using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Resources.Billing;

namespace SmartRestaurant.Client.Web.Controllers
{
    //[Route("admin/billing")]
    [Route("{culture}/billing")]
    public class BillingController : AdminBaseController
    {
        private readonly ILoggerService<BillingController> _log;

        public BillingController(
            IConfiguration configuration, 
            IMailingService mailing, 
            INotifyService notify, 
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<BillingController> log) : base(configuration, mailing, notify, baselog)
        {
            _log = log;
        }

        //[Route("")]
        //[Route("index")]
        public IActionResult Index()
        {
            this.PageBreadcrumb                
               .AddHome()
               .AddItem(BillingUtilsResource.HomeNavigationTitle)
               .SetTitle(BillingUtilsResource.HomePageTitle)
               .Save();
            return View();
        }

        #region Invoices
        //[Route("invoices")]
        public IActionResult Invoices()
        {
            this.PageBreadcrumb
               .AddHome()
               .AddItem(BillingUtilsResource.HomeNavigationTitle, Url.Action("Index", "Billing"))
               .AddItem(BillingUtilsResource.InvoicesNavigationTitle)
               .SetTitle(BillingUtilsResource.InvoicesPageTitle)
               .Save();
            return View();
        }

        //[Route("addinvoices")]
        public IActionResult AddInvoice()
        {
            this.PageBreadcrumb
               .AddHome()
               .AddItem(BillingUtilsResource.HomeNavigationTitle, Url.Action("Index", "Billing"))
               .AddItem(BillingUtilsResource.InvoicesNavigationTitle, Url.Action("Invoices", "Billing"))
               .AddItem(BillingUtilsResource.AddInvoiceNavigationTitle)
               .SetTitle(BillingUtilsResource.AddInvoicePageTitle)
               .Save();
            return View();
        }
        #endregion

        #region Quotations
        [Route("quotations")]
        public IActionResult Quotations()
        {
            this.PageBreadcrumb
               .AddHome()
               .AddItem(BillingUtilsResource.HomeNavigationTitle, Url.Action("Index", "Billing"))
               .AddItem(BillingUtilsResource.QuotationsNavigationTitle)
               .SetTitle(BillingUtilsResource.QuotationsPageTitle)
               .Save();
            return View();
        }

        [Route("addquotation")]
        public IActionResult AddQuotation()
        {
            this.PageBreadcrumb
               .AddHome()
               .AddItem(BillingUtilsResource.HomeNavigationTitle, Url.Action("Index", "Billing"))
               .AddItem(BillingUtilsResource.QuotationsNavigationTitle, Url.Action("Quotations", "Billing"))
               .AddItem(BillingUtilsResource.AddQuotationNavigationTitle)
               .SetTitle(BillingUtilsResource.AddQuotationPageTitle)
               .Save();
            return View();
        }
        #endregion
    }
}