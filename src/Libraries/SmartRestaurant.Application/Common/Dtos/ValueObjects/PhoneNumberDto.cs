using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Common;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Dtos.ValueObjects
{
    public class PhoneNumberDto
    {
        public int CountryCode { get; set; }
        public int Number { get; set; }
    }
}
