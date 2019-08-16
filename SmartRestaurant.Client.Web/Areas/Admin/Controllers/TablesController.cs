using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Areas.Queries.GetByFloorId;
using SmartRestaurant.Application.Restaurants.Floors.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Floors.Queries.GetByRestaurantId;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Create;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Update;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetByAreaId;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetByFloorId;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetByRestaurantId;
using SmartRestaurant.Client.Web.Models;
using SmartRestaurant.Client.Web.Models.Restaurants;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Restaurants.Areas;
using SmartRestaurant.Resources.Restaurants.Tables;
using SmartRestaurant.Resources.Utils;

namespace SmartRestaurant.Client.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/tables")]
    public class TablesController : AdminBaseController
    {

        private readonly ILoggerService<TablesController> _log;
        private readonly ICreateTableCommand createCommand;
        private readonly IUpdateTableCommand updateCommand;
        private readonly IDeleteTableCommand deleteCommand;
        private readonly IHostingEnvironment _hostingEnvironnement;
        private readonly IGetTableByIdQuery getById;
        private readonly IGetAllRestaurantsQuery getAllRestaurants;
        private readonly IGetFloorsByRestaurantIdQuery getFloorsByRestaurantId;
        private readonly IGetAreasByFloorIdQuery getAreasByFloorId;
        private readonly IGetTablesByAreaIdQuery getTablesByAreaId;

        public TablesController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<TablesController> log,
            ICreateTableCommand createCommand,
            IUpdateTableCommand updateCommand,
            IDeleteTableCommand deleteCommand,
            IGetTableByIdQuery getById,
            IGetAllRestaurantsQuery getAllRestaurants,
            IGetFloorsByRestaurantIdQuery getFloorsByRestaurantId,
            IGetAreasByFloorIdQuery getAreasByFloorIdQuery,
            IGetTablesByAreaIdQuery getTablesByAreaIdQuery

            )
            : base(configuration, mailing, notify, baselog)
        {

            _log = log;
            this.createCommand = createCommand;
            this.updateCommand = updateCommand;
            this.deleteCommand = deleteCommand;
            this.getById = getById;
            this.getAllRestaurants = getAllRestaurants;
            this.getFloorsByRestaurantId = getFloorsByRestaurantId;
            this.getAreasByFloorId = getAreasByFloorIdQuery;
            this.getTablesByAreaId = getTablesByAreaIdQuery;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(TableUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(TableUtilsResource.HomeNavigationTitle, Url.Action("Tables", "Index"))
                .Save();

            var viewModel = new TableItemViewModel
            {
                TableFilterViewModel = new TableFilterViewModel
                {
                    Restaurants = GetRestaurants()
                }
            };
            return View(viewModel);
        }
        [HttpPost]
        [Route("index")]
        public IActionResult Index(TableItemViewModel viewmodel)
        {
            this.PageBreadcrumb.SetTitle(TableUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(TableUtilsResource.HomeNavigationTitle, Url.Action("Tables", "Index"))
                .Save();

            viewmodel.TableFilterViewModel.Restaurants =
                GetRestaurants(viewmodel.TableFilterViewModel.SelectedRestaurantId);
            viewmodel.TableFilterViewModel.Floors =
                GetFloors(viewmodel.TableFilterViewModel.SelectedRestaurantId,
                viewmodel.TableFilterViewModel.SelectedFloorId);
            GetAreas(viewmodel.TableFilterViewModel.SelectedFloorId,
               viewmodel.TableFilterViewModel.SelectedAreaId);
            viewmodel.Tables = getTablesByAreaId.Execute(viewmodel.TableFilterViewModel.SelectedAreaId);
            return View(viewmodel);
        }

        /// <summary>
        /// Breadcrumb de la page Add
        /// </summary>
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(TableUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(TableUtilsResource.HomePageTitle, Url.Action("Index", "Tables"))
               .AddItem(TableUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name = "name" ></ param >
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(TableUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(TableUtilsResource.HomePageTitle, Url.Action("Index", "Tables"))
               .AddItem(string.Format(TableUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        private SelectList GetRestaurants(string selectedRestaurant = null)
        {
            return new SelectList(getAllRestaurants.Execute(null, null),
                 "Id", "Name", selectedRestaurant);

        }
        private SelectList GetFloors(string restId, string selectedFloor = null)
        {
            return new SelectList(getFloorsByRestaurantId.Execute(restId),
               "Id", "Name", selectedFloor);
        }
        private SelectList GetAreas(string floorId, string selectedArea= null)
        {
            return new SelectList(getAreasByFloorId.Execute(floorId),
               "Id", "Name", selectedArea);
        }
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            var model = new TableViewModel
            {
                Restaurants = GetRestaurants()
            };
            return View(model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(TableViewModel model)
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
                var result = getById.Execute(id);
                BreadcrumbForEdit(result.Name);

                var viewModel = new TableViewModel
                {
                    Restaurants = GetRestaurants(result.RestaurantId),
                    Floors = GetFloors(result.RestaurantId, result.FloorId),
                    Areas = GetAreas(result.FloorId, result.AreaId),
                    RestaurantId = result.RestaurantId,
                    FloorId = result.FloorId,
                    UpdateModel = result,
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
        public IActionResult Edit(TableViewModel viewModel)
        {
            BreadcrumbForEdit(viewModel.UpdateModel.Name);
            try
            {
                updateCommand.Execute(viewModel.UpdateModel);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }
            return View(viewModel);
        }


        [HttpGet]
        [Route("getAreasByFloorId")]
        public JsonResult GetAreasByFloorId(string parentVal)
        {
            var result = getAreasByFloorId.Execute(parentVal);

            var list = new SelectList(result, "Id", "Name");
            return Json(new TitleListModel(list, AreaResource.Area));
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
                    model.Args.Add(Url.Action("Delete", "Tables"));
                    model.Args.Add("Table");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, TableResource.Table);
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
                    deleteCommand.Execute(new DeleteTableModel { Id = id });
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