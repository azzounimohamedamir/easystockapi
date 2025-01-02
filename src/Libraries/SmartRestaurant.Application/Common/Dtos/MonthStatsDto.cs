using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class MonthStatsDto
    {
        public decimal JanuaryVCA { get; set; }
        public decimal JanuaryACA { get; set; }

        // February
        public decimal FebruaryVCA { get; set; }
        public decimal FebruaryACA { get; set; }

        // March
        public decimal MarchVCA { get; set; }
        public decimal MarchACA { get; set; }

        // April
        public decimal AprilVCA { get; set; }
        public decimal AprilACA { get; set; }

        // May
        public decimal MayVCA { get; set; }
        public decimal MayACA { get; set; }

        // June
        public decimal JuneVCA { get; set; }
        public decimal JuneACA { get; set; }

        // July
        public decimal JulyVCA { get; set; }
        public decimal JulyACA { get; set; }

        // August
        public decimal AugustVCA { get; set; }
        public decimal AugustACA { get; set; }

        // September
        public decimal SeptemberVCA { get; set; }
        public decimal SeptemberACA { get; set; }

        // October
        public decimal OctoberVCA { get; set; }
        public decimal OctoberACA { get; set; }

        // November
        public decimal NovemberVCA { get; set; }
        public decimal NovemberACA { get; set; }

        // December
        public decimal DecemberVCA { get; set; }
        public decimal DecemberACA { get; set; }

        public List<ProduitVQteDto> ProduitsVendus{ get;set; }
        public List<ProduitVQteDto> ProduitsAchetes { get; set; }
        public List<ProduitVQteDto> Top10ProductsV { get; set; }
        public List<MarqueVQteDto> Top10MarquesV { get; set; }
        public List<FamilleVQteDto> Top10FamilleV { get; set; }

    }
}
