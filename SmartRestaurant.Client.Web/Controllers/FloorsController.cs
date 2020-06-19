using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Floors.Commands.Create;
using SmartRestaurant.Application.Restaurants.Floors.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Floors.Commands.Update;
using SmartRestaurant.Application.Restaurants.Floors.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Floors.Queries.GetByRestaurantId;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Client.Web.Models.Restaurants;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Restaurants.Floors;
using SmartRestaurant.Resources.Utils;
using System;

namespace SmartRestaurant.Client.Web.Controllers
{
    // [Area("Admin")]
    [Route("Floors")]
    public class FloorsController : AdminBaseController
    {

        private readonly ILoggerService<FloorsController> _log;
        private readonly ICreateFloorCommand createCommand;
        private readonly IUpdateFloorCommand updateCommand;
        private readonly IDeleteFloorCommand deleteCommand;
        private readonly IGetFloorByIdQuery getById;
        private readonly IGetFloorsByRestaurantIdQuery getByRestaurantId;
        private readonly IHostingEnvironment _hostingEnvironnement;
        private readonly IGetAllRestaurantsQuery IGetAllRestaurantsQuery;

        public FloorsController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<FloorsController> log,
            ICreateFloorCommand createCommand,
            IUpdateFloorCommand updateCommand,
            IDeleteFloorCommand deleteCommand,
            IGetFloorByIdQuery getById,
             IGetFloorsByRestaurantIdQuery getByRestaurantId,
            IHostingEnvironment hostingEnvironnement,
            IGetAllRestaurantsQuery IGetAllRestaurantsQuery

            )
            : base(configuration, mailing, notify, baselog)
        {
            this.IGetAllRestaurantsQuery = IGetAllRestaurantsQuery;
            _log = log;
            this.createCommand = createCommand;
            this.updateCommand = updateCommand;
            this.deleteCommand = deleteCommand;
            this.getById = getById;
            this.getByRestaurantId = getByRestaurantId;


            _hostingEnvironnement = hostingEnvironnement;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(FloorUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(FloorUtilsResource.HomeNavigationTitle, Url.Action("Floors", "Index"))
                .Save();

            var viewModel = new FloorItemViewModel
            {
                FloorFilterViewModel = new FloorFilterViewModel
                {
                    Restaurants = GetRestaurants()
                }
            };
            return View(viewModel);
        }
        [HttpPost]
        [Route("index")]
        public IActionResult Index(FloorItemViewModel viewmodel)
        {
            this.PageBreadcrumb.SetTitle(FloorUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(FloorUtilsResource.HomeNavigationTitle, Url.Action("Floors", "Index"))
                .Save();

            viewmodel.FloorFilterViewModel.Restaurants =
                GetRestaurants(viewmodel.FloorFilterViewModel.SelectedRestaurantId);
            viewmodel.Floors = getByRestaurantId.Execute(viewmodel.FloorFilterViewModel.SelectedRestaurantId);
            return View(viewmodel);
        }

        /// <summary>
        /// Breadcrumb de la page Add
        /// </summary>
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(FloorUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(FloorUtilsResource.HomePageTitle, Url.Action("Index", "Floors"))
               .AddItem(FloorUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name = "name" ></ param >
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(FloorUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(FloorUtilsResource.HomePageTitle, Url.Action("Index", "Floors"))
               .AddItem(string.Format(FloorUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        private SelectList GetRestaurants(string selectedRestaurant = null)
        {
            return new SelectList(IGetAllRestaurantsQuery.Execute(null, null),
                 "Id", "Name", selectedRestaurant);

        }
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            var model = new FloorViewModel
            {
                Restaurants = GetRestaurants()
            };
            return View(model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(FloorViewModel model)
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


                var viewModel = new FloorViewModel
                {
                    Restaurants = GetRestaurants(result.RestaurantId),
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
        public IActionResult Edit(FloorViewModel viewModel)
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
                    model.Args.Add(Url.Action("Delete", "Floors"));
                    model.Args.Add("floor");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, FloorResource.Floor);
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
                    deleteCommand.Execute(new DeleteFloorModel { Id = id });
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