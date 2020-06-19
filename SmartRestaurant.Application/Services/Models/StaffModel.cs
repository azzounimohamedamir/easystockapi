namespace SmartRestaurant.Application.Services.Models
{
    public class BaseStaffModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string Alias { get; set; }
        public string IsDisabled { get; set; }
    }

    public class GuestModel : BaseStaffModel
    {

    }

    public class WaiterModel : BaseStaffModel
    {

    }

    public class CookerModel : BaseStaffModel
    {

    }
}
