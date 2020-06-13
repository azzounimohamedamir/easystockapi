using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Create;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Delete;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Update;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Services;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Restaurants.RestaurantTypes;
using SmartRestaurant.Resources.Utils;

namespace SmartRestaurant.Client.Web.Controllers
{
   // [Area("Admin")]
    [Route("restaurants/types")]
    public class RestaurantsTypesController : AdminBaseController
    {
        private readonly ILoggerService<RestaurantsTypesController> _log;
        private readonly IRestaurantTypeService RestaurantTypeService;

        public RestaurantsTypesController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<RestaurantsTypesController> log,
            IRestaurantTypeService service
            //IHostingEnvironment hostingEnvironnement
            )
            : base(configuration, mailing, notify, baselog)
        {
            _log = log;
            this.RestaurantTypeService = service;
            //_hostingEnvironnement = hostingEnvironnement;
        }

        [Route("")]
        [Route("index")]        
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(RestaurantTypeUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(RestaurantTypeUtilsResource.HomeNavigationTitle, Url.Action("RestaurantTypes", "Index"))
                .Save();
 
            return View(RestaurantTypeService.Queries.List.Execute());
        }

        /// <summary>
        /// Breadcrumb de la page Add
        /// </summary>
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(RestaurantTypeUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(RestaurantTypeUtilsResource.HomePageTitle, Url.Action("Index", "RestaurantTypes"))
               .AddItem(RestaurantTypeUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name="name"></param>
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(RestaurantTypeUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(RestaurantTypeUtilsResource.HomePageTitle, Url.Action("Index", "RestaurantTypes"))
               .AddItem(string.Format(RestaurantTypeUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {

            var model = new CreateRestaurantTypeModel();
            return View(model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(CreateRestaurantTypeModel model)
        {
            BreadcrumbForAdd();
            try
            {
                RestaurantTypeService.Create.Execute(model);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }
            return RedirectToAction("index");
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
                var result = RestaurantTypeService.Queries.GetById.Execute(id);
                BreadcrumbForEdit(result.Name);
                return View(result);
            }
            catch (NotFoundException)
            {
                return View("NotFound");
            }
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(UpdateRestaurantTypeModel model)
        {
            BreadcrumbForEdit(model.Name);
            try
            {
                RestaurantTypeService.Update.Execute(model);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }

            return View(model);
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
                    var entity = RestaurantTypeService.Queries.GetById.Execute(id);
                    model.Args.Add(entity.Id);
                    model.Args.Add(Url.Action("Delete", "RestaurantTypes"));
                    model.Args.Add("RestaurantType");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, RestaurantTypeResource.RestaurantType);
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
                    RestaurantTypeService.Delete.Execute(new DeleteRestaurantTypeModel { Id = id });
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