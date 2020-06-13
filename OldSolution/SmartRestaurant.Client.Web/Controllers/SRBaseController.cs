using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Models;
using System.Globalization;

namespace SmartRestaurant.Client.Web.Controllers
{
    //[Route("{language:regex(^[[a-z]]{{2}}(?:-[[A-Z]]{{2}})?$)}/[controller]")]
    //[Route("[controller]")]
    public class SRBaseController : Controller
    {
        protected int pageSize = 10;
        protected int itemCount;
        protected BreadcrumbViewModel PageBreadcrumb;

        //private static string _cookieLangName = "g22smartrestaurant";
        private string _twoLetterISOLanguageName;
        private string _currentLanguage;

        protected readonly IConfiguration _configuration;
        protected readonly IMailingService _mailing;
        protected readonly INotifyService _notify;
        
        public SRBaseController(IConfiguration configuration,
                                IMailingService mailing,
                                INotifyService notify)
        {
            _configuration = configuration;
            _mailing = mailing;
            _notify = notify;            
        }

        public CultureInfo AppCulture => new CultureInfo(CurrentLanguage);
        private string CurrentLanguage
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentLanguage))
                    return _currentLanguage;

                if (string.IsNullOrEmpty(_currentLanguage))
                {
                    var feature = HttpContext.Features.Get<IRequestCultureFeature>();
                    _currentLanguage = feature.RequestCulture.Culture.Name.ToLower();
                    _twoLetterISOLanguageName = feature.RequestCulture.Culture.TwoLetterISOLanguageName.ToLower();
                }
                return _currentLanguage;
            }
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //string cultureOnCookie = GetCultureOnCookie(context.HttpContext.Request);
            //string cultureOnURL = context.RouteData.Values.ContainsKey("culture")
            //    ? context.RouteData.Values["culture"].ToString()
            //    : GlobalHelper.DefaultCulture;

            if (CurrentLanguage.Length == 2)
            {
                switch (_currentLanguage)
                {
                    case "ar":
                        _currentLanguage = "ar-DZ";
                        break;
                    case "fr":
                        _currentLanguage = "fr-FR";
                        break;
                    case "en":
                        _currentLanguage = "en-US";
                        break;
                    case "es":
                        _currentLanguage = "es-ES";
                        break;
                }
            }
            SetCurrentCultureOnThread(_currentLanguage);
            base.OnActionExecuting(context);
        }

        //public static String GetCultureOnCookie(HttpRequestBase request)
        //{
        //    var cookie = request.Cookies[_cookieLangName];
        //    string culture = string.Empty;
        //    if (cookie != null)
        //    {
        //        culture = cookie.Value;
        //    }
        //    return culture;
        //}

        private void SetCurrentCultureOnThread(string culture)
        {
            if (string.IsNullOrEmpty(culture))
                culture = _configuration.GetValue<string>("DefaultCulture");

            var cultureInfo = new System.Globalization.CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;


        }

        protected void AddErrorToModelState(NotValidException ex)
        {
            foreach (var err in ex.Errors)
            {
                ModelState.AddModelError(err.PropertyName,err.ErrorMessage);
            }
        }

        

    }
}