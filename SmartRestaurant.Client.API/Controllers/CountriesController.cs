using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Client.API.Extension;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartRestaurant.Client.API.Controllers
{
    [Route("api/commun/geo/countries")]
    [Route("api/{culture}/commun/geo/countries")]
    public class CountriesController : SRBaseController
    {
        // GET: api/commun/geo/countries
        // GET: api/{culture}/commun/geo/countries        
        [HttpGet]
        public IActionResult Get()
        {
            var culture = CultureOnUri;
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }
            var data = GetCountries();
            int currentPage = page;
            int currentPageSize = pageSize;
            var totalSchedules = data.Count();
            var totalPages = (int)Math.Ceiling((double)totalSchedules / pageSize);

            Response.AddPagination(page, pageSize, totalSchedules, totalPages);

            var result = data
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();
            return new OkObjectResult(result);
        }

        // GET api/commun/geo/countries/5        
        // GET api/{culture}/commun/geo/countries/5        
        [HttpGet("{id}")]
        public string Get(int id, string culture = null)
        {
            return $"value {culture}";
        }

        // POST api/commun/geo/countries        
        // POST api/{culture}/commun/geo/countries        
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/commun/geo/countries/5        
        // PUT api/{culture}/commun/geo/countries/5        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/commun/geo/countries/5        
        // DELETE api/{culture}/commun/geo/countries/5        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
