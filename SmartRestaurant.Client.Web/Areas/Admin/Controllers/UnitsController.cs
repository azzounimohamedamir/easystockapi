using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Commun.Cities.Queries.GetCitiesByStateId;
using SmartRestaurant.Application.Commun.Units.Commands.Create;
using SmartRestaurant.Application.Commun.Units.Commands.Delete;
using SmartRestaurant.Application.Commun.Units.Commands.Update;
using SmartRestaurant.Application.Commun.Units.Queries.GetUnitById;
using SmartRestaurant.Application.Commun.Units.Queries.GetUnitsList;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Commun.Unit;
using SmartRestaurant.Resources.Utils;
using System;

namespace SmartRestaurant.Client.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/units")]   
    
    public class UnitsController : AdminBaseController
    {
        private readonly ILoggerService<StatesController> _log;
        
        private readonly ICreateUnitCommand _createUnitCommand;
        private readonly IUpdateUnitCommand _updateUnitCommand;
        private readonly IDeleteUnitCommand _deleteUnitCommand;
        private readonly IGetAllUnitsQuerie _getAllUnitsQuery;
        private readonly IGetUnitByIdQuerie _getUnitByIdQuery;
        

        public UnitsController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,            
            ICreateUnitCommand createUnitCommand,
            IUpdateUnitCommand updateUnitCommand,
            IDeleteUnitCommand deleteUnitCommand,
            IGetAllUnitsQuerie getAllUnitsQuery,
            IGetUnitByIdQuerie getUnitByIdQuery,            
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<StatesController> log) : base(configuration, mailing, notify, baselog)
        {
            _log = log;            
            _createUnitCommand = createUnitCommand;
            _updateUnitCommand = updateUnitCommand;
            _deleteUnitCommand = deleteUnitCommand;
            _getAllUnitsQuery = getAllUnitsQuery;
            _getUnitByIdQuery = getUnitByIdQuery;
            
        }
      
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(UnitUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(UnitUtilsResource.HomeNavigationTitle)
                .Save();

            return View(_getAllUnitsQuery.Execute());
        }       
        

        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(UnitUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(UnitUtilsResource.HomePageTitle, Url.Action("Index", "Units"))
               .AddItem(UnitUtilsResource.AddNewNavigationTitle)
               .Save();
            
        }

        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(UnitUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(UnitUtilsResource.HomePageTitle, Url.Action("Index", "Units"))
               .AddItem(string.Format(UnitUtilsResource.EditNavigationTitle, name))
               .Save();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            return View(new CreateUnitModel());
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(CreateUnitModel model)
        {
            BreadcrumbForAdd();
            try
            {                
                _createUnitCommand.Execute(model); 
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
                var unit = _getUnitByIdQuery.Execute(id);
                BreadcrumbForEdit(unit.Name);
                return View(unit);                             
            }
            catch (NotFoundException)
            {
                return View("NotFound");
            }
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(UpdateUnitModel model)
        {
            BreadcrumbForEdit(model.Name);

            try
            {                
                _updateUnitCommand.Execute(model);
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
                    var unit = _getUnitByIdQuery.Execute(id);
                    model.Args.Add(unit.Id);
                    model.Args.Add(Url.Action("Delete", "Units"));
                    model.Args.Add("unit");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, UnitUtilsResource.TableName);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, unit.Name);
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
                    _deleteUnitCommand.Execute(new DeleteUnitModel { Id = id });
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