using Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Commun.Units.Queries;
using SmartRestaurant.Application.Commun.Units.Queries.GetUnitsList;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.FoodCategories.Queries;
using SmartRestaurant.Application.FoodCategories.Services;
using SmartRestaurant.Application.Foods.Commands.Create;
using SmartRestaurant.Application.Foods.Commands.Delete;
using SmartRestaurant.Application.Foods.Commands.Update;
using SmartRestaurant.Application.Foods.Models;
using SmartRestaurant.Application.Foods.Queries;
using SmartRestaurant.Application.Foods.Services;
using SmartRestaurant.Application.Foods.Specifications;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Models.Foods;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Foods.Foods;
using SmartRestaurant.Resources.Utils;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Controllers
{
    // [Area("Admin")]
    [Route("foods")]
    public class FoodsController : AdminBaseController
    {
        private readonly ILoggerService<FoodsCategoriesController> _log;
        private readonly IFoodService _foodService;
        private readonly IFoodCategoryService _foodCategoryService;
        private readonly IGetAllUnitsQuerie _getAllUnitsQuery;
        private readonly IHostingEnvironment _hostingEnvironment;


        public FoodsController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<FoodsCategoriesController> log,
            IFoodService foodService,
            IFoodCategoryService foodCategoryService,
            IGetAllUnitsQuerie getAllUnitsQuery,
            IHostingEnvironment hostingEnvironment
            )
            : base(configuration, mailing, notify, baselog)
        {
            _log = log;
            _foodService = foodService;
            _foodCategoryService = foodCategoryService;
            _getAllUnitsQuery = getAllUnitsQuery;
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index(string categoryId, string name, int? page)
        {
            this.PageBreadcrumb.SetTitle(FoodUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(FoodUtilsResource.HomeNavigationTitle, Url.Action("Index", "Foods"))
                .Save();

            var specification = new FoodSpecification(categoryId, name)
                .ApplyOrderBy(fo => fo.Name)
                .ApplyPagination(page * pageSize ?? 0, pageSize);

            var foods = _foodService.Queries.Filter.Execute(specification, out itemCount);

            var model = new FoodListViewModel
            {
                List = PaginatedList<FoodItemModel>.Create(foods, itemCount, page ?? 1, pageSize),
                Filter = new FoodListFilterViewModel
                {
                    Categories = new SelectList(_foodCategoryService.Queries.List.Execute(null), "Id", "Name", categoryId),
                    FoodCategoryId = categoryId,
                    Name = name,
                }
            };
            return View(model);
        }

        /// <summary>
        /// Breadcrumb de la page Add
        /// </summary>
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(FoodUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(FoodUtilsResource.HomePageTitle, Url.Action("Index", "FoodsCategories"))
               .AddItem(FoodUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name="name"></param>
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(FoodUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(FoodUtilsResource.HomePageTitle, Url.Action("Index", "FoodsCategories"))
               .AddItem(string.Format(FoodUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        private List<FoodCategoryItemModel> _categoriesLevel0;
        private List<FoodCategoryItemModel> GetCategoriesLevel0()
        {
            if (_categoriesLevel0 == null) _categoriesLevel0 = _foodCategoryService.Queries.List.Execute(null);
            return _categoriesLevel0;
        }
        private SelectList PopulateSelectListCategories(string selected = null)
        {
            return new SelectList(GetCategoriesLevel0(), "Id", "Name", selected);
        }
        private SelectListViewModel PopulateCascadingCategories(string target)
        {
            var result = GetCategoriesLevel0();
            return BuildSelectListViewModelForFoodsCategories(new SelectList(result, "Id", "Name"), target);

        }
        private SelectListViewModel PopulateCascadingCategories(string id, string parentId, string target)
        {
            //last level
            var childsSpe = new FoodCategorySpecification
                (
                    fc => fc.Id != id.ToGuid() && fc.ParentId == parentId.ToGuid()
                );
            var childs = _foodCategoryService.Queries.Filter.Execute(childsSpe);
            var last = BuildSelectListViewModelForFoodsCategories(new SelectList(childs, "Id", "Name", parentId), target);

            if (!string.IsNullOrEmpty(parentId))
            {
                return PopulateCategories(last, parentId, target);
            }
            else
            {
                return last;
            }
        }
        private SelectListViewModel PopulateCategories(SelectListViewModel result, string id, string target)
        {
            var _category = _foodCategoryService.Queries.GetById.Execute(id);
            Guid? parentId = null;
            if (!string.IsNullOrEmpty(_category.ParentId))
            {
                parentId = _category.ParentId.ToGuid();
            }
            var brothersSpe = new FoodCategorySpecification
                (
                    fc => fc.ParentId == parentId
                );
            var brothers = _foodCategoryService.Queries.Filter.Execute(brothersSpe);

            var parentModel = BuildSelectListViewModelForFoodsCategories(new SelectList(brothers, "Id", "Name", _category.Id), target);
            parentModel.NestedItems = result;

            if (!string.IsNullOrEmpty(_category.ParentId))
            {
                parentModel = PopulateCategories(parentModel, _category.ParentId, target);
            }
            return parentModel;
        }

        private List<UnitItemModel> _units;
        List<UnitItemModel> GetUnits()
        {
            if (_units == null) _units = _getAllUnitsQuery.Execute();
            return _units;
        }
        private SelectList PopulateUnits(string selectedItem = null)
        {
            return new SelectList(GetUnits(), "Id", "Name", selectedItem);
        }

        //[HttpGet]
        //[Route("addpartialcomposition")]
        //public PartialViewResult AddPartialComposition(int index)
        //{
        //    var composition = new FoodCompositionViewModel
        //    {
        //        Id = null,
        //        Index = index + 1,
        //        Categories = PopulateSelectListCategories(),
        //        Units = PopulateUnits(),

        //    };
        //    return PartialView("_FoodCompositionItemView", composition);
        //}
        //[HttpPost]
        //[Route("deletepartialcompositionitem")]
        //public PartialViewResult DeletePartialCompositionItem(FoodViewModel model)
        //{
        //    if (model.IndexToDelete != null && model.Compositions!=null && model.Compositions.Count>0)
        //    {
        //        int indexToDelete = model.IndexToDelete.Value;
        //        var itemToDelete = model.Compositions.FirstOrDefault(it => it.Index == indexToDelete);
        //        model.Compositions.Remove(itemToDelete);
        //        var index = 0;

        //        foreach (var composition in model.Compositions)
        //        {
        //            composition.Index = index;
        //            index++;
        //        }
        //    }
        //    return PartialView("_FoodCompositionItemsView", model.Compositions);
        //}

        [HttpGet]
        [Route("getfoodsbycategory")]
        public JsonResult GetFoodsByCategory(string categoryId)
        {
            if (string.IsNullOrEmpty(categoryId))
            {
                return Json("");
            }
            var selectList = new SelectList(_foodService.Queries.GetListByCategoryId.Execute(categoryId), "Id", "Name");
            return Json(selectList);
        }


        [HttpGet]
        [Route("getfoodsdetails")]
        public JsonResult GetFoodDetails(string foodId)
        {
            if (string.IsNullOrEmpty(foodId))
            {
                return Json("");
            }
            var result = new FoodJsonDetailsModel();
            var food = _foodService.Queries.GetById.Execute(foodId);
            if (food != null)
            {
                result = new FoodJsonDetailsModel
                {
                    Name = food.FoodModel.Name,
                    UnitId = food.FoodModel.UnitId,
                };
            }
            return Json(result);
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            var model = new FoodViewModel
            {
                Categories = PopulateCascadingCategories("FoodModel_FoodCategoryId"),
                FoodModel = new FoodModel(),
                Nutrition = new NutritionModel(),
                Units = PopulateUnits(),

            };

            return View(model);
        }


        [HttpPost]
        [Route("add")]
        public IActionResult Add(FoodViewModel model)
        {
            try
            {
                CreateFoodModel food = new CreateFoodModel
                {
                    FoodModel = model.FoodModel,
                    Nutrition = model.Nutrition,
                };

                if (model.Picture.IsChanged)
                {
                    food.FoodModel.Picture.Url = model.Picture.Save(_hostingEnvironment, Request, "foods,foods");
                }
                _foodService.Create.Execute(food);
                return RedirectToAction("Index");
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);

            }
            BreadcrumbForAdd();

            //model.Categories = PopulateCategories(string.Empty, model.FoodCategoryId, "CreateModel_FoodCategoryId");
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
                var _food = _foodService.Queries.GetById.Execute(id);
                var model = new FoodViewModel
                {
                    Categories = PopulateCascadingCategories(null, _food.FoodModel.FoodCategoryId, "FoodModel_FoodCategoryId"),
                    FoodModel = new FoodModel
                    {
                        Id = _food.FoodModel.Id,
                        Name = _food.FoodModel.Name,
                        Alias = _food.FoodModel.Alias,
                        Description = _food.FoodModel.Description,
                        FoodCategoryId = _food.FoodModel.FoodCategoryId,
                        IsDisabled = _food.FoodModel.IsDisabled,
                        Picture = _food.FoodModel.Picture
                    },
                    Nutrition = new NutritionModel
                    {
                        Quantity = new QuantityModel
                        {
                            UnitId = _food.Nutrition.Quantity.UnitId,
                            Value = _food.Nutrition.Quantity.Value
                        },
                        GlycemicIndex = _food.Nutrition.GlycemicIndex,
                        Fibre = _food.Nutrition.Fibre,
                        Calorie = _food.Nutrition.Calorie,
                        Protein = _food.Nutrition.Protein,
                        Carbohydrate = _food.Nutrition.Carbohydrate,
                        Lipid = _food.Nutrition.Lipid,
                    },
                    Units = PopulateUnits(_food.Nutrition?.Quantity?.UnitId),
                    Action = "Edit",
                    Picture = new FileViewModel(_food.FoodModel.Picture),
                };
                BreadcrumbForAdd();
                return View(model);
            }
            catch (NotFoundException)
            {
                return View("NotFound");
            }
        }


        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(FoodViewModel model)
        {
            try
            {
                UpdateFoodModel food = new UpdateFoodModel
                {
                    FoodModel = model.FoodModel,
                    Nutrition = model.Nutrition,
                };

                if (model.Picture.IsChanged)
                {
                    food.FoodModel.Picture.Url = model.Picture.Save(_hostingEnvironment, Request, "foods,foods");
                }
                _foodService.Update.Execute(food);
                return RedirectToAction("Index");
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);

            }
            BreadcrumbForEdit(model.FoodModel.Name);
            model.Categories = PopulateCascadingCategories(null, model.FoodModel.FoodCategoryId, "FoodModel_FoodCategoryId");
            model.Units = PopulateUnits(model.Nutrition?.Quantity?.UnitId);
            model.Action = "Edit";
            model.Picture = new FileViewModel(model.FoodModel.Picture);
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
                    var food = _foodService.Queries.GetById.Execute(id);
                    model.Args.Add(food.FoodModel.Id);
                    model.Args.Add(Url.Action("Delete", "Foods"));
                    model.Args.Add("food");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, FoodUtilsResource.TableName);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, food.FoodModel.Name);
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
                    _foodService.Delete.Execute(new DeleteFoodModel { Id = id });
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