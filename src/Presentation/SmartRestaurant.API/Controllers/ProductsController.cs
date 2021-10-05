using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Products.Commands;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Products menu item")]
    public class ProductsController : ApiController
    {
        /// <summary> CreateNewProduct() </summary>
        /// <remarks>
        ///     This endpoint allows <b>restaurant manager</b> to create a new product.The product is a menu item that can be a drink, dessert, snack...etc. 
        ///     You can not set <b>Section Id</b> and <b>SubSection Id</b> at the same time. you must set one property only because
        ///     the product can not be assigned to a Section and Sub-section at the same time.
        /// </remarks>
        /// <param name="command">This is payload object used to create a new product</param>
        /// <response code="204">The product has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new product is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Create([FromForm] CreateProductCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
     
    }
}