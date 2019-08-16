using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Mails.Commands.Create;
using SmartRestaurant.Application.Mails.Commands.Delete;
using SmartRestaurant.Application.Mails.Commands.Update;
using SmartRestaurant.Application.Mails.Queries.GelMailingItems;
using SmartRestaurant.Application.Mails.Queries.GetMailingById;
using SmartRestaurant.Application.Notifications.Commands.Create;
using SmartRestaurant.Application.Notifications.Commands.Delete;
using SmartRestaurant.Application.Notifications.Commands.Update;
using SmartRestaurant.Application.Notifications.Queries;
using SmartRestaurant.Application.Notifications.Queries.GetNotificationById;
using SmartRestaurant.Application.Notifications.Queries.GetNotificationItems;
using SmartRestaurant.Application.Templates.Queries.GetTemplateItems;
using SmartRestaurant.Application.Users.Queries;
using SmartRestaurant.Application.Users.Queries.GetUserById;
using SmartRestaurant.Application.Users.Queries.GetUsersitems;
using SmartRestaurant.Client.Web.Extensions;
using SmartRestaurant.Client.Web.Models.Mails;
using SmartRestaurant.Client.Web.Models.Notification;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Domain.Enumerations;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Mailing;
using SmartRestaurant.Resources.Notification;
using SmartRestaurant.Resources.Utils;

namespace SmartRestaurant.Client.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/notifications")]
    [Route("{culture?}/admin/notifications")]
    public class NotificationsController : AdminBaseController
    {
        #region PrivatesFields
        private readonly ICreateNotificationCommand createNotificationCommand;
        private readonly IUpdateNotificationCommand updateNotificationCommand;
        private readonly IDeleteNotificationCommand deleteNotificationCommand;
        private readonly IGetNotificationItemsQuery getAllNotificationQuerie;
        private readonly IGetNotificationByIdQuerie getNotificationByIdQuerie;
        private readonly IGetUsersItemsQuery getUsersItemsQuery;
        private readonly IGetUserByIdQuery getUserByIdQuery;
        private readonly IGetAllTemplateQuerie getAllTemplateQuerie;
        #endregion
        #region Constructor
        public NotificationsController(
          IConfiguration configuration,
          IMailingService mailing,
          INotifyService notify,
          ICreateNotificationCommand createNotificationCommand,
          IUpdateNotificationCommand updateNotificationCommand,
          IDeleteNotificationCommand deleteNotificationCommand,
          IGetNotificationItemsQuery getAllNotificationQuerie,
          IGetNotificationByIdQuerie getNotificationByIdQuerie,
          IGetUsersItemsQuery getUsersItemsQuery,
          IGetUserByIdQuery getUserByIdQuery,
         
          IGetAllTemplateQuerie getAllTemplateQuerie,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<NotificationsController> log) :
            base(configuration, mailing, notify, baselog)
        {
            this.createNotificationCommand = createNotificationCommand;
            this.updateNotificationCommand = updateNotificationCommand;
            this.deleteNotificationCommand = deleteNotificationCommand;
            this.getAllNotificationQuerie = getAllNotificationQuerie;
            this.getNotificationByIdQuerie = getNotificationByIdQuerie;
            this.getUsersItemsQuery = getUsersItemsQuery;
            this.getUserByIdQuery = getUserByIdQuery;
            this.getAllTemplateQuerie = getAllTemplateQuerie;
        }
        #endregion
        #region Index
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(NotificationUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(NotificationUtilsResource.HomeNavigationTitle)
                .Save();

            var test = getAllNotificationQuerie.Execute();
          
            return View(test);
        }
        #endregion
        #region Add
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            var model = new NotificationViewModel()
            {
                CreateModel = new CreateNotificationModel(),
                Templates = PopulateTemplates(),
                ActionTypes = EnumHelper<EnumAction>.ToSelectList(),
                NotificationTypes = EnumHelper<EnumNotificationType>.ToSelectList(),
                UsersItemModel = getUsersItemsQuery.Execute(),
            };
            return View(model);
        }
      

        [HttpPost]
        [Route("add")]
        public IActionResult Add(NotificationViewModel model)
        {
            BreadcrumbForAdd();
            try
            {
                var _notification = model.CreateModel;
                model.CreateModel.UsersId = model.UsersItemModel.Where(i => i.IsSelected).Select(i => i.Id).ToList();
                createNotificationCommand.Execute(_notification);
                //command.Execute(model);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);

            }
            model.Templates = PopulateTemplates(model.CreateModel.TemplateId);
            model.NotificationTypes = EnumHelper<EnumNotificationType>.ToSelectList(model.CreateModel.Type.ToString());
            model.ActionTypes = EnumHelper<EnumAction>.ToSelectList(model.CreateModel.Action.ToString());
          
            //Templates = PopulateEnum<EnumTemplateType>(),
            //    ActionTypes = PopulateEnum<EnumAction>() ,
            //    NotificationTypes = PopulateEnum<EnumNotificationType>(),
            return View(model);
        }

        #endregion
        #region Edit
        [HttpGet]
        [Route("edit")]
        public IActionResult Edit(string Id)
        {
            if ( String.IsNullOrEmpty(Id))
            {
                return View("NotFound");
            }
            try
            {
                var result = getNotificationByIdQuerie.Execute(Id);
                var model = new NotificationViewModel()
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
      
        public IActionResult Edit(NotificationViewModel model)
        {
            BreadcrumbForEdit(model.UpdateModel.Name);

            try
            {

                model.UpdateModel.UsersId = model.UsersItemModel
                        .Where(i => i.IsSelected)
                        .Select(i => i.Id).ToList();
                updateNotificationCommand.Execute(model.UpdateModel);
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
                    var notification = getNotificationByIdQuerie.Execute(id);
                    model.Args.Add(notification.Id);
                    model.Args.Add(Url.Action("Delete", "notifications"));
                    model.Args.Add("notification");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, BaseResource.Name);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, notification.Action);
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
                    deleteNotificationCommand.Execute(new DeleteNotificationModel { Id = id });
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
        #region Private Method
        private List<UserItemModel> PopulateUsers(List<string> UsersId)
        {
            //var MailingUseritems = getMailingUserByMailingIdQuery.Execute(MailingId);

            var UsersItems = getUsersItemsQuery.Execute();
            foreach (var item in UsersId)
            {
                var entity = getUserByIdQuery.Execute(item);

                UsersItems.Find(p => p.Id == entity.Id).IsSelected = true;

            }

            return UsersItems;
        }
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(NotificationUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem("Notification", Url.Action("Index", "Notifications"))
               .AddItem(NotificationUtilsResource.AddNewNavigationTitle)
               .Save();
        }

        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(NotificationUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem("Notification", Url.Action("Index", "Notifications"))
               .AddItem(string.Format(NotificationUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }


        private SelectList PopulateTemplates(string selected = null)
        {
            var NotificationTemplates = getAllTemplateQuerie.Execute().Where(m => m.Type == EnumTemplateType.Notification);

            return new SelectList(NotificationTemplates, "Id", "Name", selected);
        }


        #endregion

    }
}