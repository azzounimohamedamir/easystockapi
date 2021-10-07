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
        [Authorize(Roles = "FoodBusinessManager,SupportAgent")]
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
        [Authorize(Roles = "FoodBusinessManager,SupportAgent")]
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
        [Authorize(Roles = "FoodBusinessManager,SupportAgent")]
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
        [Authorize(Roles = "FoodBusinessManager,SupportAgent")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            return await SendWithErrorsHandlingAsync(new GetProductByIdQuery { Id = id });
        }

        /// <summary> GetListOfProducts() </summary>
        /// <remarks>This endpoint allows <b>restaurant manager</b> to fetch list of products.</remarks>
        /// <param name="currentFilter">Products list can be filtred by: <b>name</b> | <b>description</b> | <b>price</b> | <b>energeticvalue</b>. Default value is: <b>name</b></param>
        /// <param name="searchKey">Search keyword</param>
        /// <param name="sortOrder">Products list can be sorted by: <b>acs</b> | <b>desc</b>. Default value is: <b>acs</b></param>
        /// <param name="comparisonOperator">
        ///     If the currentFilter is a numeric value, we can applay the following operators on products list:
        ///     <b>==</b> | <b>!=</b> | <b>&#62;</b> | <b>&#62;=</b> | <b>&#60;</b> | <b>&#60;=</b>. Default value is: <b>==</b>
        /// </param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> Product details has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch product details is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(PagedListDto<ProductDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent")]
        public async Task<IActionResult> GetList(string currentFilter, string searchKey, string sortOrder, string comparisonOperator, int page, int pageSize)
        {
            var query = new GetProductListQuery
            {
                CurrentFilter = currentFilter,
                SearchKey = searchKey,
                SortOrder = sortOrder,
                Page = page,
                PageSize = pageSize,
                ComparisonOperator = comparisonOperator
            };
            return await SendWithErrorsHandlingAsync(query);
        }
    }
}