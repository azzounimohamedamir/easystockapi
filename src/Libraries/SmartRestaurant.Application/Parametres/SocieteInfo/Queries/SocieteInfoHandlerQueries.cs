using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;


namespace SmartRestaurant.Application.Parametres.SocieteInfo.Queries
{
    public class SocieteInfoHandlerQueries :
        IRequestHandler<GetSocieteInfoQuery,Domain.Entities.SocieteInfo>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SocieteInfoHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        public async Task<Domain.Entities.SocieteInfo> Handle(GetSocieteInfoQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetSocieteInfoQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var societeInfo = _context.SocieteInfos.FirstOrDefault();

            if (societeInfo != null)
            {
                return societeInfo;
            }
            else
            {
                return null;
            }

           
        }

       
            }
        }
    