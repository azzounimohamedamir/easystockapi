using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Create;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Delete;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Update;
using SmartRestaurant.Application.Pricings.Tarifications.Queries.GetAll;
using SmartRestaurant.Application.Pricings.Tarifications.Queries.GetById;
using SmartRestaurant.Application.Products.ProductFamilies.Queries.GetByRestaurantId;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Client.Web.Models.Pricings;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Pricings.Tarifications;
using SmartRestaurant.Resources.Utils;

namespace SmartRestaurant.Client.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/Tarifications")]
    [Route("admin/{restaurant}/Tarifications")]
    public class TarificationsController : AdminBaseController
    {
        private readonly ILoggerService<TarificationsController> _log;
        private readonly ICreateTarificationCommand createCommand;
        private readonly IUpdateTarificationCommand updateCommand;
        private readonly IDeleteTarificationCommand deleteCommand;
        private readonly IGetTarificationByIdQuery getById;
        private readonly IGetAllRestaurantsQuery getAllRestaurants;
        private readonly IGetTarificationsByRestaurantIdQuery getByRestaurantId;
        private readonly IGetProductFamiliesByRestaurantIdQuery getProductFamiliesByRestaurantId;

        public TarificationsController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<TarificationsController> log,
            ICreateTarificationCommand createCommand,
            IUpdateTarificationCommand updateCommand,
            IDeleteTarificationCommand deleteCommand,
            IGetTarificationByIdQuery getById,
            IGetAllRestaurantsQuery getGetAllRestaurants,
            IGetTarificationsByRestaurantIdQuery getAll,
            IGetProductFamiliesByRestaurantIdQuery getProductFamiliesByRestaurantId
            )
            : base(configuration, mailing, notify, baselog)
        {
            _log = log;
            this.createCommand = createCommand;
            this.updateCommand = updateCommand;
            this.deleteCommand = deleteCommand;
            this.getById = getById;
            this.getAllRestaurants = getGetAllRestaurants;
            this.getProductFamiliesByRestaurantId = getProductFamiliesByRestaurantId;
            this.getByRestaurantId = getAll;
        }


        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index(string restaurant)
        {
            this.PageBreadcrumb.SetTitle(TarificationUtilsResource.HomePageTitle)
                .AddHome()
                .AddOptionalItem(restaurant,Url.Action("Index","Restaurants",new { area="Admin"}))
                .AddItem(TarificationUtilsResource.HomeNavigationTitle, Url.Action("Tarifications", "Index"))
                .Save();
            var viewModel = new TarificationItemViewModel
            {
                Restaurants = GetRestaurants()
            };
            return View(viewModel);
        }

        [HttpPost]
        [Route("index")]
        public IActionResult Index(TarificationItemViewModel viewModel)
        {
            this.PageBreadcrumb.SetTitle(TarificationUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(TarificationUtilsResource.HomeNavigationTitle, Url.Action("Tarifications", "Index"))
                .Save();

            viewModel.Restaurants = GetRestaurants(viewModel.SelectedRestaurant);
            viewModel.Tarifications = getByRestaurantId.Execute(viewModel.SelectedRestaurant);
            return View(viewModel);
        }


        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {

            var model = new TarificationViewModel
            {
               Restaurants = GetRestaurants()
            };

            return View(model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(TarificationViewModel model)
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
                var model = new TarificationViewModel
                {
                    UpdateModel = result,
                    Restaurants = GetRestaurants(result.RestaurantId),
                    SelectedProducts= GetSelectedProducts(result.ProductsNames)

                };
                BreadcrumbForEdit(result.Name);
                return View(model);
            }
            catch (NotFoundException)
            {
                return View("NotFound");
            }
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(TarificationViewModel model)
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
                    model.Args.Add(Url.Action("Delete", "Tarifications"));
                    model.Args.Add("Tarification");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, TarificationResource.Tarification);
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
                   deleteCommand.Execute(new DeleteTarificationModel { Id = id });
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

        #region Methods

        /// <summary>
        /// Breadcrumb de la page Add
        /// </summary>
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(TarificationUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(TarificationUtilsResource.HomePageTitle, Url.Action("Index", "Tarifications"))
               .AddItem(TarificationUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name="name"></param>
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(TarificationUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(TarificationUtilsResource.HomePageTitle, Url.Action("Index", "Tarifications"))
               .AddItem(string.Format(TarificationUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }
        private SelectList GetRestaurants(string selected = null)
        {
            return new SelectList(getAllRestaurants.Execute(), "Id", "Name", selected);
        }
        private SelectList GetProductFamilies(string restaurantId, string selected = null)
        {
            return new SelectList(getProductFamiliesByRestaurantId.Execute(restaurantId), "Id", "Name", selected);
        }
        private SelectList GetSelectedProducts(List<IdName> productsNames)
        {
            return new SelectList(productsNames, "Id", "Name");
        }
        #endregion
    }
}
