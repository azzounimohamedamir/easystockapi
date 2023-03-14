using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.Products.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;


namespace SmartRestaurant.Application.FoodBusinessClient.Commands
{
    public class FoodBusinessClientCommandHandler :
        IRequestHandler<CreateFoodBusinessClientCommand, Created>,
        IRequestHandler<UpdateFoodBusinessClientCommand, NoContent>,
        IRequestHandler<DeleteFoodBusinessClientCommand, NoContent>,
        IRequestHandler<ArchiveFoodBusinessClientCommand, NoContent>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOdooRepository _saleOrderRepository;
        public FoodBusinessClientCommandHandler(IApplicationDbContext context, IMapper mapper,
            UserManager<ApplicationUser> userManager, IOdooRepository saleOrderRepository)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _saleOrderRepository = saleOrderRepository;
        }
        public async Task<Created> Handle(CreateFoodBusinessClientCommand request,
           CancellationToken cancellationToken)
        {
            var validator = new CreateFoodBusinessClientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var foodBusiness = await _context.FoodBusinesses
               .Where(x => x.FoodBusinessId == Guid.Parse(request.FoodBusinessId))
               //.Select(x => x.FoodBusinessId)
               .FirstOrDefaultAsync(cancellationToken)
               .ConfigureAwait(false);
            if (foodBusiness==null)
                throw new NotFoundException(nameof(Domain.Entities.FoodBusiness), request.FoodBusinessId);

            var foodBusinessClient = await _context.FoodBusinessClients
               .FirstOrDefaultAsync(
                   x => x.Email == request.Email && x.FoodBusinessId.ToString() == request.FoodBusinessId,
                   cancellationToken)
               .ConfigureAwait(false);

            if (foodBusinessClient != null)
                throw new ConflictException("Duplicate Emails are not allowed");


            var entity = _mapper.Map<Domain.Entities.FoodBusinessClient>(request);
            var odooId = await CreateOdooClient(request, foodBusiness);
            entity.OdooId= odooId;
            _context.FoodBusinessClients.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
        public async Task<NoContent> Handle(UpdateFoodBusinessClientCommand request,
           CancellationToken cancellationToken)
        {
            var validator = new UpdateFoodBusinessClientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var FoodBusinessClients = await _context.FoodBusinessClients.AsNoTracking()
                .FirstOrDefaultAsync(FoodBusinessClients => FoodBusinessClients.FoodBusinessClientId == Guid.Parse(request.Id), cancellationToken)
                .ConfigureAwait(false);
            if (FoodBusinessClients == null)
                throw new NotFoundException(nameof(FoodBusinessClient), request.Id);

            _mapper.Map(request, FoodBusinessClients);
            _context.FoodBusinessClients.Update(FoodBusinessClients);
            var foodBusiness = await _context.FoodBusinesses.AsNoTracking()
                    .FirstOrDefaultAsync(r => r.FoodBusinessId == FoodBusinessClients.FoodBusinessId, cancellationToken).ConfigureAwait(false);
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), FoodBusinessClients.FoodBusinessId);

            var odooId = await UpdateOdooClient(request, foodBusiness, FoodBusinessClients.OdooId);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteFoodBusinessClientCommand request,
           CancellationToken cancellationToken)
        {
            var validator = new DeleteFoodBusinessClientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var entity = await _context.FoodBusinessClients.AsNoTracking().FirstOrDefaultAsync(r => r.FoodBusinessClientId == Guid.Parse(request.Id), cancellationToken).ConfigureAwait(false);

            if (entity == null)
                throw new NotFoundException(nameof(FoodBusinessClient), request.Id);

            _context.FoodBusinessClients.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }
        public async Task<NoContent> Handle(ArchiveFoodBusinessClientCommand request,
          CancellationToken cancellationToken)
        {
            var validator = new ArchiveFoodBusinessClientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusinessClient = await _context.FoodBusinessClients.AsNoTracking()
                .FirstOrDefaultAsync(FoodBusinessClients => FoodBusinessClients.FoodBusinessClientId.ToString() == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (foodBusinessClient == null)
                throw new NotFoundException(nameof(FoodBusinessClient), request.Id);

            foodBusinessClient.Archived = request.Archived;
            _context.FoodBusinessClients.Update(foodBusinessClient);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        private async Task<long> CreateOdooClient(CreateFoodBusinessClientCommand request, SmartRestaurant.Domain.Entities.FoodBusiness foodBusiness)
        {
            await _saleOrderRepository.Authenticate(foodBusiness.Odoo);
            long countryId = await getCountryId(request.Address.Country);
            var data = new Dictionary<string, object>
            {
                { "name", request.Name},
                { "contact_address",request.Address },
                { "contact_address_complete",request.Address},
                { "phone", request.PhoneNumber.CountryCode+request.PhoneNumber.Number},
                { "website", request.Website},
                { "email",  request.Email },
                { "company_type","company" },
                { "type","contact" },
                { "street",request.Address.StreetAddress },
                { "city",request.Address.City },
                { "country_id",countryId }
            };


            var odooId = await _saleOrderRepository.CreateAsync("res.partner", data);

            return odooId;
        }

        private async Task<long> UpdateOdooClient(UpdateFoodBusinessClientCommand request, SmartRestaurant.Domain.Entities.FoodBusiness foodBusiness, long odooId)
        {
            await _saleOrderRepository.Authenticate(foodBusiness.Odoo);
            long countryId = await getCountryId(request.Address.Country);
            var data = new Dictionary<string, object>
            {
                { "name", request.Name},
                { "contact_address",request.Address },
                { "contact_address_complete",request.Address},
                { "phone", request.PhoneNumber.CountryCode+""+request.PhoneNumber.Number},
                { "website", request.Website},
                { "email",  request.Email },
                { "company_type","company" },
                { "type","contact" },
                { "street",request.Address.StreetAddress },
                { "city",request.Address.City },
                { "country_id",countryId }
            };

            return await _saleOrderRepository.UpdateAsync("res.partner", odooId, data);
        }

        private async Task<long> getCountryId(string countryName)
        {
            var result = await _saleOrderRepository.Search<List<int>>("res.country", "name", countryName, 1);
            if (result.Count > 0)
            {
                return result[0];
            }
            else
            {
                return -1;
            }

            
        }
    }
}
