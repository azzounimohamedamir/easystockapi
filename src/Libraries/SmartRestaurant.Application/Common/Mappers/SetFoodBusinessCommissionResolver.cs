using AutoMapper;
using SmartRestaurant.Application.commisiones.Commands;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Common.Mappers
{
    public class SetFoodBusinessCommissionResolver : IValueResolver<SetFoodBusinessCommissionCommand, Domain.Entities.FoodBusiness, CommissionConfigs>
    {
        public CommissionConfigs Resolve(SetFoodBusinessCommissionCommand source, Domain.Entities.FoodBusiness destination, CommissionConfigs member, ResolutionContext context)
        {
            return new CommissionConfigs
            {
                Value = source.Value,
                Type = source.Type,
                WhoPay = source.WhoPay,
            };
        }
      
    }
}
