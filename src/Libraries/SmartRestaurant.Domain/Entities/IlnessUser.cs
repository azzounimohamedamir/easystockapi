using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class IlnessUser
    {
        public string ApplicationUserId { get; set; }
        public Guid IllnessId { get; set; }
        public Illness Illness { get; set; }
    }
}
