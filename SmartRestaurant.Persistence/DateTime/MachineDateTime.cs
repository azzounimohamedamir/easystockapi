using SmartRestaurant.Application.Interfaces;

namespace SmartRestaurant.Persistence.DateTime
{
    public class MachineDateTime : IDateTime
    {
        public System.DateTime Now => System.DateTime.Now;
    }
}
