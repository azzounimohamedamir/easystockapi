using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Hotels.Commands
{
    public class HotelsCommandsHandler :
        IRequestHandler<CreateHotelCommand, Created>,
         IRequestHandler<DeleteHotelCommand, NoContent>,
        IRequestHandler<UpdateHotelCommand, NoContent>,
        IRequestHandler<UpdateHotelRatingCommand, HotelDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HotelsCommandsHandler(IApplicationDbContext context, IUserService userService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _userManager = userManager;

        }

        public async Task<Created> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var HotelName = await _context.Hotels
           .FirstOrDefaultAsync(u => u.Name.ToUpper() == request.Name.ToUpper(), cancellationToken)
           .ConfigureAwait(false); ;
            if (HotelName != null)
            {
                throw new ConflictException("Hotel '" + request.Name + "' already exists");
            }
            var validator = new CreateHotelCommandValidator();
             var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
             if (!result.IsValid) throw new ValidationException(result);


            var hotel = _mapper.Map<Domain.Entities.Hotel>(request);
            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);
                hotel.Picture = ms.ToArray();
            }
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }




        public async Task<NoContent> Handle(UpdateHotelCommand request,
           CancellationToken cancellationToken)
        {
            var validator = new UpdateHotelCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var hotel = await _context.Hotels
                .FirstOrDefaultAsync(hotel => hotel.Id == Guid.Parse(request.Id), cancellationToken)
                .ConfigureAwait(false);
            if (hotel == null)
                throw new NotFoundException(nameof(Hotels), request.Id);

            _mapper.Map(request, hotel);
            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);
                hotel.Picture = ms.ToArray();
                
            }
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }



        public async Task<NoContent> Handle(DeleteHotelCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new DeleteHotelCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var entity = await _context.Hotels.FindAsync(request.Id).ConfigureAwait(false);

            if (entity == null)
                throw new NotFoundException(nameof(Hotels), request.Id);

            _context.Hotels.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return default;
        }


        public async Task<HotelDto> Handle(UpdateHotelRatingCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateHotelRatingCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var hotels = await _context.Hotels.AsNoTracking()
                .FirstOrDefaultAsync(hotels => hotels.Id == Guid.Parse(request.HotelId), cancellationToken)
                .ConfigureAwait(false);
            if (hotels == null)
                throw new NotFoundException(nameof(Hotel), request.HotelId);

            var user_id = _userService.GetUserId();

            var user = await _userManager.FindByIdAsync(user_id);
            if (user == null)
                throw new NotFoundException(nameof(user), user_id);


            var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            if (roles.Contains(Roles.HotelClient.ToString()))
            {
                var rating = await _context.HotelUserRatings.AsNoTracking()
                .FirstOrDefaultAsync(rating => rating.HotelId == Guid.Parse(request.HotelId) && rating.ApplicationUserId == Guid.Parse(user_id), cancellationToken)
                .ConfigureAwait(false);

                request.ApplicationUserId = user_id;
                if (rating == null)
                {
                    var r = _mapper.Map<Domain.Entities.HotelUserRating>(request);
                    _context.HotelUserRatings.Add(r);
                }
                else
                {
                    _mapper.Map(request, rating);
                    _context.HotelUserRatings.Update(rating);
                }

                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            }
            else
            {
                throw new RolesCheckException("The user must have the role of Diner");
            }

            hotels.AverageRating = CalculateHotelRating(hotels.Id);
            _context.Hotels.Update(hotels);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var entity = _mapper.Map<HotelDto>(hotels);
            entity.CurrentUserRating = request.Rating;
            return entity;
        }

        public double CalculateHotelRating(Guid HotelId)
        {
            double averageRating = 0;
           var hotelRatings = _context.HotelUserRatings.Where(ratings => ratings.HotelId == HotelId);
            if (hotelRatings.Any())
            {
                averageRating = hotelRatings.Average(ratings => ratings.Rating);
            }
            return averageRating;
        }


    }
}
