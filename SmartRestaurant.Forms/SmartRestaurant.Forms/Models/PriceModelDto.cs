using SmartRestaurant.Application.Services.Models;

namespace SmartRestaurant.Forms.Models
{
    public class PriceModelDto : BaseModel
    {
        public string Currency { get; set; } 
        public decimal Amount { get; set; }

        public static implicit operator PriceModelDto(PriceModel model)
        {
            if (model == null) return null;
            return new PriceModelDto
            {
                Currency = model.Currency,
                Amount = model.Amount
            };
        }
        public static implicit operator PriceModel(PriceModelDto model)
        {
            if (model == null) return null;
            return new PriceModel
            {
                Currency = model.Currency,
                Amount = model.Amount
            };
        }

    }
}