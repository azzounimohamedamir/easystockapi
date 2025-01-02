using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class CaisseDto
    {
        public decimal MontantCaisse { get; set; }
        public decimal BenificeNet { get; set; }

        public decimal TotalQteVendus { get; set; }
        public decimal TotalProduitsVendus { get; set; }
        public decimal TotalBl { get; set; }
        public decimal TotalFac { get; set; }
        public decimal TotalVc { get; set; }
        public decimal TotalFp { get; set; }
        public decimal TotalBa { get; set; }
        public decimal TotalQteAchete { get; set; }

        public decimal TotalBcc{ get; set; }
        public decimal TotalBca { get; set; }

        public decimal MontantTotalVentes { get; set; }

        public decimal MontantTotalRemises { get; set; }
        public decimal MontantTotalReglementsC { get; set; }
        public decimal MontantTotalAvancementsC{ get; set; }
        public decimal MontantTotalAchats { get; set; }

        public decimal MontantTotalDepenses { get; set; }
        public decimal MontantTotalRegelementsF { get; set; }
        public decimal MontantTotalAvancementsF { get; set; }

    }
}
