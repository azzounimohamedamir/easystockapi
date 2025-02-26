namespace SmartRestaurant.Application.Common.Exceptions
{
    public class FoodBusinessActivityFrozenException : BaseException
    {
        public FoodBusinessActivityFrozenException(string foodBusinessName) : base(423, "FoodBusiness Activity Frozen")
        {
            Errors.Add($"The activity named '{foodBusinessName}' has been Frozen, please contact application administrator for more informations");
        }
    }
}