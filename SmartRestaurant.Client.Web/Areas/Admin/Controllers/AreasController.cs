using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.FoodCategories.Commands.Update;
using SmartRestaurant.Application.FoodCategories.Commands;
using SmartRestaurant.Application.FoodCategories.Services;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Models.Foods;
using SmartRestaurant.Resources.Foods.FoodCategories;
using SmartRestaurant.Application.Restaurants.Areas.Commands.Create;
using SmartRestaurant.Application.Restaurants.Areas.Commands.Update;
using SmartRestaurant.Application.Restaurants.Areas.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Areas.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Areas.Queries.GetByFloorId;
using SmartRestaurant.Resources.Restaurants.Areas;
using SmartRestaurant.Client.Web.Models.Restaurants;
using SmartRestaurant.Application.Restaurants.Floors.Queries.GetByRestaurantId;
using Microsoft.AspNetCore.Hosting;
using SmartRestaurant.Application.Restaurants.Areas.Queries.GetByRestaurantId;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Floors.Queries.GetById;
using SmartRestaurant.Resources.Restaurants.Floors;
using SmartRestaurant.Application.Foods.Queries.GetById;
using SmartRestaurant.Client.Web.Models;
using SmartRestaurant.Resources.Utils;
using SmartRestaurant.Client.Web.Models.Utils;

namespace SmartRestaurant.Client.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/restaurants/areas")]
    public class AreasController : AdminBaseController
    {
        
        private readonly ILoggerService<AreasController> _log;
        private readonly ICreateAreaCommand createCommand;
        private readonly IUpdateAreaCommand updateCommand;
        private readonly IDeleteAreaCommand deleteCommand;
        private readonly IGetAreaByIdQuery getById;
        private readonly IGetAreasByFloorIdQuery getByFloorId;
        private readonly IGetFloorByIdQuery getFloorById;
        private readonly IGetAreasByRestaurantIdQuery getByRestaurantId;
        private readonly IHostingEnvironment _hostingEnvironnement;
        private readonly IGetAllRestaurantsQuery IGetAllRestaurantsQuery;
        private readonly IGetFloorsByRestaurantIdQuery IGetFloorsByRestaurantIdQuery;

        public AreasController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<AreasController> log,
            ICreateAreaCommand createCommand,
            IUpdateAreaCommand updateCommand,
            IDeleteAreaCommand deleteCommand,
            IGetAreaByIdQuery getById,
            IGetAreasByFloorIdQuery getByFloorId,
            IGetAreasByRestaurantIdQuery getByRestaurantId,
            IHostingEnvironment hostingEnvironnement,
            IGetAllRestaurantsQuery IGetAllRestaurantsQuery,
            IGetFloorsByRestaurantIdQuery IGetFloorsByRestaurantIdQuery
            )
            : base(configuration, mailing, notify, baselog)
        {
            this.IGetAllRestaurantsQuery = IGetAllRestaurantsQuery;
            this.IGetFloorsByRestaurantIdQuery = IGetFloorsByRestaurantIdQuery;
            _log = log;
            this.createCommand = createCommand;
            this.updateCommand = updateCommand;
            this.deleteCommand = deleteCommand;
            this.getById = getById;
            this.getByFloorId = getByFloorId;
            this.getByRestaurantId = getByRestaurantId;


            _hostingEnvironnement = hostingEnvironnement;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(AreaUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(AreaUtilsResource.HomeNavigationTitle, Url.Action("Areas", "Index"))
                .Save();
            GetRestaurants();
            var viewModel = new AreaItemViewModel
            {
                AreaFilterViewModel = new AreaFilterViewModel
                {
                    Restaurants = GetRestaurants()
                }
            };
            return View(viewModel);
        }
        [HttpPost]
        [Route("index")]
        public IActionResult Index(AreaItemViewModel viewmodel)
        {
            this.PageBreadcrumb.SetTitle(AreaUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(AreaUtilsResource.HomeNavigationTitle, Url.Action("Areas", "Index"))
                .Save();
         
            viewmodel.AreaFilterViewModel.Restaurants = 
                GetRestaurants(viewmodel.AreaFilterViewModel.SelectedRestaurantId) ;
            viewmodel.AreaFilterViewModel.Floors = 
                GetFloors(viewmodel.AreaFilterViewModel.SelectedRestaurantId,
                viewmodel.AreaFilterViewModel.SelectedFloorId) ;
            viewmodel.Areas = getByFloorId.Execute(viewmodel.AreaFilterViewModel.SelectedFloorId);
            return View(viewmodel);
        }

        /// <summary>
        /// Breadcrumb de la page Add
        /// </summary>
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(AreaUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(AreaUtilsResource.HomePageTitle, Url.Action("Index", "Areas"))
               .AddItem(AreaUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name = "name" ></ param >
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(AreaUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(AreaUtilsResource.HomePageTitle, Url.Action("Index", "Areas"))
               .AddItem(string.Format(AreaUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        private SelectList GetRestaurants(string selectedRestaurant = null)
        {
           return new SelectList(IGetAllRestaurantsQuery.Execute(null, null),
                "Id", "Name", selectedRestaurant);
             
        }
        private SelectList GetFloors(string restId, string selectedFloor = null)        
        {            
            return new SelectList(IGetFloorsByRestaurantIdQuery.Execute (restId),               
               "Id", "Name", selectedFloor);
        }
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
             var model = new AreaViewModel
            {
                 Restaurants = GetRestaurants()            
             };
            return View(model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(AreaViewModel model)
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


                var viewModel = new AreaViewModel
                {
                    Restaurants = GetRestaurants(result.RestaurantId),
                    Floors = GetFloors(result.RestaurantId,result.FloorId),
                    RestaurantId = result.RestaurantId,
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
        public IActionResult Edit(AreaViewModel viewModel)
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
                    model.Args.Add(Url.Action("Delete", "Areas"));
                    model.Args.Add("Area");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, AreaResource.Area);
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
                    deleteCommand.Execute(new DeleteAreaModel { Id = id });
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


        [HttpGet]
        [Route("getFloorsByRestId")]
        public JsonResult GetFloorsByRestId(string parentVal)
        {
            var result = IGetFloorsByRestaurantIdQuery.Execute(parentVal);
           
            var list = new SelectList(result, "Id", "Name");
            return Json(new TitleListModel(list, FloorResource.Floor));
        }

    } 
}