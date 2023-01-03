using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class IllnessUserDto
    {
        public string ApplicationUserId { get; set; }
        public Guid IllnessId { get; set; }
        public IllnessDto Illness { get; set; }
    }
}
