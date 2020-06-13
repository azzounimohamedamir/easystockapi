using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Interfaces;

namespace SmartRestaurant.Client.Web.Controllers
{
   // [Area("Admin")]
    [Route("galleries")]
    public class GalleriesController : AdminBaseController
    {
        private readonly IConfiguration configuration;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ILoggerService<AdminBaseController> baselog;
        private readonly ILoggerService<GalleriesController> log;

        public GalleriesController(
            IConfiguration configuration, 
            IMailingService mailing, 
            INotifyService notify, 
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<GalleriesController> log) 
            : base(configuration, mailing, notify, baselog)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.mailing = mailing ?? throw new ArgumentNullException(nameof(mailing));
            this.notify = notify ?? throw new ArgumentNullException(nameof(notify));
            this.baselog = baselog ?? throw new ArgumentNullException(nameof(baselog));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}