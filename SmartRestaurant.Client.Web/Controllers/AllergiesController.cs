using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Delete;
using SmartRestaurant.Application.Allergies.Allergies.Services;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Foods.Queries.GetAll;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Models.Allergies;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Allergies.Allergies;
using SmartRestaurant.Resources.Utils;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Controllers
{
    //[Area("Admin")]
    //[Route("admin/commun/allergies")]
    public class AllergiesController : AdminBaseController
    {
        private readonly ILoggerService<AllergiesController> _log;
        private readonly IAllergyService AllergiesService;
        private readonly IGetAllFoodsQuery getAllFoods;

        public AllergiesController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            IGetAllFoodsQuery getAllFoods,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<AllergiesController> log,

            IAllergyService AllergiesService
            //IHostingEnvironment hostingEnvironnement
            )
            : base(configuration, mailing, notify, baselog)
        {
            _log = log;
            this.AllergiesService = AllergiesService;
            this.getAllFoods = getAllFoods;
            //_hostingEnvironnement = hostingEnvironnement;
        }

        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(AllergyUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(AllergyUtilsResource.HomeNavigationTitle, Url.Action("Allergies", "Index"))
                .Save();

            return View(AllergiesService.Queries.List.Execute());
        }


        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {

            var model = new AllergyViewModel
            {
                Foods = GetFoods()
            };

            return View(model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(AllergyViewModel model)
        {
            BreadcrumbForAdd();
            try
            {
                AllergiesService.Create.Execute(model.CreateModel);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }
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
                var result = AllergiesService.Queries.GetById.Execute(id);
                var model = new AllergyViewModel
                {
                    UpdateModel = result,
                    Foods = GetFoods(),
                    SelectedFoods = GetSelectedFoods(result.FoodsIdsNames)
                };
                BreadcrumbForEdit(result.Name);
                return View(model);
            }
            catch (NotFoundException)
            {
                return View("NotFound");
            }
        }

        private SelectList GetSelectedFoods(List<IdName> foodsIdsNames)
        {
            return new SelectList(foodsIdsNames, "Id", "Name");
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(AllergyViewModel model)
        {
            BreadcrumbForEdit(model.UpdateModel.Name);
            try
            {
                AllergiesService.Update.Execute(model.UpdateModel);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }

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
                    var entity = AllergiesService.Queries.GetById.Execute(id);
                    model.Args.Add(entity.Id);
                    model.Args.Add(Url.Action("Delete", "Allergies"));
                    model.Args.Add("Allergy");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, AllergyResource.Allergy);
                    model.Message = string.Format(UtilsResource.DeleteModalBodyMessage, entity.Name);
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
                    AllergiesService.Delete.Execute(new DeleteAllergyModel { Id = id });
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

        #region Methods

        /// <summary>
        /// Breadcrumb de la page Add
        /// </summary>
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(AllergyUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(AllergyUtilsResource.HomePageTitle, Url.Action("Index", "Allergies"))
               .AddItem(AllergyUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name="name"></param>
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(AllergyUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(AllergyUtilsResource.HomePageTitle, Url.Action("Index", "Allergies"))
               .AddItem(string.Format(AllergyUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        private SelectList GetFoods()
        {
            return new SelectList(getAllFoods.Execute(), "Id", "Name");
        }
        #endregion
    }
}
