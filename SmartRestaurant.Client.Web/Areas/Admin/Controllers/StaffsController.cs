using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Staffs.Commands.Create;
using SmartRestaurant.Application.Restaurants.Staffs.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Staffs.Services;
using SmartRestaurant.Application.Restaurants.Staffs.Specifications;
using SmartRestaurant.Client.Web.Models.Restaurants;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Client.Web.Utils;
using SmartRestaurant.Domain.Enumerations;
using SmartRestaurant.Resources.Restaurants.Staffs;
using SmartRestaurant.Resources.Utils;
using System;

namespace SmartRestaurant.Client.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/Staffs")]
    public class StaffsController : AdminBaseController
    {
        private readonly ILoggerService<StaffsController> _log;
        private readonly IStaffService staffService;

        public IGetAllRestaurantsQuery getAllRestaurants { get; }
        public IGetRestaurantByIdQuery getRestaurantById { get; }

        public StaffsController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<StaffsController> log,
            IStaffService service,
            IGetAllRestaurantsQuery getAllRestaurants,
            IGetRestaurantByIdQuery getRestaurantById          
            //IHostingEnvironment hostingEnvironnement
            )
            : base(configuration, mailing, notify, baselog)
        {
            _log = log;
            this.staffService = service;
            this.getAllRestaurants = getAllRestaurants;
            this.getRestaurantById = getRestaurantById;
            //_hostingEnvironnement = hostingEnvironnement;
        }

        #region Index
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(StaffUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(StaffUtilsResource.HomeNavigationTitle, Url.Action("Staffs", "Index"))
                .Save();

            var spe = new StaffSpecification()
                .AddInclude(s => s.Restaurant);
            var staffs=staffService.Queries.Filter.Execute(new StaffSpecification());
            
            var result = new StaffItemViewModel
            {
                Parents = GetParent(),
                Entities=staffs,
            };
            return View(result);

        }

        [HttpPost]
        [Route("index")]
        public IActionResult Index(StaffItemViewModel viewModel)
        {
            this.PageBreadcrumb.SetTitle(StaffUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(StaffUtilsResource.HomeNavigationTitle, Url.Action("Staffs", "Index"))
                .Save();

            viewModel.Entities =staffService.Queries.GetByRestaurantId
                .Execute(viewModel.SelectedParentId);
            viewModel.Parents = GetParent(viewModel.SelectedParentId);
            
            return View(viewModel);
        }
        #endregion

        #region Add
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {

            var model = new StaffViewModel
            {
                CreateModel = new CreateStaffModel(),
                Parents = GetParent(),
                Roles = SelectListHelper.PopulateEnum<EnumPersoneType>()
            };
            return View(model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(StaffViewModel model)
        {
            BreadcrumbForAdd();
            try
            {
                staffService.Create.Execute(model.CreateModel);
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
                var result = staffService.Queries.GetById.Execute(id);
                BreadcrumbForEdit(result.FullName);

                var viewModel = new StaffViewModel
                {
                    UpdateModel = result,
                    Parents = GetParent(result.RestaurantId),
                    Roles = SelectListHelper.PopulateEnum<EnumPersoneType>((int)result.StaffRole)
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
        public IActionResult Edit(StaffViewModel model)
        {
            BreadcrumbForEdit(model.UpdateModel.FullName);
            try
            {
                staffService.Update.Execute(model.UpdateModel);
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
            this.PageBreadcrumb.SetTitle(StaffUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(StaffUtilsResource.HomePageTitle, Url.Action("Index", "Staffs"))
               .AddItem(StaffUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name="name"></param>
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(StaffUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(StaffUtilsResource.HomePageTitle, Url.Action("Index", "Staffs"))
               .AddItem(string.Format(StaffUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        private SelectList GetParent(object selected=null)
        {
           return  new SelectList(getAllRestaurants.Execute(null,null), "Id", "Name", selected);
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
                    var entity = staffService.Queries.GetById.Execute(id);
                    model.Args.Add(entity.Id);
                    model.Args.Add(Url.Action("Delete", "Staffs"));
                    model.Args.Add("Staff");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, StaffResource.Staff);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, entity.FirstName+" "+entity.LastName);
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
                    staffService.Delete.Execute(new DeleteStaffModel { Id = id });
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

        [HttpGet]
        [Route("search")]
        public IActionResult Search()
        {
            return View();
        }
    }
}