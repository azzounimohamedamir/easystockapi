using SmartRestaurant.Application.Commun.Units.Commands.Create;

namespace SmartRestaurant.Application.Commun.Units.Commands.Update
{
    public class UpdateUnitModel :CreateUnitModel,IUpdateUnitModel
    {
        public string Id { get; set; }
        
    }
}