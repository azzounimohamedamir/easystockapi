using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Chains.Commands.Create;
using SmartRestaurant.Application.Restaurants.Chains.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Chains.Commands.Update;
using SmartRestaurant.Application.Restaurants.Chains.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Chains.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Chains.Queries.GetByOwnerId;
using SmartRestaurant.Application.Restaurants.Owners.Queries.GetAll;
using SmartRestaurant.Client.Web.Models.Restaurants;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Restaurants.Chains;
using SmartRestaurant.Resources.Utils;
using System;

namespace SmartRestaurant.Client.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/Chains")]
    public class ChainsController : AdminBaseController
    {
        private readonly ILoggerService<ChainsController> _log;
        private readonly ICreateChainCommand createCommand;
        private readonly IUpdateChainCommand updateCommand;
        private readonly IDeleteChainCommand deleteCommand;

        private readonly IGetChainByIdQuery getById;
        private readonly IGetChainsByOwnerIdQuery getByOwnerId;
        private readonly IGetAllOwnersQuery getAllOwners;
        private readonly IGetAllChainsQuery getAllChains;



        public ChainsController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<ChainsController> log,
            ICreateChainCommand createCommand,
            IUpdateChainCommand updateCommand,
            IDeleteChainCommand deleteCommand,
            IGetChainsByOwnerIdQuery getByOwnerId,
            IGetChainByIdQuery getById,
              IGetAllOwnersQuery getAllOwners,
              IGetAllChainsQuery getAllChains
            )
            : base(configuration, mailing, notify, baselog)
        {
            _log = log;
            this.createCommand = createCommand;
            this.updateCommand = updateCommand;
            this.deleteCommand = deleteCommand;
            this.getById = getById;
            this.getByOwnerId = getByOwnerId;
            this.getAllOwners = getAllOwners;
            this.getAllChains = getAllChains;
            //_hostingEnvironnement = hostingEnvironnement;
        }

        #region Index
        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(ChainUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(ChainUtilsResource.HomeNavigationTitle, Url.Action("Chains", "Index"))
                .Save();

            var result = new ChainItemViewModel
            {
                Owners = GetOwners(),
                Entities = getAllChains.Execute()
            };
            return View(result);
        }

        [HttpPost]
        [Route("")]
        [Route("index")]
        public IActionResult Index(ChainItemViewModel viewModel)
        {
            this.PageBreadcrumb.SetTitle(ChainUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(ChainUtilsResource.HomeNavigationTitle, Url.Action("Chains", "Index"))
                .Save();

            viewModel.Entities = getByOwnerId
                .Execute(viewModel.SelectedOwnerId);

             viewModel.Owners = GetOwners(viewModel.SelectedOwnerId);
            return View(viewModel);
        }
        #endregion

        #region Add
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            BreadcrumbForAdd();
            var model = new ChainViewModel
            {
                CreateModel = new CreateChainModel(),
            
                Owners = GetOwners()
            };
            return View(model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(ChainViewModel model)
        {
            BreadcrumbForAdd();
            try
            {
                createCommand.Execute(model.CreateModel);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }
            return RedirectToAction("index");
        }
        #endregion

        #region Edit
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
                var result = getById.Execute(id);
                BreadcrumbForEdit(result.Name);

                var viewModel = new ChainViewModel
                {
                    UpdateModel = result,
                     Owners = GetOwners(result.OwnerId)
                };
                return View(viewModel);
            }
            catch (NotFoundException)
            {
                return View("NotFound");
            }
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(ChainViewModel model)
        {
            BreadcrumbForEdit(model.UpdateModel.Name);
            try
            {
                updateCommand.Execute(model.UpdateModel);
            }
            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }

            return View(model);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Breadcrumb de la page Add
        /// </summary>
        private void BreadcrumbForAdd()
        {
            this.PageBreadcrumb.SetTitle(ChainUtilsResource.AddPageTitle)
               .AddHome()
               .AddItem(ChainUtilsResource.HomePageTitle, Url.Action("Index", "Chains"))
               .AddItem(ChainUtilsResource.AddNewNavigationTitle)
               .Save();
        }
        /// <summary>
        /// Breadcrumb de la page Edit
        /// </summary>
        /// <param name="name"></param>
        private void BreadcrumbForEdit(string name)
        {
            this.PageBreadcrumb.SetTitle(ChainUtilsResource.EditPageTitle)
               .AddHome()
               .AddItem(ChainUtilsResource.HomePageTitle, Url.Action("Index", "Chains"))
               .AddItem(string.Format(ChainUtilsResource.EditNavigationTitle, name), null)
               .Save();
        }

        private SelectList GetOwners(object selected = null)
        {
            return new SelectList(getAllOwners.Execute(), "Id", "FullName", selected);
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
                    var entity = getById.Execute(id);
                    model.Args.Add(entity.Id);
                    model.Args.Add(Url.Action("Delete", "Chains"));
                    model.Args.Add("Chain");

                    model.Title = string.Format(UtilsResource.DefaultDeleteEntityModalTitle, ChainResource.Chain);
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
                    deleteCommand.Execute(new DeleteChainModel { Id = id });
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
    }
}