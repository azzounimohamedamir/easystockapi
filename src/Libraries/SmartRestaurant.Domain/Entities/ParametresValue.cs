using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class ParametresValue
    {
        public Guid Id { get; set; }
        public Names Names { get; set; }
        public ServiceParametreType ServiceParametreType { get; set; }
        public string Date { get; set; }
        public int NumberValue { get; set; }
        public ListingDetail SelectedValue { get; set; }
    }
}
