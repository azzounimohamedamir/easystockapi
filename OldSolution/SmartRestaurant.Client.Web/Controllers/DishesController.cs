using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using SmartRestaurant.Application.Commun.Units.Queries;
using SmartRestaurant.Application.Commun.Units.Queries.GetUnitsList;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Create;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Models;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Update;
using SmartRestaurant.Application.Dishes.Dishes.Queries;
using SmartRestaurant.Application.Dishes.Dishes.Queries.Models;
using SmartRestaurant.Application.Dishes.Dishes.Specifications;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.GetDishFamilliesBySpecifications;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.GetDishFamilliesList;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.GetDishFamilyById;
using SmartRestaurant.Application.Dishes.DishFamillies.Specifications;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.FoodCategories.Queries;
using SmartRestaurant.Application.FoodCategories.Queries.GetAll;
using SmartRestaurant.Application.Foods.Foods.Queries.GetByCategoryId;
using SmartRestaurant.Application.Foods.Queries.GetAll;
using SmartRestaurant.Application.Foods.Services;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Client.Web.Extensions;
using SmartRestaurant.Client.Web.Models.Dishes;
using SmartRestaurant.Client.Web.Models.Galleries;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Domain.Enumerations;
using SmartRestaurant.Resources.Commun.Gallery;
using SmartRestaurant.Resources.Dishes.Dish;
using SmartRestaurant.Resources.Dishes.DishFamily;
using SmartRestaurant.Resources.Enumerations;

namespace SmartRestaurant.Client.Web.Controllers
{
   // [Area("Admin")]
    [Route("dishes")]
    [Route("{restaurant}/dishes")]
    public class DishesController : AdminBaseController
    {
        private readonly IGetDishFamilyListQuery getDishFamilyListQuery;
        private readonly IGetDishFamilyBySpecificationQuery getDishFamilyBySpecification;
        private readonly IGetDishFamilyByIdQuery getDishFamilyByIdQuery;
        private readonly IGetAllRestaurantsQuery getAllRestaurantsQuery;
        private readonly IGetDishFamilyByRestaurantIdQuery getDishFamilyByRestaurantIdQuery;
        private readonly IGetAllFoodsQuery getAllFoodsQuery;
        private readonly IGetFoodsByCategoryIdQuery getFoodsByCategoryIdQuery;
        private readonly IGetAllFoodCategoriesQuery getAllFoodCategoriesQuery;
        private readonly IGetAllUnitsQuerie getAllUnitsQuery;
        private readonly ICreateDishCommand createDishCommand;
        private readonly IUpdateDishCommand updateDishCommand;
        private readonly IFoodService foodService;
        private readonly IGetBySpecificationQuery getBySpecificationQuery;
        private readonly IGetAllDishQuery getAllDishQuery;
        private readonly IGetByIdQuery getByIdQuery;
        private readonly IHostingEnvironment hostingEnvironment;

        public DishesController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            IGetDishFamilyListQuery getDishFamilyListQuery,
            IGetDishFamilyBySpecificationQuery getDishFamilyBySpecification,
            IGetDishFamilyByIdQuery getDishFamilyByIdQuery,
            IGetAllRestaurantsQuery getAllRestaurantsQuery,
            IGetDishFamilyByRestaurantIdQuery getDishFamilyByRestaurantIdQuery,
            IGetAllFoodsQuery getAllFoodsQuery,
            IGetFoodsByCategoryIdQuery getFoodsByCategoryIdQuery,
            IGetAllFoodCategoriesQuery getAllFoodCategoriesQuery,
            IGetAllUnitsQuerie getAllUnitsQuery,
            ICreateDishCommand createDishCommand,
            IUpdateDishCommand updateDishCommand,
            IFoodService foodService,
            IGetBySpecificationQuery getBySpecificationQuery,
            IGetAllDishQuery getAllDishQuery,
            IGetByIdQuery getByIdQuery,            
            IHostingEnvironment hostingEnvironment)
            : base(configuration, mailing, notify, baselog)
        {
            this.getDishFamilyListQuery = getDishFamilyListQuery;
            this.getDishFamilyBySpecification = getDishFamilyBySpecification;
            this.getDishFamilyByIdQuery = getDishFamilyByIdQuery;
            this.getAllRestaurantsQuery = getAllRestaurantsQuery;
            this.getDishFamilyByRestaurantIdQuery = getDishFamilyByRestaurantIdQuery;
            this.getAllFoodsQuery = getAllFoodsQuery;
            this.getFoodsByCategoryIdQuery = getFoodsByCategoryIdQuery ?? throw new ArgumentNullException(nameof(getFoodsByCategoryIdQuery));
            this.getAllFoodCategoriesQuery = getAllFoodCategoriesQuery;
            this.getAllUnitsQuery = getAllUnitsQuery;
            this.createDishCommand = createDishCommand ?? throw new ArgumentNullException(nameof(createDishCommand));
            this.updateDishCommand = updateDishCommand ?? throw new ArgumentNullException(nameof(updateDishCommand));
            this.foodService = foodService ?? throw new ArgumentNullException(nameof(foodService));
            this.getBySpecificationQuery = getBySpecificationQuery ?? throw new ArgumentNullException(nameof(getBySpecificationQuery));
            this.getAllDishQuery = getAllDishQuery ?? throw new ArgumentNullException(nameof(getAllDishQuery));
            this.getByIdQuery = getByIdQuery ?? throw new ArgumentNullException(nameof(getByIdQuery));
            this.hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
        }

        /// <summary>
        /// Breadcrumb de la page Add
        /// </summary>
        private void BreadcrumbForAdd(string restaurant)
        {
            this.PageBreadcrumb
               .AddHome()
               .AddOptionalItem(restaurant, Url.Action("Index", "Restaurants", new { area = "admin" }))
               .AddItem(DishUtilsResource.HomeNavigationTitle, Url.Action("Dishes", "Dishes", new { area = "admin" }))
               .AddItem(DishUtilsResource.AddNewNavigationTitle, null)
               .SetTitle(DishUtilsResource.AddPageTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name="name"></param>
        private void BreadcrumbForEdit(string name, string restaurant = null)
        {
            this.PageBreadcrumb
               .AddHome()
               .AddOptionalItem(restaurant, Url.Action("Index", "Restaurants", new { area = "admin" }))
               .AddItem(DishUtilsResource.HomeNavigationTitle, Url.Action("Dishes", "Dishes", new { area = "admin" }))
               .AddItem(string.Format(DishUtilsResource.EditNavigationTitle, name), null)
               .SetTitle(DishUtilsResource.EditPageTitle)
               .Save();
        }

        private SelectList PopulateRestaurants(string restaurantId = null)
        {
            return new SelectList(getAllRestaurantsQuery.Execute(), "Id", "Name", restaurantId);
        }

        private List<DishSelectItemModel> _familliesLevel0;
        protected SelectListViewModel BuildSelectListViewModelForDishFamily(SelectList items, string target = "DishModel_FamillyId")
        {
            return new SelectListViewModel
            {
                ActionUrl = Url.Action("LoadFamillyChilds", "Dishes"),
                TargetId = target,
                EmptyOptionText = DishFamilyResource.ParentId,
                Items = items,
            };
        }

        [Route("LoadFamillyChilds")]
        public IActionResult LoadFamillyChilds(string id)
        {
            var result = BuildSelectListViewModelForDishFamily(new SelectList(getDishFamilyListQuery.Execute(id), "Id", "Name"));
            return PartialView("_CascadingSelectListView", result);
        }

        private SelectListViewModel PopulateDishFamillies(string restaurantId = null)
        {
            if (!string.IsNullOrEmpty(restaurantId))
            {
                var result = getDishFamilyListQuery.Execute(null);
                return BuildSelectListViewModelForDishFamily(new SelectList(result, "Id", "Name"));
            }
            else
            {
                return new SelectListViewModel
                {
                    EmptyOptionText = DishFamilyResource.ParentId,
                };
            }

        }

        private SelectListViewModel PopulateDishFamillies(string restaurantId, string parentId)
        {
            var childsSpe = new DishFamilySpecification
                (
                    fc => fc.RestaurantId.Equals(restaurantId.ToGuid()) & fc.ParentId == parentId.ToGuid()
                );
            var childs = getDishFamilyBySpecification.Execute(childsSpe);
            var last = BuildSelectListViewModelForDishFamily(new SelectList(childs, "Id", "Name", parentId));

            if (!string.IsNullOrEmpty(parentId))
            {
                return PopulateDishFamillies(last, parentId);
            }
            else
            {
                return last;
            }
        }

        private SelectListViewModel PopulateDishFamillies(SelectListViewModel result, string id)
        {
            var _family = getDishFamilyByIdQuery.Execute(id);
            Guid? parentId = null;
            if (!string.IsNullOrEmpty(_family.ParentId))
            {
                parentId = _family.ParentId.ToGuid();
            }
            var brothersSpe = new DishFamilySpecification
                (
                    fc => fc.ParentId == parentId
                );
            var brothers = getDishFamilyBySpecification.Execute(brothersSpe);

            var parentModel = BuildSelectListViewModelForDishFamily(new SelectList(brothers, "Id", "Name", _family.Id));
            parentModel.NestedItems = result;

            if (!string.IsNullOrEmpty(_family.ParentId))
            {
                parentModel = PopulateDishFamillies(parentModel, _family.ParentId);
            }
            return parentModel;
        }

        [HttpGet]
        [Route("LoadPartialDishesFamilliesView")]
        public IActionResult LoadDishesFamilliesView(string restaurantId)
        {
            if (!string.IsNullOrEmpty(restaurantId))
            {
                var result = BuildSelectListViewModelForDishFamily(
                    new SelectList(getDishFamilyByRestaurantIdQuery.Execute(restaurantId), "Id", "Name"), "DishModel_FamillyId");
                return PartialView("_CascadingSelectListView", result);
            }
            else
            {
                return PartialView("_CascadingSelectListView",
                                   new SelectListViewModel
                                   {
                                       EmptyOptionText = DishFamilyResource.ParentId,
                                   });
            }

        }

        private List<FoodCategoryItemModel> _categoriesLevel0;
        private List<FoodCategoryItemModel> GetCategoriesLevel0()
        {
            if (_categoriesLevel0 == null) _categoriesLevel0 = getAllFoodCategoriesQuery.Execute(null);
            return _categoriesLevel0;
        }

        private SelectList PopulateSelectListCategories(string selected = null)
        {
            return new SelectList(GetCategoriesLevel0(), "Id", "Name", selected);
        }

        private SelectList PopulateSelectListAccompainements(string restaurantId,string dishId,EnumDishType type,string selected = null)
        {
            //TODO:implement GetAllAccompainementByRestaurantByDishQuery
            var specification = new DishSpecification(
                d => d.RestaurantId == restaurantId.ToGuid() & 
                d.Id!=dishId.ToGuid() &
                d.Type == type & 
                d.CanBeAccompanying).ApplyOrderBy(d => d.Name);

            var dishes = getBySpecificationQuery.Execute(specification);
            if (dishes != null) dishes.ForEach(di => di.Id = di.Id.ToLower());
            //if (selected != null) selected = selected.ToUpper();            
            return new SelectList(dishes, "Id", "Name", selected);
        }

        private List<UnitItemModel> _units;
        List<UnitItemModel> GetUnits()
        {
            if (_units == null) _units = getAllUnitsQuery.Execute();
            return _units;
        }
        private SelectList PopulateUnits(string selectedItem = null)
        {
            return new SelectList(GetUnits(), "Id", "Name", selectedItem);
        }

        [HttpGet]
        public SelectList PopulateFoodsByCategory(string categoryId, string foodId = null)
        {
            return new SelectList(getFoodsByCategoryIdQuery.Execute(categoryId), "Id", "Name", foodId);
        }

        [HttpGet]
        [Route("addnewingredient")]
        public IActionResult AddNewIngredient(int index)
        {
            var ingredient = new DishIngredientViewModel
            {
                Index = index + 1,
                Text = DishResource.Ingredient,
                Categories = PopulateSelectListCategories(null),
                Units = PopulateUnits(null),
            };
            return PartialView("_DishIngredientUIView", ingredient);
        }

        [HttpPost]
        [Route("deleteingredient")]
        public IActionResult DeleteIngredient(DishViewModel model)
        {
            if (model != null)
            {
                if (model.Ingredients != null)
                {
                    var ingredient = model.Ingredients
                        .FirstOrDefault(i => i.Index == model.IngredientToDeleteIndex);
                    if (ingredient != null)
                    {
                        model.Ingredients.Remove(ingredient);
                    }
                    if (model.Ingredients.Count == 0)
                    {
                        model.Ingredients = new List<DishIngredientViewModel>
                        {
                            new DishIngredientViewModel
                            {
                                Index=0,
                                Text=DishResource.Ingredient,
                                Categories=PopulateSelectListCategories(null),
                                Units=PopulateUnits(null),
                            }
                        };
                    }
                    else
                    {
                        int index = 0;
                        foreach (var ing in model.Ingredients)
                        {
                            ing.Index = index;
                            ing.Text = DishResource.Ingredient;
                            ing.Categories = PopulateSelectListCategories(null);
                            ing.Units = PopulateUnits(null);
                            index++;
                        }
                    }
                }
                else
                {
                    model.Ingredients = new List<DishIngredientViewModel>
                    {
                        new DishIngredientViewModel
                        {
                            Index=0,
                            Text=DishResource.Ingredient,
                            Categories=PopulateSelectListCategories(null),
                            Units=PopulateUnits(null),
                        }
                    };
                }
            }
            return PartialView("_DishIngredientsView", model.Ingredients);
        }

        [HttpGet]
        [Route("addnewaccompaniment")]
        public IActionResult AddNewAccompaniment(int index,string restaurantId, string dishId, EnumDishType type)
        {
            var accompaniment = new DishAccompanimentViewModel
            {
                Index = index + 1,
                Text = DishResource.Accompaniments,
                Accompaniments = PopulateSelectListAccompainements(restaurantId,dishId,type,null),
                Units = PopulateUnits(null),
            };
            return PartialView("_DishAccompainementUIView", accompaniment);
        }

        [HttpPost]
        [Route("deleteaccompaniment")]
        public IActionResult DeleteAccompaniment(DishViewModel model)
        {
            if (model != null)
            {
                if (model.Accompaniments != null)
                {
                    var accompaniment = model.Accompaniments
                        .FirstOrDefault(i => i.Index == model.AccompanyingToDeleteIndex);
                    if (accompaniment != null)
                    {
                        model.Accompaniments.Remove(accompaniment);
                    }
                    if (model.Accompaniments.Count == 0)
                    {
                        model.Accompaniments = new List<DishAccompanimentViewModel>
                        {
                            new DishAccompanimentViewModel
                            {
                                Index=0,
                                Text=DishResource.Accompaniments,
                                Accompaniments = PopulateSelectListAccompainements(model.DishModel.RestaurantId,model.Id,model.DishModel.Type,null),
                                Units=PopulateUnits(null),
                            }
                        };
                    }
                    else
                    {
                        int index = 0;
                        foreach (var acc in model.Accompaniments)
                        {
                            acc.Index = index;
                            acc.Text = DishResource.Accompaniments;
                            acc.Accompaniments = PopulateSelectListAccompainements(model.DishModel.RestaurantId,model.Id, model.DishModel.Type, accompaniment.Accompaniment.AccompanyingId);
                            acc.Units = PopulateUnits(null);
                            index++;
                        }
                    }
                }
                else
                {
                    model.Accompaniments = new List<DishAccompanimentViewModel>
                    {
                         new DishAccompanimentViewModel
                         {
                                Index=0,
                                Text=DishResource.Accompaniments,
                                Accompaniments = PopulateSelectListAccompainements(model.DishModel.RestaurantId,model.Id,model.DishModel.Type,null),
                                Units=PopulateUnits(null),
                         }
                    };
                }
            }
            return PartialView("_DishAccompanimentsView", model.Accompaniments);
        }

        [HttpGet]
        [Route("addnewgalleryimage")]
        public IActionResult AddNewGalleryImage(int index)
        {
            var galleryImage = new GalleryPictureViewModel
            {
                Index = index + 1,
                Text = GalleryUtilsResource.Picture,
                HtmlFieldPrefix = "GalleryViewModel",
            };
            return PartialView("_GalleryPictureUIView", galleryImage);
        }

        [HttpPost]
        [Route("deletegalleryimage")]
        public IActionResult DeleteGalleryImage(DishViewModel model)
        {
            if (model.GalleryViewModel != null)
            {
                var picture = model.GalleryViewModel.Pictures
                    .FirstOrDefault(i => i.Index == model.GalleryPictureToDeleteIndex);
                if (picture != null)
                {
                    model.GalleryViewModel.Pictures.Remove(picture);
                }
                if (model.GalleryViewModel.Pictures.Count == 0)
                {
                    model.GalleryViewModel.Pictures = new List<GalleryPictureViewModel>
                        {
                            new GalleryPictureViewModel
                            {
                                Index=0,
                                Text=GalleryUtilsResource.Picture,
                            }
                        };
                }
                else
                {
                    int index = 0;
                    foreach (var pic in model.GalleryViewModel.Pictures)
                    {
                        pic.Index = index;
                        pic.Text = GalleryUtilsResource.Picture;
                        index++;
                    }
                }
            }
            else
            {
                model.GalleryViewModel = new GalleryViewModel
                {
                    Pictures = new List<GalleryPictureViewModel>
                    {
                        new GalleryPictureViewModel
                        {
                            Index=0,
                            Text=GalleryUtilsResource.Picture,
                            File=new FileViewModel(FileType.Image),
                            Picture=new GalleryPictureModel(),
                        }
                    }
                };
            }
            return PartialView("_GalleryPicturesView", model.GalleryViewModel.Pictures);
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index(DishListFilterViewModel filter, int? page)
        {
            string restaurant = null;
            this.PageBreadcrumb
                .AddHome()
                .AddOptionalItem(restaurant, Url.Action("Index", "Restaurants", new { area = "admin" }))
                .AddItem(DishUtilsResource.Index, Url.Action("Index", "Dishes", new { area = "admin" }))
                .AddItem(DishUtilsResource.HomeNavigationTitle)
                .SetTitle(DishUtilsResource.HomePageTitle)
                .Save();
            var model = new DishListViewModel();
            if (filter.IsDefined)
            {
                var specification = new DishSpecification
                    (
                    d => !string.IsNullOrEmpty(filter.Name) ? d.Name.Contains(filter.Name) : true
                    && !string.IsNullOrEmpty(filter.RestaurantId) ? d.RestaurantId.Equals(filter.RestaurantId.ToGuid()) : true
                    //&& !string.IsNullOrEmpty(filter.FamilyId)?d.FamillyId.Equals(filter.FamilyId.ToGuid()):true
                    && filter.Type != null ? d.Type == filter.Type : true
                    ).ApplyPagination(page * pageSize ?? 0, pageSize);

                var dishes = getBySpecificationQuery.Execute(specification, out itemCount);
                model.List = PaginatedList<DishItemModel>.Create(dishes, itemCount, page ?? 1, pageSize);
            }
            else
            {
                var dishes = getAllDishQuery.Execute(out itemCount, page * pageSize ?? 0, pageSize);
                model.List = PaginatedList<DishItemModel>.Create(dishes, itemCount, page ?? 1, pageSize);
            }
            filter.Restaurants = PopulateRestaurants(filter.RestaurantId);
            filter.Types = EnumHelper<EnumDishType>.ToLocalizedSelectList(nameof(EnumDishTypeResource), AppCulture);
            model.Filter = filter;
            return View(model);
        }


        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd(null);
            var model = new DishViewModel
            {
                Restaurants = PopulateRestaurants(),
                DishModel = new DishModel
                {
                    IsDisabled = false,
                    CanBeAccompanying = false,
                    PreparationTime = new TimeSpan(0, 10, 0),
                    ServiceTime = new TimeSpan(0, 2, 0),
                },
                Accompaniments = new List<DishAccompanimentViewModel>(),
                AccompanyingIndex=-1,

                Ingredients = new List<DishIngredientViewModel>
                {
                    new DishIngredientViewModel
                    {
                        Index = 0,
                        Text = DishResource.Ingredient,
                        Categories = PopulateSelectListCategories(null),
                        Units = PopulateUnits(null),
                    },

                },
                IngredientIndex=0,

                Equivalences = new List<DishEquivalenceModel>(),
                EquivalenceIndex=-1,

                Famillies = PopulateDishFamillies(null),
                DishTypes = EnumHelper<EnumDishType>.ToLocalizedSelectList(nameof(EnumDishTypeResource), AppCulture),
                GalleryViewModel = new GalleryViewModel
                {
                    HtmlFieldPrefix = "GalleryViewModel",
                    Pictures = new List<GalleryPictureViewModel>
                    {
                        new GalleryPictureViewModel
                        {
                            Index=0,
                            Text=GalleryUtilsResource.Picture,
                            File=new FileViewModel(FileType.Image),
                            Picture=new GalleryPictureModel(),
                            HtmlFieldPrefix="GalleryViewModel",
                        }
                    }
                }
            };
            return View(model);
        }

        [HttpPost]
        [Route("add")]
        [ValidateAntiForgeryToken]
        public IActionResult Add(DishViewModel model)
        {
            try
            {
                //Enregistre les modifications de photos
                SaveGallery(model);
                var _dish = new CreateDishModel
                {                    
                    DishModel = model.DishModel,
                    Ingredients = model.Ingredients.Select(i => i.Ingredient).ToList(),
                    Accompaniments=model.Accompaniments?.Select(acc=>acc.Accompaniment).ToList()??null,
                    Gallery = GetGallery(model),
                };

                createDishCommand.Execute(_dish);
                return RedirectToAction("Index");
            }
            catch (NotValidOperation)
            {

            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }
            int index = 0;
            BreadcrumbForAdd(null);
            model.Restaurants = PopulateRestaurants(model.DishModel.RestaurantId);
            if (model.Ingredients != null && model.Ingredients.Count > 0)
            {
                foreach (var ingredient in model.Ingredients)
                {
                    if (!string.IsNullOrEmpty(ingredient.CategoryId)) ingredient.Foods = PopulateFoodsByCategory(ingredient.CategoryId, ingredient.Ingredient.FoodId);
                    ingredient.Index = index;
                    ingredient.Text = DishResource.Ingredient;
                    ingredient.Categories = PopulateSelectListCategories(ingredient.CategoryId);
                    ingredient.Units = PopulateUnits(ingredient.Ingredient.Quantity.UnitId);
                    index++;
                }
            }
            else
            {
                model.Ingredients = new List<DishIngredientViewModel>
                {
                    new DishIngredientViewModel
                    {
                        Index=0,
                        Text=DishResource.Ingredient,
                        Categories=PopulateSelectListCategories(null),
                        Units=PopulateUnits(null),
                    },

                };
            }
            model.Famillies = PopulateDishFamillies(model.DishModel.FamillyId);
            model.DishTypes = EnumHelper<EnumDishType>.ToLocalizedSelectList(nameof(EnumDishTypeResource), AppCulture, model.DishModel.Type.ToString());
            if (model.GalleryViewModel != null)
            {
                index = 0;
                foreach (var galleryImage in model.GalleryViewModel.Pictures)
                {
                    galleryImage.Index = index;
                    galleryImage.Text = GalleryUtilsResource.Picture;
                    galleryImage.HtmlFieldPrefix = "GalleryViewModel";
                    index++;
                }

            }
            else
            {
                index = 0;
                foreach (var galleryImage in model.GalleryViewModel.Pictures)
                {
                    galleryImage.Index = index;
                    galleryImage.Text = GalleryUtilsResource.Picture;
                    galleryImage.HtmlFieldPrefix = "GalleryViewModel";
                    index++;
                }
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
            var dish = getByIdQuery.Execute(id);

            var model = new DishViewModel
            {
                Action="Edit",
                Id=dish.Id.ToString(),
                Restaurants = PopulateRestaurants(),
                DishModel = dish.DishModel,                
                AccompanyingIndex=dish.Accompaniments?.Count()-1??0,

                Equivalences = new List<DishEquivalenceModel>(),
                EquivalenceIndex=dish.Equivalences?.Count() - 1 ?? 0,

                Famillies = PopulateDishFamillies(dish.DishModel.RestaurantId, dish.DishModel.FamillyId),
                DishTypes = EnumHelper<EnumDishType>.ToLocalizedSelectList(nameof(EnumDishTypeResource), AppCulture),
                IngredientIndex=dish.Ingredients?.Count() - 1 ?? 0,

            };
            int index = 0;
            if (dish.Ingredients != null && dish.Ingredients.Count > 0)
            {
                model.Ingredients = new List<DishIngredientViewModel>();
                foreach (var ingredient in dish.Ingredients)
                {
                    model.Ingredients.Add(
                        new DishIngredientViewModel
                        {
                            Index = index,
                            Text = DishResource.Ingredient,
                            CategoryId = ingredient.FoodCategoryParentsIds.First(),
                            Categories = PopulateSelectListCategories(ingredient.FoodCategoryId),
                            Foods = PopulateFoodsByCategory(ingredient.FoodCategoryId, ingredient.FoodId),
                            Units = PopulateUnits(ingredient.FoodUnitId),
                            Ingredient = ingredient,
                        }
                        );
                    index++;
                }
            }
            index = 0;
            if (dish.Accompaniments != null && dish.Accompaniments.Count > 0)
            {
                model.Accompaniments = new List<DishAccompanimentViewModel>();
                foreach (var accompaniment in dish.Accompaniments)
                {
                    model.Accompaniments.Add(
                        new DishAccompanimentViewModel
                        {
                            Index = index,
                            Text = DishResource.Accompaniments,
                            Accompaniments = PopulateSelectListAccompainements(model.DishModel.RestaurantId,model.Id, model.DishModel.Type, accompaniment.AccompanyingId),
                            Units = PopulateUnits(accompaniment.Quantity.UnitId),
                            Accompaniment = accompaniment,
                        }
                        );
                    index++;
                }
            }

            model.GalleryViewModel = new GalleryViewModel
            {
                HtmlFieldPrefix = "GalleryViewModel",
                GalleryModel = dish.Gallery,
                Pictures = new List<GalleryPictureViewModel>(),
            };
            index = 0;

            if (dish.Gallery != null)
            {               
                if (dish.Gallery.Pictures != null && dish.Gallery.Pictures.Count > 0)
                {
                    foreach (var picture in dish.Gallery.Pictures)
                    {
                        model.GalleryViewModel.Pictures.Add
                            (
                            new GalleryPictureViewModel
                            {
                                Index = index,
                                Text = GalleryUtilsResource.Picture,
                                File = new FileViewModel(picture.Id,picture.ImageUrl),
                                Picture = picture,                                
                                HtmlFieldPrefix = "GalleryViewModel",
                            }
                            );
                        index++;
                    }
                }                
            }
            else
            {
                model.GalleryViewModel.Pictures.Add
                        (
                        new GalleryPictureViewModel
                        {
                            Index = 0,
                            Text = GalleryUtilsResource.Picture,
                            File = new FileViewModel(FileType.Image),
                            Picture = new GalleryPictureModel(),
                            HtmlFieldPrefix = "GalleryViewModel",
                        }
                        );
            }



            return View(model);
        }

        [HttpPost]
        [Route("edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DishViewModel model)
        {
            try

            {
                //Enregistre les modifications de photos
                SaveGallery(model);
                var _dish = new UpdateDishModel
                {
                    Id=model.Id,
                    DishModel = model.DishModel,
                    Ingredients = model.Ingredients.Select(i => i.Ingredient).ToList(),
                    Gallery = GetGallery(model),
                };

                updateDishCommand.Execute(_dish);
                return RedirectToAction("Index");
            }
            catch (NotValidOperation)
            {

            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }

            int index = 0;
            BreadcrumbForEdit(model.DishModel.Name);

            model.Restaurants = PopulateRestaurants(model.DishModel.RestaurantId);
            if (model.Ingredients != null && model.Ingredients.Count > 0)
            {
                foreach (var ingredient in model.Ingredients)
                {
                    if (!string.IsNullOrEmpty(ingredient.CategoryId)) ingredient.Foods = PopulateFoodsByCategory(ingredient.CategoryId, ingredient.Ingredient.FoodId);
                    ingredient.Index = index;
                    ingredient.Text = DishResource.Ingredient;
                    ingredient.Categories = PopulateSelectListCategories(ingredient.CategoryId);
                    ingredient.Units = PopulateUnits(ingredient.Ingredient.Quantity.UnitId);
                    index++;
                }
            }
            else
            {
                model.Ingredients = new List<DishIngredientViewModel>
                {
                    new DishIngredientViewModel
                    {
                        Index=0,
                        Text=DishResource.Ingredient,
                        Categories=PopulateSelectListCategories(null),
                        Units=PopulateUnits(null),
                    },

                };
            }
            model.Famillies = PopulateDishFamillies(model.DishModel.FamillyId);
            model.DishTypes = EnumHelper<EnumDishType>.ToLocalizedSelectList(nameof(EnumDishTypeResource), AppCulture, model.DishModel.Type.ToString());
            if (model.GalleryViewModel != null)
            {
                index = 0;
                foreach (var galleryImage in model.GalleryViewModel.Pictures)
                {
                    galleryImage.Index = index;
                    galleryImage.Text = GalleryUtilsResource.Picture;
                    galleryImage.HtmlFieldPrefix = "GalleryViewModel";
                    index++;
                }

            }
            else
            {
                index = 0;
                foreach (var galleryImage in model.GalleryViewModel.Pictures)
                {
                    galleryImage.Index = index;
                    galleryImage.Text = GalleryUtilsResource.Picture;
                    galleryImage.HtmlFieldPrefix = "GalleryViewModel";
                    index++;
                }
            }
            return View(model);
        }


        private GalleryModel GetGallery(DishViewModel model)
        {
            if (model != null && model.GalleryViewModel != null && model.GalleryViewModel.Pictures.Any())
            {
                var gallery = model.GalleryViewModel.GalleryModel;
                gallery.Pictures = model.GalleryViewModel.Pictures.Select(it => it.Picture).ToList();
                return gallery;
            }
            return null;
        }

        private void SaveGallery(DishViewModel model)
        {
            if (model != null && model.GalleryViewModel != null && model.GalleryViewModel.Pictures.Any())
            {
                string path = $"{model.DishModel.RestaurantId},dishes";
                foreach (var galleryPictureViewModel in model.GalleryViewModel.Pictures)
                {
                    if (galleryPictureViewModel.File.IsChanged)
                    {
                        galleryPictureViewModel.Picture.ImageUrl = galleryPictureViewModel.File.Save(hostingEnvironment, Request, path);
                    }                    
                }
            }
        }
    }
}