using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SmartRestaurant.Diner.Models
{
    /// <summary>
    /// Used to manage languages
    /// </summary>
    public class LanguageModel
    {
        /// <summary>
        /// The langue name to display to the user.
        /// </summary>
        private string displayName;
        public string DisplayName
        {
            get { return displayName; }
            set
            {
                if (value != displayName)
                {
                    displayName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DisplayName"));
                }
            }
        }

        /// <summary>
        /// The short name used to manages resources and CultureInfo
        /// </summary>
        private string shortName;
        public string ShortName
        {
            get { return shortName; }
            set
            {
                if (value != shortName)
                {
                    shortName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ShortName"));
                }
            }
        }

        /// <summary>
        /// Used to indicate the language selected.
        /// </summary>
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsSelected"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
