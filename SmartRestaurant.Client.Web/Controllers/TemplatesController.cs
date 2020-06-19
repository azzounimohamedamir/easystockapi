using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Templates.Commands.Create;
using SmartRestaurant.Application.Templates.Commands.Delete;
using SmartRestaurant.Application.Templates.Commands.Update;
using SmartRestaurant.Application.Templates.Queries.GetTemplateById;
using SmartRestaurant.Application.Templates.Queries.GetTemplateItems;
using SmartRestaurant.Client.Web.Extensions;
using SmartRestaurant.Client.Web.Models.Templates;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Domain.Enumerations;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Templates;
using SmartRestaurant.Resources.Utils;
using System;

namespace SmartRestaurant.Client.Web.Controllers
{

    // [Area("Admin")]
    [Route("templates")]
    [Route("{culture}/templates")]
    public class TemplatesController : AdminBaseController
    {
        private readonly ICreateTemplateCommand createTemplateCommand;
        private readonly IUpdateTemplateCommand updateTemplateCommand;
        private readonly IDeleteTemplateCommand deleteTemplateCommand;
        private readonly IGetAllTemplateQuerie getAllTemplatesQuerie;
        private readonly IGetTemplateByIdQuerie getTemplateByIdQuerie;
        private readonly ILoggerService<TemplatesController> _log;

        public TemplatesController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
          ICreateTemplateCommand createTemplateCommand,
          IUpdateTemplateCommand updateTemplateCommand,
          IDeleteTemplateCommand deleteTemplateCommand,
          IGetAllTemplateQuerie getAllTemplatesQuerie,
          IGetTemplateByIdQuerie getTemplateByIdQuerie,

         ILoggerService<AdminBaseController> baselog,
         ILoggerService<TemplatesController> log) :
            base(configuration, mailing, notify, baselog)
        {
            this.createTemplateCommand = createTemplateCommand;
            this.updateTemplateCommand = updateTemplateCommand;
            this.deleteTemplateCommand = deleteTemplateCommand;
            this.getAllTemplatesQuerie = getAllTemplatesQuerie;
            this.getTemplateByIdQuerie = getTemplateByIdQuerie;
            _log = log;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(TemplateUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(TemplateUtilsResource.HomeNavigationTitle)
                .Save();

            return View(getAllTemplatesQuerie.Execute());
        }

        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(TemplateUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem("Templates", Url.Action("Index", "Templates"))
               .AddItem(TemplateUtilsResource.AddNewNavigationTitle)
               .Save();
        }

        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(TemplateUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem("Templates", Url.Action("Index", "Templates"))
               .AddItem(string.Format(TemplateUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            var model = new TemplateViewModel()
            {
                CreateModel = new CreateTemplateModel(),
                TemplateType = EnumHelper<EnumTemplateType>.ToSelectList(),

            };
            return View(model);
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add(TemplateViewModel model)
        {
            BreadcrumbForAdd();
            try
            {
                var _Template = model.CreateModel;
                // model.CreateModel.Type = model.Type; 
                createTemplateCommand.Execute(_Template);
                //command.Execute(model);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);

            }
            //model.TemplateType = PopulateEnum(model.CreateModel.Type.ToString());
            model.TemplateType = EnumHelper<EnumTemplateType>.ToSelectList(model.CreateModel.Type.ToString());

            return View(model);
        }
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
                var result = getTemplateByIdQuerie.Execute(Id);
                var model = new TemplateViewModel()
                {
                    UpdateModel = result,
                    TemplateType = EnumHelper<EnumTemplateType>.
                    ToSelectList(result.Type.ToString())
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
        public IActionResult Edit(TemplateViewModel model)
        {
            BreadcrumbForEdit(model.UpdateModel.Name);

            try
            {

                updateTemplateCommand.Execute(model.UpdateModel);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);

            }
            model.TemplateType = EnumHelper<EnumTemplateType>.ToSelectList(model.UpdateModel.Type.ToString());

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
                    var Template = getTemplateByIdQuerie.Execute(id);
                    model.Args.Add(Template.Id);
                    model.Args.Add(Url.Action("Delete", "Templates"));
                    model.Args.Add("template");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, BaseResource.Name);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, Template.Name);
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
                    deleteTemplateCommand.Execute(new DeleteTemplateModel { Id = id });
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





