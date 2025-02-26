namespace SmartRestaurant.Application.Common.Exceptions
{
    public class AvancesCreditsException : BaseException
    {
        public AvancesCreditsException()
            : base(400,
                $"Cannot Delete Client Having Credits or Avance ")
        {
        }
    }
}
