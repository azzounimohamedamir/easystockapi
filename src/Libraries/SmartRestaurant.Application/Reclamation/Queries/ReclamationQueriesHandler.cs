using AutoMapper;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Extensions;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace SmartRestaurant.Application.Reclamation.Queries
{
    public class ReclamationQueriesHandler :
        IRequestHandler<GetAllReclamationListQuery, PagedListDto<ReclamationDto>>,
        IRequestHandler<GetAllReclamationOfClientQuery, PagedListDto<ReclamationDto>>

    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;
        private readonly IUserService _userservice;


        public ReclamationQueriesHandler(IApplicationDbContext context, IMapper mapper ,IUserService userservice
            )
        {
            _context = context;
            _mapper = mapper;
            _userservice = userservice;
        }

        public async Task<PagedListDto<ReclamationDto>> Handle(GetAllReclamationListQuery request,
            CancellationToken cancellationToken)
        {
            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;

            var query = (from r in _context.Reclamations
                         join room in _context.Rooms on r.RoomId equals room.Id
                         join b in _context.Buildings on room.BuildingId equals b.Id
                         join h in _context.Hotels on b.HotelId equals h.Id
                         join check in _context.CheckIns on r.RoomId equals check.RoomId
                         
                         where h.Id == Guid.Parse(request.HotelId)
                         orderby r.CreatedAt descending
                         select new ReclamationDto
                         {
                             Id = r.Id,
                             HotelName = h.Name,
                             HotelId = h.Id.ToString(),
                             BuildingName = b.Name,
                             ClientEmail = room.ClientEmail,
                             ClientPhone = check.PhoneNumber,
                             ClientName = check.FullName,
                             RoomNumber = room.RoomNumber,
                             FloorNumber = room.FloorNumber,
                             ReclamationDescription = r.ReclamationDescription,
                             CreatedAt = r.CreatedAt,
                             Picture = r.Picture,
                             Status = r.Status
                         });




            var querypaged = query.GetPaged(request.Page, request.PageSize);
            var data = await querypaged.Data.AsNoTracking().ToListAsync(cancellationToken)
                       .ConfigureAwait(false);

            if(searchKey != "")
            {
                var dataFiltered = querypaged.Data.AsNoTracking().Where(
                  a => a.HotelName.Contains(searchKey) ||
                  a.ReclamationDescription.AR.Contains(searchKey) ||
                  a.ReclamationDescription.FR.Contains(searchKey) ||
                  a.ReclamationDescription.EN.Contains(searchKey) ||
                  a.ReclamationDescription.TR.Contains(searchKey) ||
                  a.ReclamationDescription.RU.Contains(searchKey) ||
                  "R" + a.RoomNumber == searchKey ||
                  "F" + a.FloorNumber == searchKey ||
                     a.ClientName.Replace(" ", "").ToLower().Contains(searchKey.ToLower()) || 
                     a.ClientEmail.Contains(searchKey)

           ).ToList();
                var pagedResult = new PagedListDto<ReclamationDto>(querypaged.CurrentPage, querypaged.PageCount, querypaged.PageSize, querypaged.RowCount, dataFiltered);
                return pagedResult;
            }
            else
            {
                var pagedResult = new PagedListDto<ReclamationDto>(querypaged.CurrentPage, querypaged.PageCount, querypaged.PageSize, querypaged.RowCount, data);
                return pagedResult;
            }
           



            
        }


        public async Task<PagedListDto<ReclamationDto>> Handle(GetAllReclamationOfClientQuery request,
           CancellationToken cancellationToken)
        {
            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;

            var connectedUser = _userservice.GetUserId();
            var query = from r in _context.Reclamations
                        join room in _context.Rooms on r.RoomId equals room.Id
                        join b in _context.Buildings on room.BuildingId equals b.Id
                        join h in _context.Hotels on b.HotelId equals h.Id
                        join check in _context.CheckIns on r.RoomId equals check.RoomId

                        where r.ClientId.ToString() == connectedUser
                        orderby r.CreatedAt descending
                        select new ReclamationDto
                        {
                            Id = r.Id,
                            HotelName = h.Name,
                            HotelId = h.Id.ToString(),
                            BuildingName = b.Name,
                            ClientEmail = room.ClientEmail,
                            ClientPhone = check.PhoneNumber,
                            ClientName = check.FullName,
                            RoomNumber = room.RoomNumber,
                            FloorNumber = room.FloorNumber,
                            ReclamationDescription = r.ReclamationDescription,
                            CreatedAt = r.CreatedAt,
                            Picture = r.Picture,
                            Status = r.Status
                        };
            

            var querypaged = query.GetPaged(request.Page, request.PageSize);
            var data = await querypaged.Data.AsNoTracking().ToListAsync(cancellationToken)
                       .ConfigureAwait(false);

            if (searchKey != "")
            {
                var dataFiltered = querypaged.Data.AsNoTracking().Where(
                  a => a.HotelName.Contains(searchKey) ||
                  a.ReclamationDescription.AR.Contains(searchKey) ||
                  a.ReclamationDescription.FR.Contains(searchKey) ||
                  a.ReclamationDescription.EN.Contains(searchKey) ||
                  a.ReclamationDescription.TR.Contains(searchKey) ||
                  a.ReclamationDescription.RU.Contains(searchKey) 

           ).ToList();
                var pagedResult = new PagedListDto<ReclamationDto>(querypaged.CurrentPage, querypaged.PageCount, querypaged.PageSize, querypaged.RowCount, dataFiltered);
                return pagedResult;
            }
            else
            {
                var pagedResult = new PagedListDto<ReclamationDto>(querypaged.CurrentPage, querypaged.PageCount, querypaged.PageSize, querypaged.RowCount, data);
                return pagedResult;
            }

        }

    }
}
