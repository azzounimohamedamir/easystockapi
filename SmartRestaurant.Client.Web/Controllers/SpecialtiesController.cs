using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Commun.Specialites.Commands.Create;
using SmartRestaurant.Application.Commun.Specialites.Commands.Delete;
using SmartRestaurant.Application.Commun.Specialites.Commands.Update;
using SmartRestaurant.Application.Commun.Specialites.Queries.GetSpecialityById;
using SmartRestaurant.Application.Commun.Specialites.Queries.GetSpecialtiesBySpecifications;
using SmartRestaurant.Application.Commun.Specialites.Queries.GetSpecialtiesList;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Commun;
using SmartRestaurant.Resources.Commun.Specialities;
using SmartRestaurant.Resources.Utils;
using System;

namespace SmartRestaurant.Client.Web.Controllers
{
    // [Area("Admin")]
    [Route("commun/specialites")]
    public class SpecialtiesController : AdminBaseController
    {
        private readonly ICreateSpecialityCommand createSpecialityCommand;
        private readonly IUpdateSpecialityCommand updateSpecialityCommand;
        private readonly IDeleteSpecialityCommand deleteSpecialityCommand;
        private readonly IGetSpecialityListQuery getSpecialityListQuery;
        private readonly IGetSpecialityBySpecificationQuery getSpecialityBySpecification;
        private readonly IGetSpecialityByIdQuery getSpecialityByIdQuery;

        public SpecialtiesController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<SpecialtiesController> log,
            ICreateSpecialityCommand createSpecialityCommand,
            IUpdateSpecialityCommand updateSpecialityCommand,
            IDeleteSpecialityCommand deleteSpecialityCommand,
            IGetSpecialityListQuery getSpecialityListQuery,
            IGetSpecialityBySpecificationQuery getSpecialityBySpecification,
            IGetSpecialityByIdQuery getSpecialityByIdQuery)
            : base(configuration, mailing, notify, baselog)
        {
            this.createSpecialityCommand = createSpecialityCommand;
            this.updateSpecialityCommand = updateSpecialityCommand;
            this.deleteSpecialityCommand = deleteSpecialityCommand;
            this.getSpecialityListQuery = getSpecialityListQuery;
            this.getSpecialityBySpecification = getSpecialityBySpecification;
            this.getSpecialityByIdQuery = getSpecialityByIdQuery;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb
                .AddHome()
                .AddItem(CommunResource.HomeNavigationTitle, Url.Action("Index", "Communs", new { area = "admin" }))
                .AddItem(SpecialityUtilsResource.HomeNavigationTitle)
                .SetTitle(SpecialityUtilsResource.HomePageTitle)
                .Save();

            return View(getSpecialityListQuery.Execute());
        }

        /// <summary>
        /// Breadcrumb de la page Add
        /// </summary>
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb
               .AddHome()
               .AddItem(CommunResource.HomeNavigationTitle, Url.Action("Index", "Communs", new { area = "admin" }))
               .AddItem(SpecialityUtilsResource.HomeNavigationTitle, Url.Action("Index", "Specialites", new { area = "admin" }))
               .AddItem(SpecialityUtilsResource.AddNewNavigationTitle)
               .SetTitle(SpecialityUtilsResource.AddPageTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name="name"></param>
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb
               .AddHome()
               .AddItem(CommunResource.HomeNavigationTitle, Url.Action("Index", "Communs", new { area = "admin" }))
               .AddItem(SpecialityUtilsResource.HomeNavigationTitle, Url.Action("Index", "Specialites", new { area = "admin" }))
               .AddItem(string.Format(SpecialityUtilsResource.EditNavigationTitle, name), null)
               .SetTitle(SpecialityUtilsResource.EditPageTitle)
               .Save();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            var model = new CreateSpecialityModel();
            return View(model);
        }

        [HttpPost]
        [Route("add")]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CreateSpecialityModel model)
        {
            try
            {
                createSpecialityCommand.Execute(model);
                return RedirectToAction("Index");
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }
            BreadcrumbForAdd();
            return View(model);
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
                var model = getSpecialityByIdQuery.Execute(id);
                BreadcrumbForEdit(model.Name);
                return View(model);
            }
            catch (NotFoundException)
            {
                return View("NotFound");
            }

        }

        [HttpPost]
        [Route("edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateSpecialityModel model)
        {
            try
            {
                updateSpecialityCommand.Execute(model);
                return RedirectToAction("Index");
            }
            catch (NotFoundException)
            {
                return View("NotFound");
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }
            BreadcrumbForEdit(model.Name);
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
                    var speciality = getSpecialityByIdQuery.Execute(id);
                    model.Args.Add(speciality.Id);
                    model.Args.Add(Url.Action("Delete", "Specialites"));
                    model.Args.Add("speciality");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, SpecialityUtilsResource.TableName);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, speciality.Name);
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
                    deleteSpecialityCommand.Execute(new DeleteSpecialityModel { Id = id });
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
