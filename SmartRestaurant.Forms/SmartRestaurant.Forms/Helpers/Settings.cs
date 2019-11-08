using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Forms.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(GeneralSettings), SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(GeneralSettings), value);
            }
        }
        public static string RestaurantId
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(RestaurantId), SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(RestaurantId), value);
            }
        }

        public static string LastServiceId
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(LastServiceId), SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(LastServiceId), value);
            }
        }



        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(AccessToken), SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(AccessToken), value);
            }
        }


        public static string username
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(username), SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(username), value);
            }
        }


        public static string password
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(password), SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(password), value);
            }
        }


    }
}
