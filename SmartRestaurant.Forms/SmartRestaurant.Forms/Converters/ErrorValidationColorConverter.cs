#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;


using SmartRestaurant.Controls;
using SmartRestaurant.ViewModels.Login;

namespace SmartRestaurant.Converters
{
    /// <summary>
    /// Which is used to convert the email entry border color.
    /// </summary>
    public class ErrorValidationColorConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the bool to color
        /// </summary>
        /// <param name="value">Gets the value</param>
        /// <param name="targetType">Gets the target type</param>
        /// <param name="parameter">Gets the parameter</param>
        /// <param name="culture">Gets the culture</param>
        /// <returns>Return the color</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BorderlessEntry emailEntry = parameter as BorderlessEntry;
            LoginPageViewModel bindingContext = emailEntry.BindingContext as LoginPageViewModel;

            if (bindingContext != null)
            {
                var isFocused = (bool)value;
                bindingContext.IsInvalidEmail = isFocused ? false : !CheckValidEmail(bindingContext.Email);
               
                if (isFocused)
                {
                    return Color.FromRgba(255, 255, 255, 0.6);
                }
               
                if (bindingContext.IsInvalidEmail)
                {
                    return Color.FromHex("#FF4A4A");
                }
            }

            return Color.White;
        }

        /// <summary>
        /// This method is used to convert back the color to bool
        /// </summary>
        /// <param name="value">Gets the value</param>
        /// <param name="targetType">Gets the target type</param>
        /// <param name="parameter">Gets the parameter</param>
        /// <param name="culture">Gets the culture</param>
        /// <returns>Returns the string</returns>        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        /// <summary>
        /// Which is used to validate the email.
        /// </summary>
        /// <param name="email">Gets the email</param>
        /// <returns>Returns the boolean value</returns>
        private static bool CheckValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return true;

            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return regex.IsMatch(email) && !email.EndsWith(".");
        }
    }
}
