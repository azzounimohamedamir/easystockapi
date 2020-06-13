using System;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Commun.Currencies.Commands.Create;
using SmartRestaurant.Application.Commun.Currencies.Commands.Delete;
using SmartRestaurant.Application.Commun.Currencies.Commands.Update;
using SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrenciesList;
using SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrencyById;
using SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrencyByName;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Models.Currencies;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Commun.Currency;
using SmartRestaurant.Resources.Utils;

namespace SmartRestaurant.Client.Web.Controllers
{
   // [Area("Admin")]
    [Route("currencies")]
    [Route("{culture?}/currencies")]

    public class CurrenciesController : AdminBaseController
    {
        #region Private Fields 
        private readonly IGetAllCurrenciesQuery getAllCurrenciesQuerie;
        private readonly IGetCurrencyByIdQuerie getCurrencyByIdQuerie;
        private readonly ICreateCurrencyCommand createCurrencyCommand;
        private readonly IUpdateCurrencyCommand updateCurrencyCommand;
        private readonly IDeleteCurrencyCommand deleteCurrencyCommand;
        private readonly IGetCurrencyByNameQuerie getCurrencyByNameQuerie;
        private readonly ILoggerService<CurrenciesController> _log;
        #endregion
        #region Constructor 
        public CurrenciesController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            IGetAllCurrenciesQuery getAllCurrenciesQuerie,
            IGetCurrencyByIdQuerie getCurrencyByIdQuerie,
            ICreateCurrencyCommand createCurrencyCommand,
            IUpdateCurrencyCommand updateCurrencyCommand,
            IDeleteCurrencyCommand deleteCurrencyCommand,
            IGetCurrencyByNameQuerie getCurrencyByNameQuerie,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<CurrenciesController> log) :
            base(configuration, mailing, notify, baselog)
        {
            this.getAllCurrenciesQuerie = getAllCurrenciesQuerie;
            this.getCurrencyByIdQuerie = getCurrencyByIdQuerie;
            this.createCurrencyCommand = createCurrencyCommand;
            this.updateCurrencyCommand = updateCurrencyCommand;
            this.deleteCurrencyCommand = deleteCurrencyCommand;
            this.getCurrencyByNameQuerie = getCurrencyByNameQuerie;
            _log = log;


        }
        #endregion

        #region Index

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(CurrencyUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(CurrencyUtilsResource.HomeNavigationTitle)
                .Save();

            return View(getAllCurrenciesQuerie.Execute());
        }
        #endregion
        
        #region Add
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
         
            var model = new CurrencyViewModel()
            {

                CreateModel = new CreateCurrencyModel(),
            
            };
            return View(model);
        }

        


        [HttpPost]
        [Route("add")]
        public IActionResult Add(CurrencyViewModel model)
        {
            BreadcrumbForAdd();
            try
            {
                var _Currency = model.CreateModel;

                createCurrencyCommand.Execute(_Currency);
                //command.Execute(model);
            }
            catch (NotValidException ex)
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
            try
            {
                var result = getCurrencyByIdQuerie.Execute(Id);
                var model = new CurrencyViewModel()
                {
                    UpdateModel = result,

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
        public IActionResult Edit(CurrencyViewModel model)
        {
            BreadcrumbForEdit(model.UpdateModel.Name);

            try
            {
                //var _lang = model.UpdateModel;
                updateCurrencyCommand.Execute(model.UpdateModel);
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
                    var currency = getCurrencyByIdQuerie.Execute(id);
                    model.Args.Add(currency.Id);
                    model.Args.Add(Url.Action("Delete", "currencies"));
                    model.Args.Add("currency");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, BaseResource.Name);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, currency.Name);
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
                    deleteCurrencyCommand.Execute(new DeleteCurrencyModel { Id = id });
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
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(CurrencyUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem("Currencies", Url.Action("Index", "Currencies"))
               .AddItem(CurrencyUtilsResource.AddNewNavigationTitle)
               .Save();
        }

        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(CurrencyUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem("Currencies", Url.Action("Index", "Currencies"))
               .AddItem(string.Format(CurrencyUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        #endregion
    }
}