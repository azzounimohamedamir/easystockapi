using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Common.Dtos.ValueObjects
{
    public class EnergeticValueDto
    {
        public float Fat { get; set; }
        public float Protein { get; set; }
        public float Carbohydrates { get; set; }
        public float Energy { get; set; }
        public float Amount { get; set; }
        public MeasurementUnits MeasurementUnit { get; set; }
    }
}
