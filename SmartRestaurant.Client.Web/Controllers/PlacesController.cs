using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Areas.Queries.GetByFloorId;
using SmartRestaurant.Application.Restaurants.Floors.Queries.GetByRestaurantId;
using SmartRestaurant.Application.Restaurants.Places.Commands.Create;
using SmartRestaurant.Application.Restaurants.Places.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Places.Commands.Update;
using SmartRestaurant.Application.Restaurants.Places.Queries.GetByAreaId;
using SmartRestaurant.Application.Restaurants.Places.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetByAreaId;
using SmartRestaurant.Client.Web.Models;
using SmartRestaurant.Client.Web.Models.Restaurants;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Restaurants.Areas;
using SmartRestaurant.Resources.Restaurants.Places;
using SmartRestaurant.Resources.Restaurants.Tables;
using SmartRestaurant.Resources.Utils;

namespace SmartRestaurant.Client.Web.Controllers
{
   // [Area("Admin")]
    [Route("Places")]
    public class PlacesController : AdminBaseController
    {

        private readonly ILoggerService<PlacesController> _log;
        private readonly ICreatePlaceCommand createCommand;
        private readonly IUpdatePlaceCommand updateCommand;
        private readonly IDeletePlaceCommand deleteCommand;
        private readonly IHostingEnvironment _hostingEnvironnement;
        private readonly IGetPlaceByIdQuery getById;
        private readonly IGetAllRestaurantsQuery getAllRestaurants;
        private readonly IGetFloorsByRestaurantIdQuery getFloorsByRestaurantId;
        private readonly IGetAreasByFloorIdQuery getAreasByFloorId;
        private readonly IGetTablesByAreaIdQuery getTablesByAreaId;
        private readonly IGetPlacesByAreaIdQuery getPlacesByAreaId;

        public PlacesController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<PlacesController> log,
            ICreatePlaceCommand createCommand,
            IUpdatePlaceCommand updateCommand,
            IDeletePlaceCommand deleteCommand,
            IGetPlaceByIdQuery getById,
            IGetAllRestaurantsQuery getAllRestaurants,
            IGetTablesByAreaIdQuery getTablesByAreaId,
            IGetFloorsByRestaurantIdQuery getFloorsByRestaurantId,
            IGetAreasByFloorIdQuery getAreasByFloorIdQuery,
            IGetPlacesByAreaIdQuery getPlacesByAreaIdQuery

            )
            : base(configuration, mailing, notify, baselog)
        {

            _log = log;
            this.createCommand = createCommand;
            this.updateCommand = updateCommand;
            this.deleteCommand = deleteCommand;
            this.getById = getById;
            this.getAllRestaurants = getAllRestaurants;
            this.getFloorsByRestaurantId = getFloorsByRestaurantId;
            this.getAreasByFloorId = getAreasByFloorIdQuery;
            this.getTablesByAreaId = getTablesByAreaId;
            this.getPlacesByAreaId = getPlacesByAreaIdQuery;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(PlaceUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(PlaceUtilsResource.HomeNavigationTitle, Url.Action("Places", "Index"))
                .Save();

            var viewModel = new PlaceItemViewModel
            {
                
                Filter = new FilterViewModel
                {
                    Restaurants = GetRestaurants()
                }
            };
            return View(viewModel);
        }
        [HttpPost]
        [Route("index")]
        public IActionResult Index(PlaceItemViewModel viewmodel)
        {
            this.PageBreadcrumb.SetTitle(PlaceUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(PlaceUtilsResource.HomeNavigationTitle, Url.Action("Places", "Index"))
                .Save();

            viewmodel.Filter.Restaurants =
                GetRestaurants(viewmodel.Filter.SelectedRestaurantId);
            viewmodel.Filter.Floors =
                GetFloors(viewmodel.Filter.SelectedRestaurantId,
                viewmodel.Filter.SelectedFloorId);
            GetAreas(viewmodel.Filter.SelectedFloorId,
               viewmodel.Filter.SelectedAreaId);
              
            GetTables(viewmodel.Filter.SelectedAreaId,
               viewmodel.Filter.SelectedTableId);

            viewmodel.Places = getPlacesByAreaId.Execute(viewmodel.Filter.SelectedTableId);
            return View(viewmodel); 
        }

        /// <summary>
        /// Breadcrumb de la page Add
        /// </summary>
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(PlaceUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(PlaceUtilsResource.HomePageTitle, Url.Action("Index", "Places"))
               .AddItem(PlaceUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name = "name" ></ param >
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(PlaceUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(PlaceUtilsResource.HomePageTitle, Url.Action("Index", "Places"))
               .AddItem(string.Format(PlaceUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        private SelectList GetRestaurants(string selectedRestaurant = null)
        {
            return new SelectList(getAllRestaurants.Execute(null, null),
                 "Id", "Name", selectedRestaurant);

        }
        private SelectList GetFloors(string restId, string selectedFloor = null)
        {
            return new SelectList(getFloorsByRestaurantId.Execute(restId),
               "Id", "Name", selectedFloor);
        }
        private SelectList GetAreas(string floorId, string selectedArea= null)
        {
            return new SelectList(getAreasByFloorId.Execute(floorId),
               "Id", "Name", selectedArea);
        }
        private SelectList GetTables(string areaId, string selectedTable = null)
        {
            return new SelectList(getTablesByAreaId.Execute(areaId),
               "Id", "Name", selectedTable);
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            var model = new PlaceViewModel
            {
                Restaurants = GetRestaurants()
            };
            return View(model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(PlaceViewModel model)
        {
            BreadcrumbForAdd();
            try
            {
                createCommand.Execute(model.CreateModel);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }
            return View(model);
        }

        [HttpGet]
        [Route("edit")]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("BadRequest");
            }
            try
            {
                var result = getById.Execute(id);
                BreadcrumbForEdit(result.Name);

                var viewModel = new PlaceViewModel
                {
                    Restaurants = GetRestaurants(result.RestaurantId),
                    Floors = GetFloors(result.RestaurantId, result.FloorId),
                    Areas = GetAreas(result.FloorId, result.AreaId),
                    RestaurantId = result.RestaurantId,
                    FloorId = result.FloorId,
                    UpdateModel = result,
                };
                return View(viewModel);
            }
            catch (NotFoundException)
            {
                return View("NotFound");
            }

        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(PlaceViewModel viewModel)
        {
            BreadcrumbForEdit(viewModel.UpdateModel.Name);
            try
            {
                updateCommand.Execute(viewModel.UpdateModel);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }
            return View(viewModel);
        }


        [HttpGet]
        [Route("getAreasByFloorId")]
        public JsonResult GetAreasByFloorId(string parentVal)
        {
            var result = getAreasByFloorId.Execute(parentVal);

            var list = new SelectList(result, "Id", "Name");
            return Json(new TitleListModel(list, AreaResource.Area));
        }
        [HttpGet]
        [Route("getTablesByAreaId")]
        public JsonResult GetTablesByAreaId(string parentVal)
        {
            var result = getTablesByAreaId.Execute(parentVal);

            var list = new SelectList(result, "Id", "Name");
            return Json(new TitleListModel(list, TableResource.Table));
        }

        [HttpGet]
        [Route("delete")]
        public IActionResult Delete(string id)
        {
            var model = new DeleteEntityViewModel
            {
                Title = UtilsResource.DefaultDeleteEntityModalTitle
            };

            if (string.IsNullOrEmpty(id))
            {
                model.HasError = true;
                model.Error.Message = UtilsResource.BadRequestMessage;
            }
            else
            {
                try
                {
                    var entity = getById.Execute(id);
                    model.Args.Add(entity.Id);
                    model.Args.Add(Url.Action("Delete", "Places"));
                    model.Args.Add("Place");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, PlaceResource.Place);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, entity.Name);
                    model.HasError = false;

                }
                catch (NotFoundException ex)//l'exception qui est dans la couche application me retourne un message
                {
                    model.HasError = true;
                    model.Error.Message = ex.Message;
                }
                catch (Exception)//message par défaut stocké dans les ressource.
                {
                    model.HasError = true;
                    model.Error.Message = UtilsResource.ErrorMessage;
                }
            }


            return Json(model);
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var model = new DeleteEntityViewModel
            {
                Title = UtilsResource.DefaultDeleteEntityModalTitle
            };

            if (string.IsNullOrEmpty(id))
            {
                model.HasError = true;
                model.Error.Message = UtilsResource.BadRequestMessage;
            }
            else
            {
                try
                {
                    deleteCommand.Execute(new DeletePlaceModel { Id = id });
                    model.HasError = false;

                }
                catch (NotFoundException ex)
                {
                    model.HasError = true;
                    model.Error.Message = ex.Message;
                }
                catch (NestedDeleteException ex)
                {
                    model.HasError = true;
                    model.Error.Message = ex.Message;
                }
                catch (Exception)
                {
                    model.HasError = true;
                    model.Error.Message = UtilsResource.ErrorMessage;
                }
            }
            return Json(model);
        }
    }
}