using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.Hotels.Commands;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Reclamation.Commands
{
    public class ReclamationCommandsHandler :
        IRequestHandler<CreateReclamationCommand, Created>,
        IRequestHandler<UpdateReclamationCommand, NoContent>,
        IRequestHandler<DeleteReclamationCommand, NoContent>,
        IRequestHandler<UpdateReclamationStatusCommand, NoContent>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IDateTime _datetime;


        public ReclamationCommandsHandler(IApplicationDbContext context, IMapper mapper , IUserService userService, IDateTime datetime)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _datetime = datetime;
        }

        public async Task<Created> Handle(CreateReclamationCommand request, CancellationToken cancellationToken)
        {

            var validator = new CreateReclamationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            CheckIn checkin = await GetCheckinInfo(_userService.GetUserId(),request.CheckinId, cancellationToken);
            if(checkin == null)
            {
                throw new NotFoundException(nameof(checkin),checkin);
            }
            else
            {
                var reclamation = _mapper.Map<Domain.Entities.Reclamation>(request);
                using (var ms = new MemoryStream())
                {
                    request.Picture.CopyTo(ms);
                    reclamation.Picture = ms.ToArray();
                }
                reclamation.ClientId = Guid.Parse(checkin.ClientId);
                reclamation.RoomId = checkin.RoomId;
                reclamation.CreatedAt = _datetime.Now();
                reclamation.CheckinId = Guid.Parse(request.CheckinId);
                _context.Reclamations.Add(reclamation);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
           
            return default;
        }

        public async Task<NoContent> Handle(UpdateReclamationStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateReclamationStatusCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var reclamation = await _context.Reclamations
                .FirstOrDefaultAsync(o => o.Id == Guid.Parse(request.Id), cancellationToken)
                .ConfigureAwait(false);
            if (reclamation == null)
                throw new NotFoundException(nameof(Domain.Entities.Reclamation), request.Id);

            reclamation.Status = request.Status;



            _mapper.Map(request, reclamation);
           


            _context.Reclamations.Update(reclamation);

           
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }

        public async Task<NoContent> Handle(DeleteReclamationCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteReclamationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var reclamation = await _context.Reclamations.FindAsync(request.Id).ConfigureAwait(false);
            if (reclamation == null)
                throw new NotFoundException(nameof(Domain.Entities.Reclamation), request.Id);
            _context.Reclamations.Remove(reclamation);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateReclamationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateReclamationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var reclamation = await _context.Reclamations
                .FirstOrDefaultAsync(recl => recl.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (reclamation == null)
                throw new NotFoundException(nameof(Reclamation), request.Id);

            _mapper.Map(request, reclamation);
            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);
                reclamation.Picture = ms.ToArray();

            }
            _context.Reclamations.Update(reclamation);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
        public  async Task <Domain.Entities.CheckIn> GetCheckinInfo(string UserId ,string CeckinId, CancellationToken cancellation)
        {

            var checkin = await _context.CheckIns
            .FirstOrDefaultAsync(u => u.ClientId==UserId && u.Id==Guid.Parse(CeckinId), cancellation)
            .ConfigureAwait(false); 

            if (checkin == null)
            {
                return null;
            }
            else
            {
                return checkin;
            }
        }


    }
}