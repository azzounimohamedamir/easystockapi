using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Create;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Delete;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Update;
using SmartRestaurant.Application.Products.ProductFamilies.Queries.GetById;
using SmartRestaurant.Application.Products.ProductFamilies.Queries.GetByRestaurantId;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Client.Web.Models.Products;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Products.ProductFamilies;
using SmartRestaurant.Resources.Products.Products;
using SmartRestaurant.Resources.Utils;

namespace SmartRestaurant.Client.Web.Controllers
{
   // [Area("Admin")]
    [Route("ProductFamilies")]
    public class ProductFamiliesController : AdminBaseController
    {
        private readonly ILoggerService<ProductFamiliesController> _log;
        private readonly ICreateProductFamilyCommand createCommand;
        private readonly IUpdateProductFamilyCommand updateCommand;
        private readonly IDeleteProductFamilyCommand deleteCommand;

        private readonly IGetProductFamilyByIdQuery getById;
        private readonly IGetProductFamiliesByRestaurantIdQuery getByRestaurantId;
        private readonly IGetAllRestaurantsQuery getAllRestaurants;
 


        public ProductFamiliesController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<ProductFamiliesController> log,
          ICreateProductFamilyCommand createCommand,
          IUpdateProductFamilyCommand updateCommand,
          IDeleteProductFamilyCommand deleteCommand,

          IGetProductFamilyByIdQuery getById,
          IGetProductFamiliesByRestaurantIdQuery getByRestaurantId,
          IGetAllRestaurantsQuery getAllRestaurants
            //IHostingEnvironment hostingEnvironnement
            )
            : base(configuration, mailing, notify, baselog)
        {
            _log = log;

            this.createCommand = createCommand;
            this.updateCommand = updateCommand;
            this.deleteCommand = deleteCommand;

            this.getById = getById;
            this.getByRestaurantId = getByRestaurantId;
            this.getAllRestaurants = getAllRestaurants;
        }

        #region Index
        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(ProductUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(ProductUtilsResource.HomeNavigationTitle, Url.Action("ProductFamilies", "Index"))
                .Save();

            var result = new ProductFamilyItemViewModel
            {
                Rerstaurants = GetParent()
            };
            return View(result);
        }

        [HttpPost]
        [Route("index")]
        public IActionResult Index(ProductFamilyItemViewModel viewModel)
        {
            this.PageBreadcrumb.SetTitle(ProductUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(ProductUtilsResource.HomeNavigationTitle, Url.Action("ProductFamilies", "Index"))
                .Save();

            viewModel.Entities = getByRestaurantId
                .Execute(viewModel.SelectedRestaurantId);
            viewModel.Rerstaurants = GetParent(viewModel.SelectedRestaurantId);
            return View(viewModel);
        }
        #endregion

        #region Add
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {

            var model = new  ProductFamilyViewModel
            {
                CreateModel = new CreateProductFamilyModel(),
                Parents = GetParent()
            };
            return View(model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(ProductFamilyViewModel model)
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

                var viewModel = new ProductFamilyViewModel
                {
                    UpdateModel = result,
                    Parents = GetParent(result.RestaurantId)
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
        public IActionResult Edit(ProductFamilyViewModel model)
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
            this.PageBreadcrumb.SetTitle(ProductUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(ProductUtilsResource.HomePageTitle, Url.Action("Index", "ProductFamilies"))
               .AddItem(ProductUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name="name"></param>
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(ProductUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(ProductUtilsResource.HomePageTitle, Url.Action("Index", "ProductFamilies"))
               .AddItem(string.Format(ProductUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        private SelectList GetParent( object selected = null)
        {
            return new SelectList(getAllRestaurants.Execute(), "Id", "Name", selected);
        }
        #endregion

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
                    model.Args.Add(Url.Action("Delete", "ProductFamilies"));
                    model.Args.Add("ProductFamily");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, ProductFamilyResource.ProductFamily);
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
                   deleteCommand.Execute(new DeleteProductFamilyModel { Id = id });
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