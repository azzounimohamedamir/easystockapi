using SmartRestaurant.Application.Foods.Commands.Create;
using SmartRestaurant.Application.Foods.Commands.Delete;
using SmartRestaurant.Application.Foods.Commands.Update;
using SmartRestaurant.Application.Foods.Queries;

namespace SmartRestaurant.Application.Foods.Services
{
    public interface IFoodService
    {
        ICreateFoodCommand Create { get; }
        IUpdateFoodCommand Update { get; }
        IDeleteFoodCommand Delete { get; }
        IFoodQueries Queries { get; }
    }
}
