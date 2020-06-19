using SmartRestaurant.Application.Commun.Select;
using SmartRestaurant.Application.FoodCategories.Commands;
using SmartRestaurant.Application.FoodCategories.Commands.Delete;
using SmartRestaurant.Application.FoodCategories.Commands.Update;
using SmartRestaurant.Application.FoodCategories.Queries;
using SmartRestaurant.Application.FoodCategories.Queries.GetAll;
using SmartRestaurant.Application.Foods.FoodCategories.Queries;
using SmartRestaurant.Application.Foods.Specifications;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System.Collections.Generic;

namespace SmartRestaurant.Application.FoodCategories.Services
{
    public interface IFoodCategoryService
    {
        ICreateFoodCategoryCommand Create { get; }
        IUpdateFoodCategoryCommand Update { get; }
        IDeleteFoodCatergoryCommand Delete { get; }
        IFoodCategoryQueries Queries { get; }     
    }
}
