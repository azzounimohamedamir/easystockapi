using System;
using System.Text.RegularExpressions;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Domain.Identity.Enums;

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

        public static bool ValidatePassword(string password)
        {
            if (password == null)
                return false;

            return password.Length >= 6;
        }

        public static bool ValidateAllRoles(string role)
        {
            if (role == null)
                return false;

            var regex =
                $"^(?:{Roles.SuperAdmin.ToString()}" +
                $"|{Roles.SupportAgent.ToString()}" +
                $"|{Roles.SalesMan.ToString()}" +
                $"|{Roles.Photograph.ToString()}" +
                $"|{Roles.FoodBusinessAdministrator.ToString()}" +
                $"|{Roles.FoodBusinessManager.ToString()}" +
                $"|{Roles.FoodBusinessOwner.ToString()}" +
                $"|{Roles.Chef.ToString()}" +
                $"|{Roles.Cashier.ToString()}" +
                $"|{Roles.Waiter.ToString()}" +
                $"|{Roles.Diner.ToString()}" +
                $"|{Roles.Anounymous.ToString()}" +
                $"|{Roles.Organization.ToString()})$";
            return new Regex(regex).Match(role).Success;
        }

        public static bool ValidateUsersRoles(string role)
        {
            if (role == null)
                return false;

            var regex =
                $"^(?:{Roles.SupportAgent.ToString()}" +
                $"|{Roles.SalesMan.ToString()}" +
                $"|{Roles.Photograph.ToString()}" +
                $"|{Roles.FoodBusinessAdministrator.ToString()}" +
                $"|{Roles.FoodBusinessManager.ToString()}" +
                $"|{Roles.FoodBusinessOwner.ToString()}" +
                $"|{Roles.Chef.ToString()}" +
                $"|{Roles.Cashier.ToString()}" +
                $"|{Roles.Waiter.ToString()}" +
                $"|{Roles.Diner.ToString()}" +
                $"|{Roles.Anounymous.ToString()}" +
                $"|{Roles.Organization.ToString()})$";
            return new Regex(regex).Match(role).Success;
        }

        public static bool ValidateRoleForOraganizationStaff(string role)
        {
            if (role == null)
                return false;

            var regex =
                $"^(?:{Roles.FoodBusinessManager.ToString()}" +
                $"|{Roles.Chef.ToString()}" +
                $"|{Roles.Cashier.ToString()}" +
                $"|{Roles.Waiter.ToString()})$";
            return new Regex(regex).Match(role).Success;
        }

        public static bool ValidateRoleForFoodBusinessStaff(string role)
        {
            if (role == null)
                return false;

            var regex =
                $"^(?:{Roles.Chef.ToString()}" +
                $"|{Roles.Cashier.ToString()}" +
                $"|{Roles.Waiter.ToString()})$";
            return new Regex(regex).Match(role).Success;
        }

        public static bool ValidateEntityNameForUploadImages(string role)
        {
            if (role == null)
                return false;

            var regex =
                $"^(?:{UploadImagesEntities.FoodBusiness}" +
                $"|{UploadImagesEntities.Zone}" +
                $"|{UploadImagesEntities.Table}" +
                $"|{UploadImagesEntities.Menu}" +
                $"|{UploadImagesEntities.SubSection})$";
            return new Regex(regex).Match(role).Success;
        }
    }
}