using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public static bool ValidateUrl(string url)
        {
            if (url == null)
                return false;

            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
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

        public static bool ValidateInvitationType(string type)
        {
            if (type == null)
                return false;
          
            else
            return true;
        }
        public static bool ValidateEntryUserForInvitation(string type)
        {
            if (type != TypeInvitation.hotel && type !=TypeInvitation.foodbusinness)              
                return false;
            else
                return true;
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
                $"|{Roles.Organization.ToString()}" +
                $"|{Roles.HotelClient.ToString()}" +
                $"|{Roles.HotelManager.ToString()}" +
                $"|{Roles.HotelReceptionist.ToString()}" +
                $"|{Roles.HotelServiceAdmin.ToString()})$";
            return new Regex(regex).Match(role).Success;
        }

        public static bool ValidateRoleForOraganizationStaff(string role)
        {
            if (role == null)
                return false;

            var regex =
                $"^(?:{Roles.FoodBusinessManager.ToString()}" +
                $"|{Roles.Chef.ToString()}" + $"|{Roles.HotelServiceAdmin.ToString()}"+ $"|{Roles.HotelReceptionist.ToString()}"+ $"|{Roles.HotelServiceTechnique.ToString()}"+
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


        public static bool ValidateRoleForHotelStaff(string role)
        {
            if (role == null)
                return false;

            var regex =
                $"^(?:{Roles.HotelServiceAdmin.ToString()}" +
                $"|{Roles.HotelReceptionist.ToString()})$";
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


        public static bool ValidateJsonSchemaForIngredientNames(string data)
        {
            try
            {
                dynamic jsonObject = JsonConvert.DeserializeObject<dynamic>(data);
                if (jsonObject == null || ((JArray)jsonObject).Count == 0)
                {
                    return false;
                }
                else
                {
                    foreach (var obj in jsonObject)
                    {
                        string name = obj.name;
                        string language = obj.language;
                        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(language))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IngredientNamesHasArabicLanguage(string data)
        {
            return data.Contains("\"ar\"") || data.Contains("'ar'");
        }

        public static bool IngredientNamesHasFrenchLanguage(string data)
        {

            return data.Contains("\"fr\"") || data.Contains("'fr'");
        }

        public static bool IngredientNamesHasEnglishLanguage(string data)
        {
            return data.Contains("\"en\"") || data.Contains("'en'");
        }
    }
}