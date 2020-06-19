namespace SmartRestaurant.Application.Commun.Quantities
{
    public class QuantityModel : IQuantityModel
    {
        public QuantityModel()
        {

        }
        public QuantityModel(string unitId, decimal value)
        {
            UnitId = unitId;
            Value = value;
        }
        public string UnitId { get; set; }
        public decimal Value { get; set; }


    }
}