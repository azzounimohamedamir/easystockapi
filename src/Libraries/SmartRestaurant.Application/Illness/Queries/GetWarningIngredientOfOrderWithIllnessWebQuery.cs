using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Illness.Queries
{
    public class GetWarningIngredientOfOrderWithIllnessWebQuery : IRequest<WarningIngredientOfOrder>
    {
        public List<SummaryQteIngredientOfDishDto>  SummaryIngredients {get;set;}
    }
}
