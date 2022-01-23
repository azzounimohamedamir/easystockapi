using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.commisiones.Commands;
using SmartRestaurant.Application.Common.Dtos.BillDtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.CommissionsMonthlyFees.Commands
{
    public class CommissionsMonthlyFeesCommandHandler :
        IRequestHandler<CalculateLastMonthCommissionFeesCommand, Created>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CommissionsMonthlyFeesCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CalculateLastMonthCommissionFeesCommand request, CancellationToken cancellationToken)
        {
            var foodBusinessesIds = await GetListOfFoodBusinessesIds().ConfigureAwait(false);

            foreach (var foodBusinessId in foodBusinessesIds)
            {
                var foodBusiness = await GetFoodBusinessById(foodBusinessId).ConfigureAwait(false);
                if (foodBusiness == null || foodBusiness.CommissionConfigs == null)
                    continue;

                if (await isMonthlyCommissionAlreadyCalculated(foodBusinessId).ConfigureAwait(false) == true)
                    continue;

                var monthlyCommission = _mapper.Map<MonthlyCommission>(foodBusiness);
                monthlyCommission.numberOfOrdersOrPersons = await GetNumberOfOrdersOrPersons(monthlyCommission).ConfigureAwait(false);
                monthlyCommission.TotalToPay = monthlyCommission.numberOfOrdersOrPersons * monthlyCommission.CommissionConfigs.Value;

                _context.MonthlyCommission.Add(monthlyCommission);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            return default;
        }

        private async Task<Domain.Entities.FoodBusiness> GetFoodBusinessById(Guid foodBusinessId)
        {
            return await _context.FoodBusinesses.AsNoTracking()
                 .FirstOrDefaultAsync(foodBusinesses => foodBusinesses.FoodBusinessId == foodBusinessId)
                 .ConfigureAwait(false);
        }

        private async Task<List<Guid>> GetListOfFoodBusinessesIds()
        {
            return await _context.FoodBusinesses
                .Where(foodBusinesses => foodBusinesses.IsActivityFrozen == false)
                .Select(foodBusinesses => foodBusinesses.FoodBusinessId)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        private async Task<bool> isMonthlyCommissionAlreadyCalculated(Guid foodBusinessId)
        {
            var lastMonth = DateTimeHelpers.GetLastMonth(DateTime.Now);
            var monthlyCommission = await _context.MonthlyCommission.AsNoTracking()
                .Where(c => c.FoodBusinessId == foodBusinessId
                && c.Month == lastMonth)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            return (monthlyCommission != null) ? true : false;             
        }

        private async Task<int> GetNumberOfOrdersOrPersons(MonthlyCommission monthlyCommission)
        {
            switch (monthlyCommission.CommissionConfigs.Type)
            {
                case CommissionType.PerPerson:                   
                    return await CalculateNumberOfPersons(monthlyCommission).ConfigureAwait(false);
                    
                case CommissionType.PerOrder:
                    return await CalculateNumberOfOrders(monthlyCommission).ConfigureAwait(false);

                default:
                    throw new Exception("Wrong Commission Type");
            }
        }

        private async Task<int> CalculateNumberOfOrders(MonthlyCommission monthlyCommission)
        {
            var firstDayOfLastMonth = monthlyCommission.Month;
            var lastDayOfLastMonth = monthlyCommission.Month.AddMonths(1).AddMilliseconds(-1);

            var ordersCount = await _context.Orders.AsNoTracking()
              .Where(o => o.FoodBusinessId == monthlyCommission.FoodBusinessId
              && o.CreatedAt >= firstDayOfLastMonth 
              && o.CreatedAt <= lastDayOfLastMonth)
              .CountAsync()
              .ConfigureAwait(false); 
            
            return ordersCount;
        }

        private async Task<int> CalculateNumberOfPersons(MonthlyCommission monthlyCommission)
        {
            var personsCount = 0;

            var firstDayOfLastMonth = monthlyCommission.Month;
            var lastDayOfLastMonth = monthlyCommission.Month.AddMonths(1).AddMilliseconds(-1);

            var ordersIds = await _context.Orders.AsNoTracking()
              .Where(o => o.FoodBusinessId == monthlyCommission.FoodBusinessId
              && o.CreatedAt >= firstDayOfLastMonth
              && o.CreatedAt <= lastDayOfLastMonth)
              .Select(o => o.OrderId)
              .ToListAsync()
              .ConfigureAwait(false);

            foreach (var orderId in ordersIds)
            {
                var order = await _context.Orders.AsNoTracking()
                    .Include(o => o.Dishes)
                    .Include(o => o.Products)
                    .FirstOrDefaultAsync(o => o.OrderId == orderId)
                    .ConfigureAwait(false);
                if (order == null)
                    continue;

                personsCount += GetPersonsCountForOrder(order);
            }
            return personsCount;
        }

        private int GetPersonsCountForOrder(Order order)
        {
            var personsCount = 0;
            var billDto = _mapper.Map<BillDto>(order);

            switch (billDto.Type)
            {
                case OrderTypes.DineIn:
                    personsCount += GetPersonsCountForDineInOrder(billDto);
                    break;

                default:
                    personsCount += 1;
                    break;
            } 
            return personsCount;
        }

        private int GetPersonsCountForDineInOrder(BillDto billDto)
        {
            var personsCount = 0;
            foreach (var table in billDto.Tables)
            {
                personsCount += table.Chairs.Count;
            }
            return personsCount;
        }
    }
}