using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
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
         IRequestHandler<DeleteHotelCommand, NoContent>



    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelsCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

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


    }
}
