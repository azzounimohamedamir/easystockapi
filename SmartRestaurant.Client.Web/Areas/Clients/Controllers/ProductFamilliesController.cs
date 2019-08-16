using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetBySlugUrl;

namespace SmartRestaurant.Client.Web.Areas.Clients.Controllers
{
    [Area("Clients")]
    [Route("clients/products/famillies")]
    public class ProductFamilliesController : ClientBaseController
    {
        private readonly ILoggerService<ProductFamilliesController> log;

        public ProductFamilliesController(IConfiguration configuration,
                                          IMailingService mailing,
                                          INotifyService notify,
                                          ILoggerService<ClientBaseController> baselog,
                                          IGetRetaurantBySlugUrlQuery getRetaurantBySlugUrlQuery,
                                          ILoggerService<ProductFamilliesController> log) : base(configuration, mailing, notify, baselog, getRetaurantBySlugUrlQuery)
        {
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}