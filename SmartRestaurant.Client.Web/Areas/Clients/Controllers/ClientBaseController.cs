using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetBySlugUrl;
using SmartRestaurant.Client.Web.Controllers;
using SmartRestaurant.Client.Web.Models;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Client.Web.Areas.Clients.Controllers
{
    [Area("Clients")]
    //[Authorize(Roles = "Owner")]
    public class ClientBaseController : SRBaseController
    {
        protected readonly string areaName = "clients";
        private readonly ILoggerService<ClientBaseController> _baselog;
        private readonly IGetRetaurantBySlugUrlQuery getRetaurantBySlugUrlQuery;

        public ClientBaseController(IConfiguration configuration,
                                    IMailingService mailing,
                                    INotifyService notify,
                                    ILoggerService<ClientBaseController> baselog,
                                    IGetRetaurantBySlugUrlQuery getRetaurantBySlugUrlQuery) : base(configuration, mailing, notify)
        {
            _baselog = baselog;
            this.getRetaurantBySlugUrlQuery = getRetaurantBySlugUrlQuery ?? throw new ArgumentNullException(nameof(getRetaurantBySlugUrlQuery));
            PageBreadcrumb = new BreadcrumbViewModel { Controller = this };
        }

        protected RestaurantItemModel Restaurant
        {
            get
            {
                if (RouteData.Values["restaurant"] != null)
                {
                    var restaurant = getRetaurantBySlugUrlQuery.Execute(RouteData.Values["restaurant"].ToString());
                    if (restaurant != null)
                    {
                        return restaurant;
                    }
                    return null;
                }
                return null;
            }
        }
        
    }
}