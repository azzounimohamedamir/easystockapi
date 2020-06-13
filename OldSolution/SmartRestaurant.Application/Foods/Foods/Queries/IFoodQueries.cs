using SmartRestaurant.Application.Foods.Foods.Queries.GetByCategoryId;
using SmartRestaurant.Application.Foods.Queries.GetAll;
using SmartRestaurant.Application.Foods.Queries.GetById;
using SmartRestaurant.Application.Foods.Queries.GetBySpecification;

namespace SmartRestaurant.Application.Foods.Queries
{
    public interface IFoodQueries
    {
        IGetFoodByIdQuery GetById { get; }
        IGetFoodsByCategoryIdQuery GetListByCategoryId { get; }
        IGetAllFoodsQuery List { get; }
        IGetFoodBySpecificationQuery Filter { get; }
    }
}