using System;

namespace SmartRestaurant.Domain.Entities
{
    public class CreanceAssainie
    {
        public Guid Id { get; set; }

        public DateTime DateAssainissement { get; set; }

        public string NomClient { get; set; }
        public string AssainissementSur { get; set; }

        public decimal AncienCredit { get; set; }
        public decimal MontantAssainissement { get; set; }
        public decimal Reste { get; set; }
        public string Motif { get; set; }
    }
}
