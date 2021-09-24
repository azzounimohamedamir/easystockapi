namespace SmartRestaurant.Application.Common.Exceptions
{
    public class QuantityNotAllowedException : BaseException
    {
        public QuantityNotAllowedException(string ingredient, float quantity, float maxQuantity, string measurementUnit)
            : base(400,
                $"Ingredient {ingredient} quantity {quantity} {measurementUnit} is more than max value {maxQuantity} {measurementUnit}")
        {
        }
    }
}