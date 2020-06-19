using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Owners.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Update;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetByChainId;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetById;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries.GetAll;
using SmartRestaurant.Client.Web.Models.Restaurants;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Restaurants.Restaurants;
using SmartRestaurant.Resources.Utils;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Controllers
{
    //[Area("Admin")]
    [Route("Restaurants")]
    public class RestaurantsController : AdminBaseController
    {
        private readonly ILoggerService<RestaurantsController> _log;
        private readonly ICreateRestaurantCommand createCommand;
        private readonly IUpdateRestaurantCommand updateCommand;
        private readonly IDeleteRestaurantCommand deleteCommand;

        private readonly IGetRestaurantByIdQuery getById;
        private readonly IGetRestaurantsByChainIdQuery getByChainId;
        private readonly IGetAllRestaurantTypesQuery getAllRestaurantTypes;
        private readonly IGetAllOwnersQuery getAllOwners;
        private readonly IGetAllRestaurantsQuery getAllRestaurants;



        public RestaurantsController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<RestaurantsController> log,
            ICreateRestaurantCommand createCommand,
            IUpdateRestaurantCommand updateCommand,
            IDeleteRestaurantCommand deleteCommand,
            IGetRestaurantByIdQuery getById,
            IGetRestaurantsByChainIdQuery getByChainId,
              IGetAllRestaurantTypesQuery getAllRestaurantTypes,
              IGetAllOwnersQuery getAllOwners,
              IGetAllRestaurantsQuery getAllRestaurants
            )
            : base(configuration, mailing, notify, baselog)
        {
            _log = log;
            this.createCommand = createCommand;
            this.updateCommand = updateCommand;
            this.deleteCommand = deleteCommand;
            this.getById = getById;
            this.getByChainId = getByChainId;
            this.getAllRestaurantTypes = getAllRestaurantTypes;
            this.getAllOwners = getAllOwners;
            this.getAllRestaurants = getAllRestaurants;
            //_hostingEnvironnement = hostingEnvironnement;
        }

        #region Index
        [HttpGet]
        //[Route("")]
        //[Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(RestaurantUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(RestaurantUtilsResource.HomeNavigationTitle, Url.Action("Index", "Restaurants"))
                .Save();

            var result = new RestaurantItemViewModel
            {
                RestaurantTypes = GetTypes(),
                Owners = GetOwners()
            };
            return View(result);
        }

        [HttpPost]
        //[Route("")]
        //[Route("index")]
        public IActionResult Index(RestaurantItemViewModel viewModel)
        {
            this.PageBreadcrumb.SetTitle(RestaurantUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(RestaurantUtilsResource.HomeNavigationTitle, Url.Action("Index", "Restaurants"))
                .Save();

            viewModel.Entities = getAllRestaurants
                .Execute(viewModel.SelectedRestaurantTypeId, viewModel.SelectedOwnerId);

            viewModel.RestaurantTypes = GetTypes(viewModel.SelectedRestaurantTypeId);
            viewModel.Owners = GetOwners(viewModel.SelectedOwnerId);
            return View(viewModel);
        }

        #endregion


        #region Add
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {

            var model = new RestaurantViewModel
            {
                CreateModel = new CreateRestaurantModel(),
                RestaurantTypes = GetTypes(),
                Owners = GetOwners()
            };
            return View(model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(RestaurantViewModel model)
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
            return RedirectToAction("index");
        }
        #endregion

        #region Edit
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

                var viewModel = new RestaurantViewModel
                {
                    UpdateModel = result,
                    RestaurantTypes = GetTypes(result.RestaurantTypeId),
                    Owners = GetOwners(result.OwnerId)
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
        public IActionResult Edit(RestaurantViewModel model)
        {
            BreadcrumbForEdit(model.UpdateModel.Name);
            try
            {
                updateCommand.Execute(model.UpdateModel);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }

            return View(model);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Breadcrumb de la page Add
        /// </summary>
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(RestaurantUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(RestaurantUtilsResource.HomePageTitle, Url.Action("Index", "Restaurants"))
               .AddItem(RestaurantUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name="name"></param>
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(RestaurantUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(RestaurantUtilsResource.HomePageTitle, Url.Action("Index", "Restaurants"))
               .AddItem(string.Format(RestaurantUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        private SelectList GetTypes(object selected = null)
        {
            var result = getAllRestaurantTypes.Execute();
            if (result == null)
                return new SelectList(new List<string>());
            return new SelectList(result, "Id", "Name", selected);
        }
        private SelectList GetOwners(object selected = null)
        {
            var result = getAllOwners.Execute();
            if (result == null)
                return new SelectList(new List<string>());
            return new SelectList(result, "Id", "FullName", selected);
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
                    model.Args.Add(Url.Action("Delete", "Restaurants"));
                    model.Args.Add("Restaurant");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, RestaurantResource.Restaurant);
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
                    deleteCommand.Execute(new DeleteRestaurantModel { Id = id });
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
        #endregion


        public IActionResult Details(string restaurantId)
        {
            return View();
        }
    }
}