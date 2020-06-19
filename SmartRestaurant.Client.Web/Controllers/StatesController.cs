using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Commun.Countries.Commands.Create;
using SmartRestaurant.Application.Commun.Countries.Queries.GetCountriesList;
using SmartRestaurant.Application.Commun.State.Commands.Create;
using SmartRestaurant.Application.Commun.State.Commands.Delete;
using SmartRestaurant.Application.Commun.States.Queries.GetStateById;
using SmartRestaurant.Application.Commun.States.Queries.GetStatesList;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Models.States;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Commun.State;
using SmartRestaurant.Resources.Utils;
using System;

namespace SmartRestaurant.Client.Web.Controllers
{
    // [Area("Admin")]

    [Route("states")]
    [Route("{culture}/states")]
    public class StatesController : AdminBaseController
    {
        private readonly IGetAllStatesQuerie getAllStatesQuerie;
        private readonly ICreateStateCommand createStateCommand;
        private readonly IUpdateStateCommand updateStateCommand;
        private readonly IDeleteStateCommand deleteStateCommand;
        private readonly IGetAllCountriesQuerie getAllCountriesQuerie;
        private readonly IGetStateByIdQuerie getStateByIdQuerie;
        private readonly ILoggerService<StatesController> _log;

        public StatesController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
           IGetAllStatesQuerie getAllStatesQuerie,
            ICreateStateCommand createStateCommand,
          IUpdateStateCommand updateStateCommand,
          IDeleteStateCommand deleteStateCommand,
        IGetAllCountriesQuerie getAllCountriesQuerie,
          IGetStateByIdQuerie getStateByIdQuerie,
          ILoggerService<AdminBaseController> baselog,
          ILoggerService<StatesController> log) : base(configuration, mailing, notify, baselog)
        {
            this.getAllStatesQuerie = getAllStatesQuerie;
            this.createStateCommand = createStateCommand;
            this.updateStateCommand = updateStateCommand;
            this.deleteStateCommand = deleteStateCommand;
            this.getAllCountriesQuerie = getAllCountriesQuerie;
            this.getStateByIdQuerie = getStateByIdQuerie;
            _log = log;

        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(StateUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(StateUtilsResource.HomeNavigationTitle)
                .Save();

            return View(getAllStatesQuerie.Execute());
        }

        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(StateUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem("States", Url.Action("Index", "States"))
               .AddItem(StateUtilsResource.AddNewNavigationTitle)
               .Save();
        }

        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(StateUtilsResource.EditPageTitle)
               .AddHome()
              .AddItem("Cities", Url.Action("Index", "Cities"))
               .AddItem(string.Format(StateUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            var model = new StateViewModel()
            {
                CreateModel = new CreateStateModel(),
                Countries = PopulateCountries(),
            };
            return View(model);
        }

        private SelectList PopulateCountries(string selected = null)
        {
            return new SelectList(getAllCountriesQuerie.Execute(), "Id", "Name", selected);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(StateViewModel model)
        {
            BreadcrumbForAdd();
            try
            {
                var _state = model.CreateModel;
                createStateCommand.Execute(_state);

                //command.Execute(model);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);

            }
            model.Countries = PopulateCountries(model.CreateModel.CountryId);
            return View(model);
        }



        [HttpGet]
        [Route("edit")]
        public IActionResult Edit(string Id)
        {
            if (Id == null)
            {
                return View("NotFound");
            }
            try
            {
                var result = getStateByIdQuerie.Execute(Id);
                var model = new StateViewModel()
                {
                    UpdateModel = result,
                    Countries = PopulateCountries(result.CountryId)
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
        public IActionResult Edit(StateViewModel model)
        {
            BreadcrumbForEdit(model.UpdateModel.Name);

            try
            {
                var _city = model.UpdateModel;
                updateStateCommand.Execute(model.UpdateModel);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);

            }
            model.Countries = PopulateCountries(model.UpdateModel.CountryId);
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
                    var state = getStateByIdQuerie.Execute(id);
                    model.Args.Add(state.Id);
                    model.Args.Add(Url.Action("Delete", "states"));
                    model.Args.Add("state");
                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, BaseResource.Name);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, state.Name);
                    model.HasError = false;


                }
                catch (NotFoundException ex)
                //l'exception qui est dans la couche application me retourne un message
                {
                    model.HasError = true;
                    model.Error.Message = ex.Message;
                }
                catch (Exception)
                //message par défaut stocké dans les ressource.
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
                    deleteStateCommand.Execute(new DeleteStateModel { Id = id });
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


