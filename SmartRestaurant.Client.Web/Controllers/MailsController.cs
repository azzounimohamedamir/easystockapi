using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.MailingUsers.Commands.Create;
using SmartRestaurant.Application.MailingUsers.Commands.Delete;
using SmartRestaurant.Application.MailingUsers.Queries.GetMailingUserByMailingId;
using SmartRestaurant.Application.Mails.Commands.Create;
using SmartRestaurant.Application.Mails.Commands.Delete;
using SmartRestaurant.Application.Mails.Commands.Update;
using SmartRestaurant.Application.Mails.Queries.GelMailingItems;
using SmartRestaurant.Application.Mails.Queries.GetMailingById;
using SmartRestaurant.Application.Templates.Queries.GetTemplateItems;
using SmartRestaurant.Application.Users.Queries;
using SmartRestaurant.Application.Users.Queries.GetUserById;
using SmartRestaurant.Application.Users.Queries.GetUsersitems;
using SmartRestaurant.Client.Web.Extensions;
using SmartRestaurant.Client.Web.Models.Mails;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Domain.Enumerations;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Mailing;
using SmartRestaurant.Resources.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Client.Web.Controllers
{
    // [Area("Admin")]
    [Route("mails")]
    [Route("{culture?}/mails")]
    public class MailsController : AdminBaseController
    {
        #region PrivateFields
        private readonly ICreateMailingCommand createMailCommand;
        private readonly IUpdateMailingCommand updateMailCommand;
        private readonly IDeleteMailingCommand deleteMailCommand;
        private readonly IGetAllMailingItemsQuerie getAllMailsQuerie;
        private readonly IGetMailingByIdQuerie getMailByIdQuerie;
        private readonly IGetAllTemplateQuerie getAllTemplateQuerie;
        private readonly ICreateMailingUserCommand createMailingUserCommand;
        private readonly IDeleteMailingUserCommand deleteMailingUserCommand;
        private readonly IGetMailingUserByMailingIdQuery getMailingUserByMailingIdQuery;
        private readonly IGetUserByIdQuery getuserByIdQuery;
        private readonly IGetUsersItemsQuery getUsersItemsQuery;
        #endregion

        #region Constructor
        public MailsController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
          ICreateMailingCommand createMailCommand,
          IUpdateMailingCommand updateMailCommand,
          IDeleteMailingCommand deleteMailCommand,
          IGetAllMailingItemsQuerie getAllMailsQuerie,
          IGetMailingByIdQuerie getMailByIdQuerie,
          IGetAllTemplateQuerie getAllTemplateQuerie,
          ICreateMailingUserCommand createMailingUserCommand,
          IDeleteMailingUserCommand deleteMailingUserCommand,
          IGetMailingUserByMailingIdQuery getMailingUserByMailingIdQuery,
          IGetUserByIdQuery getuserByIdQuery,
          IGetUsersItemsQuery getUsersItemsQuery,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<MailsController> log) :
            base(configuration, mailing, notify, baselog)
        {
            this.createMailCommand = createMailCommand;
            this.updateMailCommand = updateMailCommand;
            this.deleteMailCommand = deleteMailCommand;
            this.getAllMailsQuerie = getAllMailsQuerie;
            this.getMailByIdQuerie = getMailByIdQuerie;
            this.getAllTemplateQuerie = getAllTemplateQuerie;
            this.createMailingUserCommand = createMailingUserCommand;
            this.deleteMailingUserCommand = deleteMailingUserCommand;
            this.getMailingUserByMailingIdQuery = getMailingUserByMailingIdQuery;
            this.getuserByIdQuery = getuserByIdQuery;
            this.getUsersItemsQuery = getUsersItemsQuery;
        }

        #endregion
        #region Index
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(MailingUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(MailingUtilsResource.HomeNavigationTitle)
                .Save();

            return View(getAllMailsQuerie.Execute());
        }
        #endregion
        #region Add
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            var model = new MailingViewModel()
            {
                CreateModel = new CreateMailingModel(),
                //Templates = EnumHelper<EnumTemplateType>.ToSelectList(),
                Templates = PopulateTemplates(),
                ActionTypes = EnumHelper<EnumAction>.ToSelectList(),
                NotificationTypes = EnumHelper<EnumNotificationType>.ToSelectList(),
                UsersItemModel = getUsersItemsQuery.Execute(),
            };
            return View(model);
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add(MailingViewModel model)
        {
            BreadcrumbForAdd();

            var Users = model.UsersItemModel;

            try
            {
                var _mail = model.CreateModel;
                model.CreateModel.UsersId = model.UsersItemModel.Where(i => i.IsSelected).Select(i => i.Id).ToList();
                createMailCommand.Execute(_mail);




            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);

            }

            model.Templates = PopulateTemplates(model.CreateModel.TemplateId);
            model.NotificationTypes = EnumHelper<EnumNotificationType>.ToSelectList(model.CreateModel.Type.ToString());
            model.ActionTypes = EnumHelper<EnumAction>.ToSelectList(model.CreateModel.Action.ToString());


            //model.ActionTypes = PopulateTemplates(model.CreateModel.Action.ToString());
            return View(model);
        }


        #endregion

        #region Edit

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
                var result = getMailByIdQuerie.Execute(Id);
                var model = new MailingViewModel()
                {
                    UpdateModel = result,
                    Templates = PopulateTemplates(result.TemplateId),
                    ActionTypes = EnumHelper<EnumAction>.ToSelectList(result.Action.ToString()),
                    NotificationTypes = EnumHelper<EnumNotificationType>.ToSelectList(result.Type.ToString()),
                    UsersItemModel = PopulateUsers(result.UsersId),
                };
                BreadcrumbForEdit(result.TableName);
                return View(model);
            }
            catch (NotFoundException)
            {
                return View("NotFound");
            }




        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(MailingViewModel model)
        {
            BreadcrumbForEdit(model.UpdateModel.Name);

            try
            {
                model.UpdateModel.UsersId = model.UsersItemModel
                    .Where(i => i.IsSelected)
                    .Select(i => i.Id).ToList();

                updateMailCommand.Execute(model.UpdateModel);





            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);

            }
            model.Templates = PopulateTemplates(model.UpdateModel.TemplateId);
            model.NotificationTypes = EnumHelper<EnumNotificationType>.ToSelectList(model.UpdateModel.Type.ToString());
            model.ActionTypes = EnumHelper<EnumAction>.ToSelectList(model.UpdateModel.Action.ToString());
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
                    var mail = getMailByIdQuerie.Execute(id);
                    model.Args.Add(mail.Id);
                    model.Args.Add(Url.Action("Delete", "mails"));
                    model.Args.Add("mail");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, BaseResource.Name);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, mail.Action);
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
                    deleteMailCommand.Execute(new DeleteMailingModel { Id = id });
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
        private List<UserItemModel> PopulateUsers(List<string> UsersId)
        {
            //var MailingUseritems = getMailingUserByMailingIdQuery.Execute(MailingId);

            var UsersItems = getUsersItemsQuery.Execute();
            foreach (var item in UsersId)
            {
                var entity = getuserByIdQuery.Execute(item);

                UsersItems.Find(p => p.Id == entity.Id).IsSelected = true;

            }

            return UsersItems;
        }
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(MailingUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem("Mail", Url.Action("Index", "Mails"))
               .AddItem(MailingUtilsResource.AddNewNavigationTitle)
               .Save();
        }

        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(MailingUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem("Mails", Url.Action("Index", "Mails"))
               .AddItem(string.Format(MailingUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }


        private SelectList PopulateTemplates(string selected = null)
        {
            var EmailTemplates = getAllTemplateQuerie.Execute().Where(m => m.Type == EnumTemplateType.Email);

            return new SelectList(EmailTemplates, "Id", "Name", selected);
        }


        #endregion
    }
}