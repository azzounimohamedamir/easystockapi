namespace SmartRestaurant.Application.Common.Tools
{
    public class BillHelpers
    {
        public static float CalculatePriceAfterDiscount(float price, int discount)
        {
            var discountAmount = (price * discount) / 100;
            return price - discountAmount;
        }

        public static float CalculateTVA(float price, int TvaPercentage)
        {
            return (price * TvaPercentage) / 100;
        }
    }
}
