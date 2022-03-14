namespace SmartRestaurant.Application.Common.Exceptions
{
    public class MoneyNotSufficientException : BaseException
    {
        public MoneyNotSufficientException(float total, float received, string currency) : base(400,
            $"{received} {currency} is not sufficient to pay {total} {currency}")
        {
        }
    }
}