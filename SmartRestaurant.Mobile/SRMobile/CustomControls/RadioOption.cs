using SmartRestaurant.Diner.Infrastructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Diner.CustomControls
{
    public class RadioOption : SimpleViewModel
    {
        public string Name {
            get;
        }
        private bool _isSelected { get; set; }
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (value != _isSelected)
                {
                    this._isSelected = value;
                    RaisePropertyChanged();
                }
            }
        }
        public RadioOption(string name, bool isSelected)
        {
            this.Name = name;
            this.IsSelected = isSelected;
        }

    }
}
