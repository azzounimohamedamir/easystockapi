using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace SmartRestaurant.API.Scheduler
{
    public static class MediatorDependencyInjection
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            IServiceScopeFactory _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
            var scope = _scopeFactory.CreateScope();
            
            var mediator = scope.ServiceProvider.GetService<IMediator>();
            new MediatorService(mediator);
            return services;
        }
    }
}