using System.Threading.Tasks;

using SmartRestaurant.Application.Hotels.Commands;
using Microsoft.AspNetCore.Mvc;using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using SmartRestaurant.Application.Hotels.Queries;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.API.Swagger.Exception;
using System;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Hotels")]
    public class HotelsController : ApiController
    {



        /// <summary> GetListOfHotels() </summary>
        /// <remarks>This endpoint allows us to fetch list of hotels.</remarks>
        /// <param name="currentFilter">hotels list can be filtred by: <b>name</b></param>
        /// <param name="searchKey">Search keyword</param>
        /// <param name="sortOrder">Hotels list can be sorted by: <b>acs</b> | <b>desc</b>. Default value is: <b>acs</b></param>
        /// <param name="Id">If the Id is set, we will get hotels list linked to that Id else we will get an empty list.</param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> hotels list has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch hotels list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(PagedListDto<HotelDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,HotelManager,HotelClient")]

        [HttpGet]
        public Task<IActionResult> GetList(string Id, string currentFilter, string searchKey, string sortOrder, int page, int pageSize)
        {
            var query = new GetHotelsListQuery
            {
                CurrentFilter = currentFilter,
                SearchKey = searchKey,
                SortOrder = sortOrder,
                Page = page,
                PageSize = pageSize
            };
            return SendWithErrorsHandlingAsync(query);
        }


        /// <summary> GetListOfHotelsBydmin() </summary>
        /// <remarks>This endpoint allows us to fetch list of hotels of Current Administrator </remarks>
        /// <response code="200"> hotels list has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch hotels list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [Route("byFoodBusinessAdministrator")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent,SuperAdmin,FoodBusinessManager")]
        public Task<IActionResult> GetListOfHotelsByFoodBusinessAdministratorId()
        {
            return SendWithErrorsHandlingAsync(new GetHotelsListByAdmin());
        }




        /// <summary> GetListOfHotelsByFoodBusinessManager() </summary>
        /// <remarks>This endpoint allows us to fetch list of hotels of Current FoodBusinessManager </remarks>
        /// <response code="200"> hotels list has been successfully fetched.<br></br><b>Note:</b> Picture will be encoded in Base64</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch hotels list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [Route("byFoodBusinessManager")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,SuperAdmin,HotelServiceAdmin,HotelServiceTechnique")]
        public Task<IActionResult> GetAllHotelsByFoodBusinessManager()
        {
            return SendWithErrorsHandlingAsync(new GetAllHotelsByFoodBusinessManagerQuery());
        }



        /// <summary> UpdateHotel() </summary>
        /// <remarks>
        ///     This endpoint allows SM user to update hotel.<br></br>
        ///     <b>Note 01:</b> Picture should be encoded in Base64
        /// </remarks>
        /// <param name="id">id of the hotel that would be updated</param>
        /// <param name="command">This is the payload object used to update hotel</param>
        /// <response code="204">The hotel has been successfully updated.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update a hotel is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [Route("{id}")]
        [HttpPut]
       [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromForm] UpdateHotelCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> DeleteHotel() </summary>
        /// <remarks>This endpoint allows <b>Food Business Administrator</b> to delete hotel.</remarks>
        /// <param name="id">id of the hotel that would be deleted</param>
        /// <response code="204">The hotel has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a hotel is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteHotelCommand { Id = id });
        }


        /// <summary> CreateNewHotel() </summary>
        /// <remarks>
        ///     This endpoint allows user to create a new hotel.<br></br>
        ///     <b>Note 01:</b> Picture should be encoded in Base64
        /// </remarks>
        /// <param name="command">This is the payload object used to create a new hotel</param>
        /// <response code="204">The hotel has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new hotel is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
       [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<IActionResult> Create([FromForm]CreateHotelCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


         /// <summary> GetHotelByIdQuery() </summary>
        /// <remarks>This endpoint allows us to fetch Hotel of Current Administrator </remarks>
        /// <param name="id">Id of Hotel</param>
        /// <response code="200"> Hotel has been successfully fetched.</response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch Hotel is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent,SuperAdmin,Diner,Organization,Waiter,HotelClient,HotelServiceAdmin,HotelServiceTechnique")]
        public Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return SendWithErrorsHandlingAsync(new GetHotelByIdQuery { Id = id });
        }
    }



   

}
