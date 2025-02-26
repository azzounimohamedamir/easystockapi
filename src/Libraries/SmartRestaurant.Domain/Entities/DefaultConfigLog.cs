using System;

namespace SmartRestaurant.Domain.Entities
{
    public class DefaultConfigLog
    {
        public Guid Id { get; set; }
        public string Timbre { get; set; }
        public string Tva { get; set; }
        public string ModeVente { get; set; }
        public decimal SommeFacture { get; set; }
        public decimal PointsGagner { get; set; }
        public decimal MinimumPointsToWithdraw { get; set; }
        public decimal Recompense { get; set; }

        public string DeviseParDefault { get; set; }
        public string MargeBenifDetail { get; set; }
        public string MargeBenifGros { get; set; }
        public bool AutorisationQteNeg { get; set; }
        public bool PrixAchatMoyPondere { get; set; }

    }
}
