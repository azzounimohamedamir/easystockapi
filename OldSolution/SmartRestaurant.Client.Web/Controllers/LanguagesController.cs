using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Commun.Languages.Commands.Create;
using SmartRestaurant.Application.Commun.Languages.Commands.Delete;
using SmartRestaurant.Application.Commun.Languages.Commands.Update;
using SmartRestaurant.Application.Commun.Languages.Queries.GetLanguageById;
using SmartRestaurant.Application.Commun.Languages.Queries.GetLanguageByName;
using SmartRestaurant.Application.Commun.Languages.Queries.GetLanguagesList;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Models.Languages;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Commun.Language;
using SmartRestaurant.Resources.Utils;

namespace SmartRestaurant.Client.Web.Controllers
{
   // [Area("Admin")]
    [Route("languages")]
    [Route("{culture?}/languages")]
    public class LanguagesController : AdminBaseController
    {
        #region Private Fields 
        private readonly ICreateLanguageCommand createLanguageCommand;
        private readonly IUpdateLanguageCommand updateLanguageCommand;
        private readonly IDeleteLanguageCommand deleteLanguageCommand;
        private readonly IGetAllLanguagesQuerie getAllLanguagesQuerie;
        private readonly IGetLanguageByIdQuerie getLanguageByIdQuerie;
        private readonly IGetLanguageByNameQuerie getLanguageByNameQuery;
        private readonly ILoggerService<LanguagesController> _log;
        #endregion
        #region Constructor 
        public LanguagesController(

        
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
          ICreateLanguageCommand createLanguageCommand,
          IUpdateLanguageCommand updateLanguageCommand,
          IDeleteLanguageCommand deleteLanguageCommand,
          IGetAllLanguagesQuerie getAllLanguagesQuerie,
          IGetLanguageByIdQuerie getLanguageByIdQuerie,
          IGetLanguageByNameQuerie getLanguageByNameQuery,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<LanguagesController> log) : 
            base(configuration, mailing, notify, baselog)
        {
            this.createLanguageCommand = createLanguageCommand;
            this.updateLanguageCommand = updateLanguageCommand;
            this.deleteLanguageCommand = deleteLanguageCommand;
            this.getAllLanguagesQuerie = getAllLanguagesQuerie;
            this.getLanguageByIdQuerie = getLanguageByIdQuerie;
            this.getLanguageByNameQuery = getLanguageByNameQuery;
            _log = log;
          
        }
        #endregion
        #region Index
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(LanguageUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(LanguageUtilsResource.HomeNavigationTitle)
                .Save();

            return View(getAllLanguagesQuerie.Execute());
        }
        #endregion

       
        #region Add 
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            var model = new LanguageViewModel()
            {
                CreateModel = new CreateLanguageModel()
            };
            return View(model);
        }

    
        [HttpPost]
        [Route("add")]
        public IActionResult Add(LanguageViewModel model)
        {
            BreadcrumbForAdd();
            try
            {
                var _Lang = model.CreateModel;

                createLanguageCommand.Execute(_Lang);
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
            if (String.IsNullOrEmpty(Id))
            {
                return View("NotFound");
            }
            try
            {
                var result = getLanguageByIdQuerie.Execute(Id);
                var model = new LanguageViewModel()
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
        public IActionResult Edit(LanguageViewModel model)
        {
            BreadcrumbForEdit(model.UpdateModel.Name);

            try
            {
                var _lang = model.UpdateModel;
                updateLanguageCommand.Execute(model.UpdateModel);
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
                    var language = getLanguageByIdQuerie.Execute(id);
                    model.Args.Add(language.Id);
                    model.Args.Add(Url.Action("Delete", "languages"));
                    model.Args.Add("language");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, BaseResource.Name);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, language.Name);
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
                    deleteLanguageCommand.Execute(new DeleteLanguageModel { Id = id });
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

        #region Private Methodes
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(LanguageUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem("Languages", Url.Action("Index", "Languages"))
               .AddItem(LanguageUtilsResource.AddNewNavigationTitle)
               .Save();
        }

        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(LanguageUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem("Languages", Url.Action("Index", "Languages"))
               .AddItem(string.Format(LanguageUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        #endregion


    }



}