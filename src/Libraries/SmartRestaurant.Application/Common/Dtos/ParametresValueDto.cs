using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ParametresValueDto
    {
        public Guid Id { get; set; }
        public NamesDto Names { get; set; }
        public ServiceParametreType ServiceParametreType { get; set; }
        public string Date { get; set; }
        public int NumberValue { get; set; }
        public ListingDetailDto SelectedValue { get; set; }
    }
}
