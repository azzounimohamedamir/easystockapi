namespace SmartRestaurant.Application.Common.Dtos.ValueObjects
{
    public class OrderIngredientDto
    {
        public string IngredientId { get; set; }
        public string Names { get; set; }
        public EnergeticValueDto EnergeticValue { get; set; }     
    }
}
