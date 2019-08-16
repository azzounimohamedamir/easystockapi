using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SmartRestaurant.Client.API.Models;

namespace SmartRestaurant.Client.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRBaseController : ControllerBase
    {
        protected int page = 1;
        protected int pageSize = 4;
        protected string _culture = "fr-FR";
        protected IEnumerable<CountryViewModel> GetCountries()
        {
            var result = new List<CountryViewModel>();
            for (int i = 0; i < 25; i++)
            {
                result.Add(new CountryViewModel
                {
                    Id=Guid.NewGuid().ToString(),
                    Name=$"Country {i}",
                });
            }
            return result;
        }

        protected string CultureOnUri
        {
            get
            {
                return RouteData.Values.ContainsKey("culture")
                                ? RouteData.Values["culture"].ToString()
                                : "fr-FR";
            }
         }
        
    }
}