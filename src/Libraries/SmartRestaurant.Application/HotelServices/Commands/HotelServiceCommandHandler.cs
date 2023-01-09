using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;
using SmartRestaurant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using static System.Collections.Specialized.BitVector32;
using System.IO;
using System.Linq;

namespace SmartRestaurant.Application.HotelServices.Commands
{
    public class HotelServiceCommandHandler : IRequestHandler<CreateHotelServiceCommand, Created>,
        IRequestHandler<DeleteHotelServiceCommand, NoContent>,
        IRequestHandler<UpdateHotelServiceCommand,NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelServiceCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<Created> Handle(CreateHotelServiceCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateHotelServiceCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var entity = _mapper.Map<HotelService>(request);
            _context.HotelServices.Add(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if (!entity.isSmartrestaurantMenue)
            {
                if (request.Parametres.Count > 0)
                {
                    for (var i = 0; i < request.Parametres.Count;)
                    {
                        request.Parametres[i].HotelServiceId = (entity.Id).ToString();

                        var par = _mapper.Map<ServiceParametre>(request.Parametres[i]);
                        _context.ServiceParametres.Add(par);
                        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                        i++;
                    };
                };
            };

            return default;
            }

         public async Task<NoContent> Handle(UpdateHotelServiceCommand request,CancellationToken cancellationToken)
         {
                var validator = new UpdateHotelServiceCommandValidator();
                var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
                if (!result.IsValid) throw new ValidationException(result);

                var entity = await _context.HotelServices.AsNoTracking()
               .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken)
               .ConfigureAwait(false);
                if (entity == null)
                    throw new NotFoundException(nameof(HotelSection), request.Id);

            var editedService= _mapper.Map<HotelService>(request);
            _context.HotelServices.Update(editedService);
            await _context.SaveChangesAsync(cancellationToken);

            var oldParams = _context.ServiceParametres.Where(p => p.HotelServiceId == request.Id);
            _context.ServiceParametres.RemoveRange(oldParams);
            await _context.SaveChangesAsync(cancellationToken);

            if (!entity.isSmartrestaurantMenue)
            {
                if (request.Parametres.Count > 0)
                {
                    for (var i = 0; i < request.Parametres.Count;)
                    {
                        request.Parametres[i].HotelServiceId = (entity.Id).ToString();

                        var par = _mapper.Map<ServiceParametre>(request.Parametres[i]);
                        _context.ServiceParametres.Add(par);
                        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                        i++;
                    };
                };
            };

            return default;
         }

            public async Task<NoContent> Handle(DeleteHotelServiceCommand request, CancellationToken cancellationToken)
            {
                var validator = new DeleteHotelServiceCommandValidator();
                var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
                if (!result.IsValid) throw new ValidationException(result);

                var entity = await _context.HotelServices.FindAsync(request.Id).ConfigureAwait(false);
                if (entity == null)
                    throw new NotFoundException(nameof(HotelServices), request.Id);

                _context.HotelServices.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return default;
            }
        }
    }

