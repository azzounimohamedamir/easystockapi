using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrenciesList;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Products.ProductFamilies.Queries.GetByRestaurantId;
using SmartRestaurant.Application.Products.Products.Commands.Create;
using SmartRestaurant.Application.Products.Products.Commands.Delete;
using SmartRestaurant.Application.Products.Products.Commands.Update;
using SmartRestaurant.Application.Products.Products.Queries.GetByFamilyId;
using SmartRestaurant.Application.Products.Products.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Client.Web.Models;
using SmartRestaurant.Client.Web.Models.Products;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Products.ProductFamilies;
using SmartRestaurant.Resources.Products.Products;
using SmartRestaurant.Resources.Utils;

namespace SmartRestaurant.Client.Web.Controllers
{
   // [Area("Admin")]
    [Route("Products")]
    public class ProductsController : AdminBaseController
    {
        private readonly ILoggerService<ProductsController> _log;
        private readonly ICreateProductCommand createCommand;
        private readonly IUpdateProductCommand updateCommand;
        private readonly IDeleteProductCommand deleteCommand;

        private readonly IGetProductByIdQuery getById;
        private readonly IGetProductByProductFamilyIdQuery getByFamilyId;
        private readonly IGetAllRestaurantsQuery getAllRestaurants;
        private readonly IGetAllCurrenciesQuery getAllCurrencies;
        private readonly IHostingEnvironment hostingEnvironnement;
        private readonly IGetProductFamiliesByRestaurantIdQuery getproductfamiliesByRestaurantId;
 


        public ProductsController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<ProductsController> log,
          ICreateProductCommand createCommand,
          IUpdateProductCommand updateCommand,
          IDeleteProductCommand deleteCommand,
          IGetAllCurrenciesQuery getAllCurrencies,
          IGetProductByIdQuery getById,
          IGetAllRestaurantsQuery getAllRestaurants,
          IGetProductByProductFamilyIdQuery GetByFamilyId,
          IGetProductFamiliesByRestaurantIdQuery getproductfamiliesByRestaurantId,
            IHostingEnvironment hostingEnvironnement)
            
            : base(configuration, mailing, notify, baselog)
        {
            _log = log;

            this.createCommand = createCommand;
            this.updateCommand = updateCommand;
            this.deleteCommand = deleteCommand;
            this.getAllRestaurants = getAllRestaurants;
            this.hostingEnvironnement = hostingEnvironnement;
            this.getAllCurrencies = getAllCurrencies;

            this.getById = getById;
            this.getByFamilyId = GetByFamilyId;
            this.getproductfamiliesByRestaurantId = getproductfamiliesByRestaurantId;
        }

        #region Index
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(ProductUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(ProductUtilsResource.HomeNavigationTitle, Url.Action("ProductFamilies", "Index"))
                .Save();

            var result = new ProductItemViewModel
            {
                Restaurants = GetRestaurants()
            };
            return View(result);
        }

        [HttpPost]
        [Route("index")]
        public IActionResult Index(ProductItemViewModel viewModel)
        {
            this.PageBreadcrumb.SetTitle(ProductUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(ProductUtilsResource.HomeNavigationTitle, Url.Action("ProductFamilies", "Index"))
                .Save();

            viewModel.Entities = getByFamilyId
                .Execute(viewModel.SelectedFamilyId);
            viewModel.Restaurants = GetRestaurants(viewModel.SelectedRestaurantId);
            return View(viewModel);
        }
        #endregion

        #region Add
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {

            var model = new ProductViewModel
            {
                CreateModel = new CreateProductModel(),
                Restaurants = GetRestaurants(),
                Currencies = GetCurrencies()
            };
            return View(model);
        }

       

        [HttpPost]
        [Route("add")]
        public IActionResult Add(ProductViewModel model)
        {
            BreadcrumbForAdd();
            try
            {
                if (model.Picture.IsChanged)
                {
                    model.CreateModel.PictureUrl = model.Picture.Save(hostingEnvironnement, Request, "foods,categories");
                }
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
                var result =  getById.Execute(id);
                BreadcrumbForEdit(result.Name);

                var viewModel = new ProductViewModel
                {
                    UpdateModel = result,
                    Restaurants = GetRestaurants(result.ResturantId),
                    Currencies = GetCurrencies(),
                    ProductFamilies = GetProductFamilies(result.ResturantId, result.ProductFamilyId)
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
        public IActionResult Edit(ProductViewModel model)
        {
            BreadcrumbForEdit(model.UpdateModel.Name);
            try
            {
                if (model.Picture.IsChanged)
                {
                    model.UpdateModel.PictureUrl = model.Picture.Save(hostingEnvironnement, Request, "foods,categories");
                }
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
               .AddItem(ProductUtilsResource.HomePageTitle, Url.Action("Index", "Products"))
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
               .AddItem(ProductUtilsResource.HomePageTitle, Url.Action("Index", "Products"))
               .AddItem(string.Format(ProductUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }
        private SelectList GetRestaurants(object selected = null)
        {
            return new SelectList(getAllRestaurants.Execute(), "Id", "Name", selected);
        }
        private SelectList GetCurrencies(object selected = null)
        {
            return new SelectList(getAllCurrencies.Execute(), "Id", "Name", selected);
        }

        private SelectList GetProductFamilies(string resturantId, string productFamilyId)
        {
            return new SelectList(getproductfamiliesByRestaurantId.Execute(resturantId), "Id", "Name", productFamilyId);
        }
        [HttpGet]
        [Route("getProductFamiliesByRestId")]
        public JsonResult GetFloorsByRestId(string parentVal)
        {            
            var result = getproductfamiliesByRestaurantId.Execute(parentVal);

            var list = new SelectList(result, "Id", "Name");
            return Json(new TitleListModel(list, ProductFamilyResource.ProductFamily));
        }
        [HttpGet]
        [Route("getProductsByFamiliesId")]
        public JsonResult GetProductsByFamiliesId(string parentVal)
        {
            var result = getByFamilyId.Execute(parentVal);

            var list = new SelectList(result, "Id", "Name");
            return Json(new TitleListModel(list, null));
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
                    model.Args.Add(Url.Action("Delete", "Products"));
                    model.Args.Add("Product");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, ProductResource.Product);
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
                    deleteCommand.Execute(new DeleteProductModel { Id = id });
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