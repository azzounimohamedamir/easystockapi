using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Products.Commands;
using SmartRestaurant.Application.Products.Queries;
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

        /// <summary> UpdateProduct() </summary>
        /// <remarks>This endpoint allows <b>restaurant manager</b> to update a product. The product is a menu item that can be a drink, dessert, snack...etc. </remarks>
        /// <param name="id">id of the product that would be updated</param>
        /// <param name="command">This is payload object used to update a product</param>
        /// <response code="204">The product has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a product is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromForm] UpdateProductCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> DeleteProduct() </summary>
        /// <remarks>This endpoint allows <b>restaurant manager</b> to delete a product.</remarks>
        /// <param name="id">id of the product that would be deleted</param>
        /// <response code="204">The product has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a product is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpDelete]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteProductCommand { Id = id});
        }

        /// <summary> GetProductDetails() </summary>
        /// <remarks>This endpoint allows <b>restaurant manager</b> to fetch product details.</remarks>
        /// <param name="id">id of the product that would be used to fetch product details</param>
        /// <response code="200"> Product details has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch product details is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ProductDto), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            return await SendWithErrorsHandlingAsync(new GetProductByIdQuery { Id = id });
        }
    }
}