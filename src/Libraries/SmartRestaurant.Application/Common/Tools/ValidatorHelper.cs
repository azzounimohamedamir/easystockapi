using System;
using System.Text.RegularExpressions;

namespace SmartRestaurant.Application.Common.Tools
{
    public class ValidatorHelper
    {
        public static bool ValidateGuid(string guid)
        {
            if (guid == null)
                return false;

            return Guid.TryParse(guid, out var newGuid);
        }

        public static bool ValidateEmail(string email)
        {
            if (email == null)
                return false;

            return new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$").Match(email).Success;
        }

        public static bool ValidateAllRoles(string role)
        {
            if (role == null)
                return false;

            var regex =
            $"^(?:{Domain.Identity.Enums.Roles.SuperAdmin.ToString()}" +
            $"|{Domain.Identity.Enums.Roles.SupportAgent.ToString()}" +
            $"|{Domain.Identity.Enums.Roles.SalesMan.ToString()}" +
            $"|{Domain.Identity.Enums.Roles.Photograph.ToString()}" +
            $"|{Domain.Identity.Enums.Roles.FoodBusinessAdministrator.ToString()}" +
            $"|{Domain.Identity.Enums.Roles.FoodBusinessManager.ToString()}" +
            $"|{Domain.Identity.Enums.Roles.FoodBusinessOwner.ToString()}" +
            $"|{Domain.Identity.Enums.Roles.Chef.ToString()}" +
            $"|{Domain.Identity.Enums.Roles.Cashier.ToString()}" +
            $"|{Domain.Identity.Enums.Roles.Waiter.ToString()}" +
            $"|{Domain.Identity.Enums.Roles.Diner.ToString()}" +
            $"|{Domain.Identity.Enums.Roles.Anounymous.ToString()}" +
            $"|{Domain.Identity.Enums.Roles.Organization.ToString()})$";
            return new Regex(regex).Match(role).Success;
        }

        public static bool ValidateRoleForOraganizationStaff(string role)
        {
            if (role == null)
                return false;

            var regex =
            $"^(?:{Domain.Identity.Enums.Roles.FoodBusinessManager.ToString()}" +
            $"|{Domain.Identity.Enums.Roles.Chef.ToString()}" +
            $"|{Domain.Identity.Enums.Roles.Cashier.ToString()}" +
            $"|{Domain.Identity.Enums.Roles.Waiter.ToString()})$";
            return new Regex(regex).Match(role).Success;
        }
    }
}
