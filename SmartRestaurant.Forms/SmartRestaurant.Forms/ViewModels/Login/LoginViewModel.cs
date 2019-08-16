#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmartRestaurant.ViewModels.Login
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string email;

        private bool isInvalidEmail;

        /// <summary>
        /// This property is bound with an entry that gets the email ID from the user in the login page.
        /// </summary>
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (email == value)
                {
                    return;
                }
                email = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the entered email is valid or invalid.
        /// </summary>
        public bool IsInvalidEmail
        {
            get
            {
                return isInvalidEmail;
            }
            set
            {
                if (isInvalidEmail == value)
                {
                    return;
                }
                isInvalidEmail = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
