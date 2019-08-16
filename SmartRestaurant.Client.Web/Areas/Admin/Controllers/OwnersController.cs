using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Create;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Update;
using SmartRestaurant.Application.Restaurants.Owners.Services;
using SmartRestaurant.Client.Web.Areas.Admin.Controllers;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Restaurants.Owners;
using SmartRestaurant.Resources.Utils;

namespace SmartRestaurant.Client.Web.Owners.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/owners")]
    public class OwnersController : AdminBaseController
    {
        private readonly ILoggerService<OwnersController> _log;
        private readonly IOwnerService ownerService;

        public OwnersController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<OwnersController> log,
            IOwnerService areaService
            //IHostingEnvironment hostingEnvironnement
            )
            : base(configuration, mailing, notify, baselog)
        {
            _log = log;
            this.ownerService = areaService;
            //_hostingEnvironnement = hostingEnvironnement;
        }

        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(OwnerUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(OwnerUtilsResource.HomeNavigationTitle, Url.Action("Owners", "Index"))
                .Save();

            return View(ownerService.Queries.List.Execute());
        }

        /// <summary>
        /// Breadcrumb de la page Add
        /// </summary>
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(OwnerUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(OwnerUtilsResource.HomePageTitle, Url.Action("Index", "Owners"))
               .AddItem(OwnerUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name="name"></param>
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(OwnerUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(OwnerUtilsResource.HomePageTitle, Url.Action("Index", "Owners"))
               .AddItem(string.Format(OwnerUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            var model = new CreateOwnerModel();
            return View(model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(CreateOwnerModel model)
        {
            
            try
            {
                ownerService.Create.Execute(model);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }
            BreadcrumbForAdd();
            return RedirectToAction("index");
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
                var result = ownerService.Queries.GetById.Execute(id);
                BreadcrumbForEdit(result.FullName);
                return View(result);
            }
            catch (NotFoundException)
            {
                return View("NotFound");
            }
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(UpdateOwnerModel model)
        {
            
            try
            {
                ownerService.Update.Execute(model);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }
            BreadcrumbForEdit(model.FullName);
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
                    var entity = ownerService.Queries.GetById.Execute(id);
                    model.Args.Add(entity.Id);
                    model.Args.Add(Url.Action("Delete", "Owners"));
                    model.Args.Add("Owner");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, OwnerResource.Owner);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, entity.FullName);
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
                    ownerService.Delete.Execute(new DeleteOwnerModel { Id = id });
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