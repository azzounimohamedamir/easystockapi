using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class CheckInventoryResultDto
    {
        public List<Equipe> EquipesFinished { get; set; }
        public bool InventaireFinished { get; set; }

    }
}
