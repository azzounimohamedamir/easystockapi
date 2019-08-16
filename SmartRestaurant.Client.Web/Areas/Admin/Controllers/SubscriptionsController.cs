using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Resources.Subscriptions.Subscription;

namespace SmartRestaurant.Client.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/subscriptions")]
    public class SubscriptionsController : AdminBaseController
    {
        private readonly ILoggerService<SubscriptionsController> _log;

        public SubscriptionsController(
            IConfiguration configuration, 
            IMailingService mailing, 
            INotifyService notify, 
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<SubscriptionsController> log) : base(configuration, mailing, notify, baselog)
        {
            _log = log;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb
                .SetTitle(SubscriptionUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(SubscriptionUtilsResource.HomeNavigationTitle)
                .Save();

            return View();
        }

        
        [Route("SoonToExpire")]
        public IActionResult SoonToExpire()
        {
            this.PageBreadcrumb
                .SetTitle(SubscriptionUtilsResource.SoonToExpirePageTitle)
                .AddHome()
                .AddItem(SubscriptionUtilsResource.HomeNavigationTitle, Url.Action("Index", "Subscriptions"))
                .AddItem(SubscriptionUtilsResource.SoonToExpireNavigationTitle)
                .Save();

            return View();
        }

        //Expired
        [Route("Expired")]
        public IActionResult Expired()
        {
            this.PageBreadcrumb.SetTitle(SubscriptionUtilsResource.ExpiredPageTitle)
                .AddHome()
                .AddItem(SubscriptionUtilsResource.HomeNavigationTitle, Url.Action("Subscriptions", "Index"))
                .AddItem(SubscriptionUtilsResource.ExpiredNavigationTitle)
                .Save();

            return View();
        }

        //ReNew
        [Route("Renewal")]
        public IActionResult Renewal()
        {
            this.PageBreadcrumb.SetTitle(SubscriptionUtilsResource.RenewalPageTitle)
                .AddHome()
                .AddItem(SubscriptionUtilsResource.HomeNavigationTitle, Url.Action("Subscriptions", "Index"))
                .AddItem(SubscriptionUtilsResource.RenewalNavigationTitle)
                .Save();

            return View();
        }
    }
}