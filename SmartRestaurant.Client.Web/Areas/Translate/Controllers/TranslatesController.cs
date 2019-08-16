using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrenciesList;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Translates.Translates.Commands.Update;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Client.Web.Models;
 using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Utils;
using SmartRestaurant.Application.Commun.Translates.Commands.Create;
using SmartRestaurant.Application.Commun.Translates.Commands.Update;
using SmartRestaurant.Application.Commun.Translates.Commands.Delete;
using SmartRestaurant.Application.Commun.Translates.Queries.GetByTableName;
using SmartRestaurant.Resources.Commun.Translator;
using SmartRestaurant.Client.Web.Areas.Translate.Models;
using SmartRestaurant.Application.Commun.Languages.Queries.GetLanguagesList;

namespace SmartRestaurant.Client.Web.Areas.Admin.Controllers
{
    public class TransationResult
    {
        public TransationResult()
        {

        }
        public bool Failed { get; set; } = false;
        public string Message { get; set; }
    }
    [Area("Translate")]
    [Route("translate/Translates")]
    public class TranslatesController : AdminBaseController
    {
        private readonly ILoggerService<TranslatesController> _log;
        private readonly ICreateTranslateCommand createCommand;
        private readonly IUpdateTranslateCommand updateCommand;
        private readonly IDeleteTranslateCommand deleteCommand;

       
        private readonly IGetAllRestaurantsQuery getAllRestaurants;
        private readonly IGetAllLanguagesQuerie getAllLanguagesQuerie;
        private readonly IGetAllCurrenciesQuery getAllCurrencies;
        private readonly IHostingEnvironment hostingEnvironnement;
        private readonly IGetTranslatesByTableNameQuery getTranslatesByTableNameQuery;
 


        public TranslatesController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<TranslatesController> log,
          ICreateTranslateCommand createCommand,
          IUpdateTranslateCommand updateCommand,
          IDeleteTranslateCommand deleteCommand,
          IGetAllCurrenciesQuery getAllCurrencies,
          IGetTranslatesByTableNameQuery getTranslatesByTableNameQuery,
          IGetAllRestaurantsQuery getAllRestaurants,
          IGetAllLanguagesQuerie getAllLanguagesQuerie,
            IHostingEnvironment hostingEnvironnement)
            
            : base(configuration, mailing, notify, baselog)
        {
            _log = log;

            this.createCommand = createCommand;
            this.updateCommand = updateCommand;
            this.deleteCommand = deleteCommand;
            this.getAllRestaurants = getAllRestaurants;
            this.getAllLanguagesQuerie = getAllLanguagesQuerie;
            this.hostingEnvironnement = hostingEnvironnement;
            this.getAllCurrencies = getAllCurrencies;

            this.getTranslatesByTableNameQuery = getTranslatesByTableNameQuery;
            
        }

        #region Index
        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(TranslateUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(TranslateUtilsResource.HomeNavigationTitle, Url.Action("Translates", "Index"))
                .Save();

            var result = new TranslatesViewModel
            {
                TablesNames = GetTablesName(),
                Languages = getAllLanguagesQuerie.Execute().OrderBy(x => x.EnglishName).ToList()
            };
            return View(result);
        }

       

        [HttpPost]
        [Route("")]
        [Route("index")]
        public IActionResult Index(TranslatesViewModel viewModel)
        {
            this.PageBreadcrumb.SetTitle(TranslateUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(TranslateUtilsResource.HomeNavigationTitle, Url.Action("TranslateFamilies", "Index"))
                .Save();

            viewModel.Translates = getTranslatesByTableNameQuery
                .Execute(viewModel.SelectedTableName);
            viewModel.TablesNames = GetTablesName();
            viewModel.Languages =  getAllLanguagesQuerie.Execute().OrderBy(x => x.EnglishName).ToList();
            return View(viewModel);
        }
        #endregion

        [HttpPost]
        [Route("save")]
        public IActionResult Save(ItemTranslatesModel viewModel)
        {
            try
            {
                //System.Threading.Thread.Sleep(5000);
                createCommand.Execute(new List<ItemTranslatesModel> {  viewModel });
                return Ok(new TransationResult { Failed=false,Message="Ok"});
            }
            catch
            {
                return Ok(new TransationResult { Failed = true, Message = "ERROR" });
            }
                    
        }

        #region Methods
        /// <summary>
        /// Breadcrumb de la page Add
        /// </summary>
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(TranslateUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(TranslateUtilsResource.HomePageTitle, Url.Action("Index", "Translates"))
               .AddItem(TranslateUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name="name"></param>
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(TranslateUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(TranslateUtilsResource.HomePageTitle, Url.Action("Index", "Translates"))
               .AddItem(string.Format(TranslateUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }
        private SelectList GetTablesName()
        {
            var tables = new List<string>
            {
                "Dishes",
                "Foods",
                "Ingredients",
                "FoodCatigories",
                "ProductFamilies",
                "Products",

            };
            return new SelectList(tables);

        }
 
        
        #endregion

    }
}