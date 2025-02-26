using MediatR;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Scheduler
{
    public class MediatorService
    {
        private static IMediator _mediator;

        public MediatorService(IMediator mediator)
        {
            if (_mediator == null)
            {
                _mediator = mediator;
            }
        }

        public MediatorService()
        {
        }

        public IMediator Mediator()
        {
            return _mediator;
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            return await _mediator.Send(request).ConfigureAwait(false);
        }
    }
}
