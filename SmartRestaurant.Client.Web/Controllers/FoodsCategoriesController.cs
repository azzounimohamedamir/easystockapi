using Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.FoodCategories.Commands;
using SmartRestaurant.Application.FoodCategories.Commands.Delete;
using SmartRestaurant.Application.FoodCategories.Services;
using SmartRestaurant.Application.Foods.Specifications;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Models.Foods;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Foods.FoodCategories;
using SmartRestaurant.Resources.Utils;
using System;
using System.Linq;

namespace SmartRestaurant.Client.Web.Controllers
{
    // [Area("Admin")]
    [Route("foods/categories")]
    public class FoodsCategoriesController : AdminBaseController
    {
        private readonly ILoggerService<FoodsCategoriesController> _log;
        private readonly IFoodCategoryService _categoryService;
        private readonly IHostingEnvironment _hostingEnvironment;


        public FoodsCategoriesController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<FoodsCategoriesController> log,
            IFoodCategoryService categoryService,
            IHostingEnvironment hostingEnvironment
            )
            : base(configuration, mailing, notify, baselog)
        {
            _log = log;
            _categoryService = categoryService;
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(FoodCategoryUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(FoodCategoryUtilsResource.HomeNavigationTitle, Url.Action("FoodsCategories", "Index"))
                .Save();

            return View(_categoryService.Queries.List.Execute(null));
        }

        [Route("LoadChilds")]
        public IActionResult LoadChilds(string parentId)
        {
            // System.Threading.Thread.Sleep(5000);
            var result = _categoryService.Queries.List.Execute(parentId);

            return PartialView("_FoodsCategoriesView", result);
        }

        [Route("LoadItemChilds")]
        public IActionResult LoadItemChilds(string id)
        {
            var result = BuildSelectListViewModelForFoodsCategories(new SelectList(_categoryService.Queries.List.Execute(id), "Id", "Name"));
            return PartialView("_CascadingSelectListView", result);
        }
        /// <summary>
        /// Breadcrumb de la page Add
        /// </summary>
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(FoodCategoryUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(FoodCategoryUtilsResource.HomePageTitle, Url.Action("Index", "FoodsCategories"))
               .AddItem(FoodCategoryUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name="name"></param>
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(FoodCategoryUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(FoodCategoryUtilsResource.HomePageTitle, Url.Action("Index", "FoodsCategories"))
               .AddItem(string.Format(FoodCategoryUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        private SelectListViewModel PopulateCategories()
        {
            var result = _categoryService.Queries.List.Execute(null);
            return BuildSelectListViewModelForFoodsCategories(new SelectList(result, "Id", "Name"));

        }
        private SelectListViewModel PopulateCategories(string id, string parentId)
        {
            var childsSpe = new FoodCategorySpecification
                (
                    fc => fc.Id != id.ToGuid() && fc.ParentId == parentId.ToGuid() && !fc.Foods.Any()
                );
            var childs = _categoryService.Queries.Filter.Execute(childsSpe);
            var last = BuildSelectListViewModelForFoodsCategories(new SelectList(childs, "Id", "Name", parentId));

            if (!string.IsNullOrEmpty(parentId))
            {
                return PopulateCategories(last, parentId);
            }
            else
            {
                return last;
            }
        }
        private SelectListViewModel PopulateCategories(SelectListViewModel result, string id)
        {
            var _category = _categoryService.Queries.GetById.Execute(id);
            Guid? parentId = null;
            if (!string.IsNullOrEmpty(_category.ParentId))
            {
                parentId = _category.ParentId.ToGuid();
            }
            var brothersSpe = new FoodCategorySpecification
                (
                    fc => fc.ParentId == parentId && !fc.Foods.Any()
                );
            var brothers = _categoryService.Queries.Filter.Execute(brothersSpe);

            var parentModel = BuildSelectListViewModelForFoodsCategories(new SelectList(brothers, "Id", "Name", _category.Id));
            parentModel.NestedItems = result;

            if (!string.IsNullOrEmpty(_category.ParentId))
            {
                parentModel = PopulateCategories(parentModel, _category.ParentId);
            }
            return parentModel;
        }


        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            var model = new FoodCategoryViewModel
            {
                Parents = PopulateCategories(),
                CreateModel = new CreateFoodCategoryModel()
            };
            return View(model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(FoodCategoryViewModel model)
        {

            try
            {
                var _category = model.CreateModel;
                _category.ParentId = model.ParentId;
                if (model.Picture.IsChanged)
                {
                    _category.PictureUrl = model.Picture.Save(_hostingEnvironment, Request, "foods,categories");
                }
                _categoryService.Create.Execute(_category);
                return RedirectToAction("Index");
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);

            }
            BreadcrumbForAdd();
            model.Parents = PopulateCategories(string.Empty, model.ParentId);// PopulateCategories(null, model.CreateModel.ParentId);
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
                var _category = _categoryService.Queries.GetById.Execute(id);

                var model = new FoodCategoryViewModel
                {
                    UpdateModel = _category,
                    ParentId = _category.ParentId,
                    Parents = PopulateCategories(_category.Id, _category.ParentId),
                    Picture = new FileViewModel(_category.PictureId, _category.PictureUrl),
                };

                BreadcrumbForEdit(_category.Name);

                return View(model);
            }
            catch (NotFoundException)
            {
                return View("NotFound");
            }

        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(FoodCategoryViewModel model)
        {

            try
            {
                var _category = model.UpdateModel;
                _category.ParentId = model.ParentId;
                if (model.Picture.IsChanged)
                {
                    _category.PictureUrl = model.Picture.Save(_hostingEnvironment, Request, "foods,categories");
                }
                _categoryService.Update.Execute(model.UpdateModel);
                return RedirectToAction("Index");
            }

            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);

            }
            BreadcrumbForEdit(model.UpdateModel.Name);
            model.Parents = PopulateCategories(model.UpdateModel.Id, model.UpdateModel.ParentId);
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
                    var category = _categoryService.Queries.GetById.Execute(id);
                    model.Args.Add(category.Id);
                    model.Args.Add(Url.Action("Delete", "FoodsCategories"));
                    model.Args.Add("food-category");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, FoodCategoryUtilsResource.TableName);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, category.Name);
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
                    _categoryService.Delete.Execute(new DeleteFoodCatergoryModel { Id = id });
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