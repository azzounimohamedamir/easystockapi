using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Dishes.DishAccompaniments.Models;
using SmartRestaurant.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Dishes.DishAccompaniments.Factory
{


    public interface IDishAccompanimentModelFactory
    {
        DishAccompanyingModel Create(
                                string parentId,
                                string accompanyingId,
                                bool isDisabled,
                                QuantityModel quantity);

        DishAccompanyingModel Create(DishAccompanying model);

        IEnumerable<DishAccompanyingModel> Create(IEnumerable<DishAccompanying> entities);
    }

    public class DishAccompanimentModelFactory : IDishAccompanimentModelFactory
    {
        private readonly IQuantityModelFactory quantityModelFactory;

        public DishAccompanimentModelFactory(IQuantityModelFactory quantityModelFactory)
        {
            this.quantityModelFactory = quantityModelFactory ?? throw new ArgumentNullException(nameof(quantityModelFactory));
        }


        public DishAccompanyingModel Create(DishAccompanying entity)
        {
            return Create(entity.ParentId.ToString(), entity.AccompanyingId.ToString(), entity.IsDisabled, quantityModelFactory.Create(entity.Quantity));
        }

        public DishAccompanyingModel Create(string parentId, string accompanyingId, bool isDisabled, QuantityModel quantity)
        {
            return new DishAccompanyingModel
            {
                ParentId = parentId,
                AccompanyingId = accompanyingId,
                IsDisabled = isDisabled,
                Quantity = quantity,
            };
        }


        public IEnumerable<DishAccompanyingModel> Create(IEnumerable<DishAccompanying> entities)
        => (from entity in entities select Create(entity)).AsEnumerable();
    }
}
