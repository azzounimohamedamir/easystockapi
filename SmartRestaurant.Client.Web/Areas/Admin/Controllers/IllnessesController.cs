using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Create;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Delete;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Update;
using SmartRestaurant.Application.Allergies.Illnesses.Services;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Foods.Queries.GetAll;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Models.Allergies;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Allergies.Illnesses;
using SmartRestaurant.Resources.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/Illnesses")]
    public class IllnessesController : AdminBaseController
    {
        private readonly ILoggerService<IllnessesController> _log;
        private readonly IIllnessService IllnessesService;
        private readonly IGetAllFoodsQuery getAllFoods;

        public IllnessesController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            IGetAllFoodsQuery getAllFoods,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<IllnessesController> log,
           
            IIllnessService IllnessesService
            //IHostingEnvironment hostingEnvironnement
            )
            : base(configuration, mailing, notify, baselog)
        {
            _log = log;
            this.IllnessesService = IllnessesService;
            this.getAllFoods = getAllFoods;
            //_hostingEnvironnement = hostingEnvironnement;
        }

        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(IllnessUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(IllnessUtilsResource.HomeNavigationTitle, Url.Action("Illnesses", "Index"))
                .Save();

            return View(IllnessesService.Queries.List.Execute());
        }


        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {

            var model = new IllnessViewModel
            {
                Foods = GetFoods()
            };

            return View(model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(IllnessViewModel model)
        {
            BreadcrumbForAdd();
             try
            {
                IllnessesService.Create.Execute(model.CreateModel);
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
                var result = IllnessesService.Queries.GetById.Execute(id);
                var model = new IllnessViewModel
                {
                    UpdateModel = result,
                    Foods = GetFoods(),
                    SelectedFoods=GetSelectedFoods(result.FoodsIdsNames)
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
        public IActionResult Edit(IllnessViewModel model)
        {
             BreadcrumbForEdit(model.UpdateModel.Name);
            try
            {
                IllnessesService.Update.Execute(model.UpdateModel);
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
                    var entity = IllnessesService.Queries.GetById.Execute(id);
                    model.Args.Add(entity.Id);
                    model.Args.Add(Url.Action("Delete", "Illnesses"));
                    model.Args.Add("Illness");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, IllnessResource.Illness);
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
                    IllnessesService.Delete.Execute(new DeleteIllnessModel { Id = id });
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
            this.PageBreadcrumb.SetTitle(IllnessUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(IllnessUtilsResource.HomePageTitle, Url.Action("Index", "Illnesses"))
               .AddItem(IllnessUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name="name"></param>
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(IllnessUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(IllnessUtilsResource.HomePageTitle, Url.Action("Index", "Illnesses"))
               .AddItem(string.Format(IllnessUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        private SelectList GetFoods( )
        {
            return new SelectList(getAllFoods.Execute(), "Id", "Name");
        }
        #endregion
    }
}
