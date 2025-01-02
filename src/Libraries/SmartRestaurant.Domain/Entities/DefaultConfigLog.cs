using SmartRestaurant.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class DefaultConfigLog
    {
        public Guid Id { get; set; }
        public string Timbre { get; set; }
        public string Tva { get; set; }
        public Guid Categorie {  get; set; }
        public string ModeVente { get; set; }
        public string SommeFacture { get; set; }
        public string PointsGagner { get; set; }
        public string DeviseParDefault { get; set; }
        public string MargeBenifDetail { get; set; }
        public string MargeBenifGros { get; set; }
        public bool AutorisationQteNeg { get; set; }
        public bool PrixAchatMoyPondere { get; set; }

    }
}
