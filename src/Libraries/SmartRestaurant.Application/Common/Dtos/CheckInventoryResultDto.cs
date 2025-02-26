using SmartRestaurant.Domain.Enums;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class CheckInventoryResultDto
    {
        public List<Equipe> EquipesFinished { get; set; }
        public bool InventaireFinished { get; set; }

    }
}
