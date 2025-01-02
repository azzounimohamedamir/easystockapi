using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class CreditDto
    {
        public Guid Id { get; set; }
        public decimal MontantCredit { get; set; }
        public DateTime DateCredit { get; set; }
        public DateTime DateEcheance { get; set; }
    }

}
