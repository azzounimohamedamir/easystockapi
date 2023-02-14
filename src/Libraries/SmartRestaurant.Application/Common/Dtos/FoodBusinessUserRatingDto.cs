using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class FoodBusinessUserRatingDto
    {
        public Guid FoodBusinessId { get; set; }
        public Guid ApplicationUserId { get; set; }
        public int Rating { get; set; }
    }
}