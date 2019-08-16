using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SmartRestaurant.Client.Web.Models;
using SmartRestaurant.Resources.UI.Areas.Admin.Breadcrumb;
using SmartRestaurant.Resources.Commun.Country;
using SmartRestaurant.Application.Commun.Countries.Commands.Create;
using SmartRestaurant.Application.Exceptions;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Commun.Countries.Services;
using SmartRestaurant.Application.Commun.Countries.Commands.Update;
using SmartRestaurant.Application.Commun.Countries.Queries.GetCountriesList;
using SmartRestaurant.Application.Commun.Countries.Queries.GetCountryById;
using SmartRestaurant.Application.Commun.Countries.Queries.GetCountryByName;
using SmartRestaurant.Client.Web.Models.Countries;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrenciesList;
using SmartRestaurant.Application.Commun.CountryCurrencies.Commands.Create;
using SmartRestaurant.Application.Commun.CountryCurrencies.Commands.Delete;
using SmartRestaurant.Application.Commun.CountryCurrencies.Queries.GetCountryCurrecencyByCountry;
using SmartRestaurant.Application.Commun.CountryCurrencies.Queries;
using Helpers;
using SmartRestaurant.Application.Commun.Currencies.Queries;
using SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrencyById;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Utils;

namespace SmartRestaurant.Client.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/countries")]
    [Route("{culture?}/admin/countries")]    
    public class CountriesController : AdminBaseController
    {
        #region Private Fields 
        private readonly ILoggerService<StatesController> _log;
        private readonly ICountryService _countryService;
        private readonly IGetAllCurrenciesQuery getAllCurrenciesQuerie;
        private readonly ICreateCountryCommand createCountryCommand;
        private readonly IUpdateCountryCommand updateCountryCommand;
        private readonly IDeleteCountryCommand deleteCountryCommand;
        private readonly IGetAllCountriesQuerie getAllCountriesQuerie;
        private readonly IGetCountryByIdQuerie getCountryByIdQuerie;
        private readonly IGetCountryByNameQuery getCountryByNameQuery;
        private readonly IDeleteCountryCurrencyCommand deleteCountryCurrenciesCommand;
        private readonly IGetCountryCurrencyByCountryIdQuerie getCountryCurrencyByCountryIdQuerie;
        private readonly IGetCurrencyByIdQuerie getCurrencyByIdQuerie;
        #endregion
        #region Constructor

        public CountriesController(
            IConfiguration configuration, 
            IMailingService mailing, 
            INotifyService notify, 
            ICountryService countryService ,
                     IGetAllCurrenciesQuery getAllCurrenciesQuerie,
          ICreateCountryCommand createCountryCommand,
          IUpdateCountryCommand updateCountryCommand ,
          IDeleteCountryCommand deleteCountryCommand ,
          IGetAllCountriesQuerie getAllCountriesQuerie,
          IGetCountryByIdQuerie getCountryByIdQuerie,
          IGetCountryByNameQuery getCountryByNameQuery,
          IGetCurrencyByIdQuerie getCurrencyByIdQuerie ,   
          ILoggerService<AdminBaseController> baselog,
            ILoggerService<StatesController> log) : base(configuration, mailing, notify, baselog)
        {
            _log = log;
            _countryService = countryService;
            this.getAllCurrenciesQuerie = getAllCurrenciesQuerie;
            this.createCountryCommand = createCountryCommand;
            this.updateCountryCommand = updateCountryCommand;
            this.deleteCountryCommand = deleteCountryCommand;
            this.getAllCountriesQuerie = getAllCountriesQuerie;
            this.getCountryByIdQuerie = getCountryByIdQuerie;
            this.getCountryByNameQuery = getCountryByNameQuery;
           this.getCurrencyByIdQuerie = getCurrencyByIdQuerie;
          
        }
        #endregion

        #region Index
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(CountryUtilsResource.HomePageTitle)   
                .AddHome()
                .AddItem(CountryUtilsResource.HomeNavigationTitle)
                .Save();

            return View(getAllCountriesQuerie.Execute()) ;
        }
        #endregion
        
        #region Add
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            var q = getAllCurrenciesQuerie.Execute();
            var model = new CountryViewModel()
            {
              
                 CreateModel = new CreateCountryModel(),          
                 CurrenciesItemModel = q                 
            };
            return View(model);
        }



        [HttpPost]
        [Route("add")]
        public IActionResult Add(CountryViewModel model)
        {
            var Currencies = model.CurrenciesItemModel;

            BreadcrumbForAdd();
            try
            {
                var _Country = model.CreateModel;
                if(model.CurrenciesItemModel != null) {
                    _Country.CurrenciesId = model.CurrenciesItemModel.Where(i => i.IsSelected).Select(i => i.Id).ToList();
                }
                
                createCountryCommand.Execute(_Country);

            }
            catch(NotValidException ex)
            {
                AddErrorToModelState(ex);

            }
           
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
                return View("NotFound");
            }
            try {
               
                var result = getCountryByIdQuerie.Execute(Id);
                var model = new CountryViewModel()
                {
                     UpdateModel = result ,
                     CurrenciesItemModel = PopulateCurrencies(result.CurrenciesId)
                };
                BreadcrumbForEdit(result.Name);
                return View(model);
            }
            catch(NotFoundException)
            {
                return View("NotFound");
            }


                      
            
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(CountryViewModel model)
        {
            BreadcrumbForEdit(model.UpdateModel.Name);

            try
            {
                var _country = model.UpdateModel;
                var CountryId = model.UpdateModel.Id;
                _country.CurrenciesId = model.CurrenciesItemModel.Where(i=>i.IsSelected).Select(i => i.Id).ToList();
                updateCountryCommand.Execute(_country);
                

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
                    var country = getCountryByIdQuerie.Execute(id);
                    model.Args.Add(country.Id);
                    model.Args.Add(Url.Action("Delete", "countries"));
                    model.Args.Add("country");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle,CountryResource.Name);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, country.Name);
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
                    deleteCountryCommand.Execute(new DeleteCountryModel { Id = id });
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
        private List<CurrencyItemModel> PopulateCurrencies(List<string> currencies)
        {


            var CurrenciesItems = getAllCurrenciesQuerie.Execute();
            foreach (var item in currencies)
            {
                var entity = getCurrencyByIdQuerie.Execute(item);

                CurrenciesItems.Find(p => p.Id == entity.Id).IsSelected = true;

            }

            return CurrenciesItems;
        }

        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(CountryUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem("Countries", Url.Action("Index", "Countries"))
               .AddItem(CountryUtilsResource.AddNewNavigationTitle)
               .Save();
        }

        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(CountryUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem("Countries", Url.Action("Index", "Countries"))
               .AddItem(string.Format(CountryUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }
        #endregion
    }
}