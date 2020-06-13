namespace SmartRestaurant.Application.Foods.Commands.Create
{
    public class CreateNutritionModel
    {
        public decimal GlycemicIndex { get; set; }
        public decimal Fibre { get; set; }
        public decimal Calorie { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Lipid { get; set; }

        public CreateQuantityModel Quantity { get; set; }
    }
}