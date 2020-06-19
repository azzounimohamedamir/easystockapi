using System;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Commun.Cities.Commands;
using SmartRestaurant.Application.Commun.Cities.Commands.Update;
using SmartRestaurant.Application.Commun.Cities.Queries.GetCitiesByStateId;
using SmartRestaurant.Application.Commun.Cities.Queries.GetCitiesList;
using SmartRestaurant.Application.Commun.Cities.Queries.GetCityById;
using SmartRestaurant.Application.Commun.City.Commands.Delete;
using SmartRestaurant.Application.Commun.Countries.Queries.GetCountriesList;
using SmartRestaurant.Application.Commun.States.Queries.GetStateByCountry;
using SmartRestaurant.Application.Commun.States.Queries.GetStatesList;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Models.Cities;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Commun.City;
using SmartRestaurant.Resources.Utils;

namespace SmartRestaurant.Client.Web.Controllers
{
   // [Area("Admin")]
    [Route("/cities")]
    [Route("{culture}/cities")]
    

    public class CitiesController : AdminBaseController
    {
        #region Private Fields 
        private readonly IGetStatesByCountryIdQuerie getStatesByCountryIdQuerie;
        private readonly IGetAllCountriesQuerie getAllCountriesQuerie;
        private readonly IGetAllStatesQuerie getAllStatesQuerie;
        private readonly ICreateCityCommand createCityCommand;
        private readonly IUpdateCityCommand updateCityCommand;
        private readonly IDeleteCityCommand deleteCityCommand;
        private readonly IGetAllCitiesQuerie getAllCitiesQuerie;
        private readonly IGetCityByIdQuerie getCityByIdQuerie;
        private readonly IGetCitiesByStateIdQuerie getCityByStateIdQuery;
        private readonly ILoggerService<StatesController> _log;
        public  SelectList Countries;
        public  SelectList States;
        #endregion
        #region Constructor
        public CitiesController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            IGetStatesByCountryIdQuerie getStatesByCountryIdQuerie,
            IGetAllCountriesQuerie getAllCountriesQuerie,
           IGetAllStatesQuerie getAllStatesQuerie,
            ICreateCityCommand createCityCommand,
          IUpdateCityCommand updateCityCommand,
          IDeleteCityCommand deleteCityCommand,
          IGetAllCitiesQuerie getAllCitiesQuerie,
          IGetCityByIdQuerie getCityByIdQuerie,
          IGetCitiesByStateIdQuerie getCityByStateIdQuery,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<StatesController> log) : base(configuration, mailing, notify, baselog)
        {
            this.getStatesByCountryIdQuerie = getStatesByCountryIdQuerie;
            this.getAllCountriesQuerie = getAllCountriesQuerie;
            this.getAllStatesQuerie = getAllStatesQuerie;
            this.createCityCommand = createCityCommand;
            this.updateCityCommand = updateCityCommand;
            this.deleteCityCommand = deleteCityCommand;
            this.getAllCitiesQuerie = getAllCitiesQuerie;
            this.getCityByIdQuerie = getCityByIdQuerie;
            this.getCityByStateIdQuery = getCityByStateIdQuery;
            _log = log;
            
        }

        #endregion
        #region Index
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(CityUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(CityUtilsResource.HomeNavigationTitle)
                .Save();
            Populate(null);
          
            var viewModel = new CityItemViewModel
            {
                CityFilterViewModel = new CityFilterViewModel
                {
                    States = States,
                    Countries = Countries
                }
            };


            return View(viewModel);
        }

        [HttpPost]
        [Route("index")]
        public IActionResult Index(CityItemViewModel viewmodel)
        {
            this.PageBreadcrumb.SetTitle(CityUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(CityUtilsResource.HomeNavigationTitle, Url.Action("Areas", "Index"))
                .Save();

            viewmodel.Cities = getCityByStateIdQuery.Execute(viewmodel.CityFilterViewModel.SelectedStateId);

            Populate(viewmodel.CityFilterViewModel.SelectedCountryId,
                viewmodel.CityFilterViewModel.SelectedStateId);
             viewmodel.CityFilterViewModel.Countries = Countries;
            viewmodel.CityFilterViewModel.States = States;


            return View(viewmodel);
        }
        #endregion


        #region Add   
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            Populate(null);
            var model = new CityViewModel
            {
                Countries = Countries,
                States = States 
            };

            return View(model);
        }


        [HttpPost]
        [Route("add")]
        public IActionResult Add( CityViewModel model)
        {
            BreadcrumbForAdd();
            try
            {
                var _City = model.CreateModel;
                model.CreateModel.CountryId = model.CountryId;
                //model.CreateModel.StateId = model.StateId;
                createCityCommand.Execute(_City);
               
                //command.Execute(model);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);

            }
            // model.States = PopulateStates(model.CreateModel.StateId); 
            Populate(model.CountryId,model.StateId);
            


            return View(model);
        }
        #endregion

        #region Edit
        [HttpGet]
        [Route("edit")]
        public IActionResult Edit(string Id)
        {
            if (Id.IsNullOrEmpty())
            {
                return View("BadRequest");
            }
            try
            {
                var result = getCityByIdQuerie.Execute(Id);
                Populate(result.CountryId,result.CountryId,result.StateId);
                var viewModel = new CityViewModel
                {
                    UpdateModel = result,
                    States = States,
                    Countries = Countries
                };
                BreadcrumbForEdit(result.Name);

                return View(viewModel);
                             
            }
            catch (NotFoundException)
            {
                return View("NotFound");
            }
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit( CityViewModel model)
        {
            BreadcrumbForEdit(model.UpdateModel.Name);

            try
            {
                var _city = model.UpdateModel;
                updateCityCommand.Execute(model.UpdateModel);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);

            }
            return View(model);
        }

        #endregion


        #region Delete 
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
                    var city = getCityByIdQuerie.Execute(id);
                    model.Args.Add(city.Id);
                    model.Args.Add(Url.Action("Delete", "cities"));
                    model.Args.Add("city");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, CityResource.Name);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, city.Name);
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
                    deleteCityCommand.Execute(new DeleteCityModel { Id = id });
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
        #endregion
        #region Private Methods 
        /////call for States Selectlist based on country 
        public JsonResult StateDropDownList(string id)
        {
            var entities = getStatesByCountryIdQuerie.Execute(id);


            States = new SelectList(getStatesByCountryIdQuerie.Execute(id)
             , "Id", "Name", id);

            return Json(States);
        }

        [HttpGet]
        [Route("getstates")]

        public JsonResult GetStates(string countryid)
        {           

            States = new SelectList(getStatesByCountryIdQuerie.Execute(countryid),
                "Id", "Name");

                        
            return Json(States);
        }

        private void Populate(string countryId, string selectedCountry = null,
       string selectedState = null)
        {

            Countries = new SelectList(getAllCountriesQuerie.Execute(),
                "Id", "Name", selectedCountry);
            States = new SelectList(getStatesByCountryIdQuerie.Execute
                (countryId),
               "Id", "Name", selectedState);
        }

        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(CityUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem("Cities", Url.Action("Index", "Cities"))
               .AddItem(CityUtilsResource.AddNewNavigationTitle)
               .Save();
        }

        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(CityUtilsResource.EditPageTitle)
               .AddHome()
              .AddItem("Cities", Url.Action("Index", "Cities"))
               .AddItem(string.Format(CityUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        #endregion
    }
}