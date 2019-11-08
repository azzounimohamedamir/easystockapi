using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Create;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Delete;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Update;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.GetDishFamilliesBySpecifications;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.GetDishFamilliesList;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.GetDishFamilyById;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.Models;
using SmartRestaurant.Application.Dishes.DishFamillies.Specifications;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Client.Web.Models.Dishes;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Dishes.Dish;
using SmartRestaurant.Resources.Dishes.DishFamily;
using SmartRestaurant.Resources.Utils;

namespace SmartRestaurant.Client.Web.Controllers
{
   // [Area("Admin")]
    [Route("dishes/famillies")]
    [Route("{restaurant}/dishes/famillies")]
    public class DishesFamilliesController : AdminBaseController
    {
        private readonly ILoggerService<DishesFamilliesController> log;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ICreateDishFamilyCommand createDishFamilyCommand;
        private readonly IUpdateDishFamilyCommand updateDishFamilyCommand;
        private readonly IDeleteDishFamilyCommand deleteDishFamilyCommand;
        private readonly IGetDishFamilyListQuery getDishFamilyListQuery;
        private readonly IGetDishFamilyBySpecificationQuery getDishFamilyBySpecification;
        private readonly IGetDishFamilyByIdQuery getDishFamilyByIdQuery;
        private readonly IGetAllRestaurantsQuery getAllRestaurantsQuery;
        private readonly IGetDishFamilyByRestaurantIdQuery getDishFamilyByRestaurantIdQuery;

        public DishesFamilliesController(
            IConfiguration configuration, 
            IMailingService mailing, 
            INotifyService notify, 
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<DishesFamilliesController> log,
            IHostingEnvironment hostingEnvironment,
            ICreateDishFamilyCommand createDishFamilyCommand,
            IUpdateDishFamilyCommand updateDishFamilyCommand,
            IDeleteDishFamilyCommand deleteDishFamilyCommand,
            IGetDishFamilyListQuery getDishFamilyListQuery,
            IGetDishFamilyBySpecificationQuery getDishFamilyBySpecification,
            IGetDishFamilyByIdQuery getDishFamilyByIdQuery,
            IGetAllRestaurantsQuery getAllRestaurantsQuery,
            IGetDishFamilyByRestaurantIdQuery getDishFamilyByRestaurantIdQuery) 
            : base(configuration, mailing, notify, baselog)
        {
            this.log = log;
            this.hostingEnvironment = hostingEnvironment;
            this.createDishFamilyCommand = createDishFamilyCommand;
            this.updateDishFamilyCommand = updateDishFamilyCommand;
            this.deleteDishFamilyCommand = deleteDishFamilyCommand;
            this.getDishFamilyListQuery = getDishFamilyListQuery;
            this.getDishFamilyBySpecification = getDishFamilyBySpecification;
            this.getDishFamilyByIdQuery = getDishFamilyByIdQuery;
            this.getAllRestaurantsQuery = getAllRestaurantsQuery;
            this.getDishFamilyByRestaurantIdQuery = getDishFamilyByRestaurantIdQuery;
        }

        [Route("LoadChilds")]
        public IActionResult LoadChilds(string parentId)
        {            
            var result = getDishFamilyListQuery.Execute(parentId);
            return PartialView("_DishesFamilliesView", result);
        }
        private SelectList PopulateParents(string parentId)
        {
            return new SelectList(getDishFamilyListQuery.Execute(null), "Id", "Name", parentId);
        }
        [Route("LoadItemChilds")]
        public IActionResult LoadItemChilds(string id)
        {
            var result = BuildSelectListViewModelForDishFamily(new SelectList(getDishFamilyListQuery.Execute(id), "Id", "Name"));
            return PartialView("_CascadingSelectListView", result);
        }


        [Route("")]
        [Route("Index")]
        public IActionResult Index(DishFamilyFilterViewModel filter,string restaurant =null)
        {
            this.PageBreadcrumb
                .AddHome()
                .AddOptionalItem(restaurant,Url.Action("Index","Restaurants", new { area = "admin" }))
                .AddItem(DishUtilsResource.Index,Url.Action("Index","Dishes",new { area = "admin" }))
                .AddItem(DishUtilsResource.HomeNavigationTitle, Url.Action("Dishes", "Dishes", new { area = "admin" }))
                .AddItem(DishUtilsResource.HomeNavigationTitle)
                .AddItem(DishFamilyUtilsResource.HomeNavigationTitle)
                .SetTitle(DishFamilyUtilsResource.HomePageTitle)
                .Save();
            IEnumerable<DishFamilyItemModel> list;
            if (filter.HasValue)
            {
                var specification = new DishFamilySpecification
                    (
                    df =>df.ParentId==null
                    && (!string.IsNullOrEmpty(filter.Name)?(df.Name.Contains(filter.Name) || df.Childs.Any(ch=>ch.Name.Contains(filter.Name))):true) 
                    && ((!string.IsNullOrEmpty(filter.RestaurantId)?df.RestaurantId==filter.RestaurantId.ToGuid():true))
                    && ((!string.IsNullOrEmpty(filter.ParentId) ? df.ParentId==filter.ParentId.ToGuid() || df.Childs.Any(ch=>ch.ParentId==filter.ParentId.ToGuid()) : true))
                    );
                list = getDishFamilyBySpecification.Execute(specification);
            }
            else
            {
                list = getDishFamilyListQuery.Execute(null);
            }
            var model = new FamilliesViewModel
            {
                Filter=new DishFamilyFilterViewModel
                {
                    Name=filter.Name,
                    ParentId=filter.ParentId,
                    RestaurantId=filter.RestaurantId,                    
                    Parents= PopulateParents(filter.ParentId),
                    Restaurants=PopulateRestaurants(filter.RestaurantId),
                },
                List = list,
            };
            return View(model);
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
               .AddItem(DishFamilyUtilsResource.HomeNavigationTitle, Url.Action("Famillies", "DishesFamillies", new { area = "admin" }))
               .AddItem(DishFamilyUtilsResource.AddNewNavigationTitle)
               .SetTitle(DishFamilyUtilsResource.AddPageTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name="name"></param>
        private void BreadcrumbForEdit(string name,string restaurant=null)
        {
            this.PageBreadcrumb
               .AddHome()
               .AddOptionalItem(restaurant, Url.Action("Index", "Restaurants", new { area = "admin" }))               
               .AddItem(DishUtilsResource.HomeNavigationTitle, Url.Action("Dishes", "Dishes", new { area = "admin" }))
               .AddItem(DishFamilyUtilsResource.HomeNavigationTitle, Url.Action("Famillies", "DishesFamillies", new { area = "admin" }))
               .AddItem(string.Format(DishFamilyUtilsResource.EditNavigationTitle, name), null)
               .SetTitle(DishFamilyUtilsResource.EditPageTitle)
               .Save();
        }

        protected SelectListViewModel BuildSelectListViewModelForDishFamily(SelectList items, string target = "ParentId")
        {
            return new SelectListViewModel
            {
                ActionUrl = Url.Action("LoadItemChilds", "DishesFamillies"),
                TargetId = target,
                EmptyOptionText = DishFamilyResource.ParentId,
                Items = items,
            };
        }

        private SelectListViewModel PopulateParents()
        {
            var result = getDishFamilyListQuery.Execute(null);
            return BuildSelectListViewModelForDishFamily(new SelectList(result, "Id", "Name"));
        }
        private SelectListViewModel PopulateParents(string id, string parentId)
        {
            var childsSpe = new DishFamilySpecification
                (
                    fc => fc.Id != id.ToGuid() && fc.ParentId == parentId.ToGuid() && !fc.Dishes.Any()
                );
            var childs = getDishFamilyBySpecification.Execute(childsSpe);
            var last = BuildSelectListViewModelForDishFamily(new SelectList(childs, "Id", "Name", parentId));

            if (!string.IsNullOrEmpty(parentId))
            {
                return PopulateParents(last, parentId);
            }
            else
            {
                return last;
            }
        }
        private SelectListViewModel PopulateParents(SelectListViewModel result, string id)
        {
            var _family = getDishFamilyByIdQuery.Execute(id);
            Guid? parentId = null;
            if (!string.IsNullOrEmpty(_family.ParentId))
            {
                parentId = _family.ParentId.ToGuid();
            }
            var brothersSpe = new DishFamilySpecification
                (
                    fc => fc.ParentId == parentId && !fc.Dishes.Any()
                );
            var brothers = getDishFamilyBySpecification.Execute(brothersSpe);

            var parentModel = BuildSelectListViewModelForDishFamily(new SelectList(brothers, "Id", "Name", _family.Id));
            parentModel.NestedItems = result;

            if (!string.IsNullOrEmpty(_family.ParentId))
            {
                parentModel = PopulateParents(parentModel, _family.ParentId);
            }
            return parentModel;
        }

        private SelectList PopulateRestaurants(string restaurantId = null)
        {
            return new SelectList(getAllRestaurantsQuery.Execute(), "Id", "Name", restaurantId);
        }
        [HttpGet]   
        [Route("add")]
        public IActionResult Add(string restaurant = null)
        {
            BreadcrumbForAdd(restaurant);
            var model = new CreateDishFamilyViewModel
            {
                Parents = PopulateParents(),
                Restaurants=PopulateRestaurants(),
                CreateModel = new CreateDishFamilyModel()
            };
            return View(model);
        }

        [HttpPost]
        [Route("add")]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CreateDishFamilyViewModel model,string restaurant = null)
        {
            try
            {
                var _family = model.CreateModel;
                _family.ParentId = model.ParentId;
                if (model.Picture.IsChanged)
                {
                    _family.PictureUrl = model.Picture.Save(hostingEnvironment, Request, "dishes,famillies");
                }
                createDishFamilyCommand.Execute(_family);
                return RedirectToAction("Index");
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }
            BreadcrumbForAdd(restaurant);
            model.Parents = PopulateParents(string.Empty, model.ParentId);
            model.Restaurants =PopulateRestaurants(model.CreateModel.RestaurantId);
            return View(model);
        }

        [HttpGet]
        [Route("edit")]
        public IActionResult Edit(string id,string restaurant = null)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("BadRequest");
            }
            try
            {
                var _family = getDishFamilyByIdQuery.Execute(id);

                var model = new UpdateDishFamilyViewModel
                {
                    UpdateModel = _family,
                    ParentId = _family.ParentId,
                    Parents = PopulateParents(_family.Id, _family.ParentId),
                    Picture = new FileViewModel(_family.Picture.Id, _family.Picture.Url),
                };

                BreadcrumbForEdit(restaurant,_family.Name);
                model.Parents = PopulateParents(string.Empty, model.ParentId);
                model.Restaurants = PopulateRestaurants(model.UpdateModel.RestaurantId);
                return View(model);
            }
            catch (NotFoundException)
            {
                return View("NotFound");
            }
            
        }

        [HttpPost]
        [Route("edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateDishFamilyViewModel model, string restaurant = null)
        {
            try
            {
                var _family = model.UpdateModel;
                _family.ParentId = model.ParentId;

                if (model.Picture.IsChanged)
                {
                    _family.Picture.Id = null;
                    _family.Picture.Url = model.Picture.Save(hostingEnvironment, Request, "dishes,famillies");
                }
                else
                {
                    _family.Picture.Id = model.Picture.ImageId;
                    _family.Picture.Url = model.Picture.OldUrl;
                }
                updateDishFamilyCommand.Execute(model.UpdateModel);
                return RedirectToAction("Index");
            }
            catch(NotFoundException)
            {
                return View("NotFound");
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }
            BreadcrumbForEdit(restaurant,model.UpdateModel.Name);
            model.Parents = PopulateParents(string.Empty, model.ParentId);
            model.Restaurants = PopulateRestaurants(model.UpdateModel.RestaurantId);
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
                    var category = getDishFamilyByIdQuery.Execute(id);
                    model.Args.Add(category.Id);
                    model.Args.Add(Url.Action("Delete", "DishesFamillies"));
                    model.Args.Add("dish-family");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, DishFamilyUtilsResource.TableName);
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
                    deleteDishFamilyCommand.Execute(new DeleteDishFamilyModel { Id = id });
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