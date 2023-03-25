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
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Reclamation.Queries
{
    public class ReclamationQueriesHandler :
        IRequestHandler<GetAllReclamationListQuery, PagedListDto<ReclamationDto>>,
        IRequestHandler<GetAllReclamationOfClientQuery, PagedListDto<ReclamationDto>>,
       IRequestHandler<GetAllReclamationListOfServiceTechniqueQuery, PagedListDto<ReclamationDto>>


    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;
        private readonly IUserService _userservice;
        private readonly IDateTime _dateTime;

        public ReclamationQueriesHandler(IApplicationDbContext context, IMapper mapper ,IUserService userservice,IDateTime datetime
            )
        {
            _context = context;
            _mapper = mapper;
            _dateTime= datetime;
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
                         join t in _context.TypeReclamations on r.TypeReclamationId equals t.TypeReclamationId
                         join servicetech in _context.ServiceTechniques on t.ServiceTechniqueId equals servicetech.ServiceTechniqueId
                         join check in _context.CheckIns on r.RoomId equals check.RoomId

                         where h.Id == Guid.Parse(request.HotelId) && r.DelaiExpiredAt < _dateTime.Now() && r.Status != ReclamationStatus.Resolved && r.IsHidden == false
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
                             ReclamationDescription = t.Names,
                             ServiceTechniqueId = servicetech.ServiceTechniqueId,
                             ServiceTechniqueOfReclamation = servicetech.Names,
                             CreatedAt = r.CreatedAt,
                             Picture = r.Picture,
                             Status = r.Status,
                             DelaiFinishedAt = r.DelaiExpiredAt
                         });




            var querypaged = query.GetPaged(request.Page, request.PageSize);
           

            if(searchKey != "")
            {
                var dataFiltered = querypaged.Data.AsNoTracking().Where(
                 
                  a => a.HotelName.Contains(searchKey) ||
                  a.ServiceTechniqueId.ToString() == searchKey ||
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
                var pagedResult = new PagedListDto<ReclamationDto>(querypaged.CurrentPage, querypaged.PageCount, querypaged.PageSize, querypaged.RowCount, querypaged.Data.AsNoTracking().ToList());
                return pagedResult;
            }
           



            
        }





        public async Task<PagedListDto<ReclamationDto>> Handle(GetAllReclamationListOfServiceTechniqueQuery request,
           CancellationToken cancellationToken)
        {
            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;

            var query = (from r in _context.Reclamations
                         join room in _context.Rooms on r.RoomId equals room.Id
                         join b in _context.Buildings on room.BuildingId equals b.Id
                         join h in _context.Hotels on b.HotelId equals h.Id
                         join t in _context.TypeReclamations on r.TypeReclamationId equals t.TypeReclamationId
                         join servicetech in _context.ServiceTechniques on t.ServiceTechniqueId equals servicetech.ServiceTechniqueId
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
                             ReclamationDescription = t.Names,
                             ServiceTechniqueId = servicetech.ServiceTechniqueId,
                             ServiceTechniqueOfReclamation = servicetech.Names,
                             CreatedAt = r.CreatedAt,
                             Picture = r.Picture,
                             Status = r.Status,
                             DelaiFinishedAt = r.DelaiExpiredAt
                         });




            var querypaged = query.GetPaged(request.Page, request.PageSize);


            if (searchKey != "")
            {
                var dataFiltered = querypaged.Data.AsNoTracking().Where(

                  a => a.HotelName.Contains(searchKey) ||
                  a.ServiceTechniqueId.ToString() == searchKey ||
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
                var pagedResult = new PagedListDto<ReclamationDto>(querypaged.CurrentPage, querypaged.PageCount, querypaged.PageSize, querypaged.RowCount, querypaged.Data.AsNoTracking().ToList());
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
                        join t in _context.TypeReclamations on r.TypeReclamationId equals t.TypeReclamationId
                        join servicetech in _context.ServiceTechniques on t.ServiceTechniqueId equals servicetech.ServiceTechniqueId
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
                            ReclamationDescription = t.Names,
                            TypeReclamationId=t.TypeReclamationId,
                            ServiceTechniqueOfReclamation = servicetech.Names,
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
