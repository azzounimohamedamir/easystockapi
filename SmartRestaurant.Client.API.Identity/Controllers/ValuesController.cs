using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SmartRestaurant.Client.API.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{culture:?}/{id:int}", Name = "byId", Order = 1)]
        public ActionResult<string> Get(string culture, [FromBody] int id)
        {
            return Ok($"value: {id} {culture}");
        }

        // GET api/values/5        
        [HttpGet("{name}", Name = "byName", Order = 1)]
        public ActionResult<string> Get(string name)
        {
            return Ok($"value: {name}");
        }

        // POST api/values
        [HttpPost]

        public void Post([FromBody] string name)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromQuery] int id,
                        [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
