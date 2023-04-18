using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Illness.Commands;
using SmartRestaurant.Application.Illness.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/illness")]
    [ApiController]
    public class IlnessesController :  ApiController
    {
        /// <summary> This endpoint is used to create an Illness </summary>
        /// <remarks>
        ///     1- This endpoint allows <b>Support Agent</b> to create Illness.
        ///     <br></br>
        /// </remarks>
        /// <param name="command">This is Json object user create Illness</param>
        /// <response code="204">The Illness has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create an Illness is invalid.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        public async Task<IActionResult> Create(CreateIllnessCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> This endpoint is used to create an Illness User </summary>
        /// <remarks>
        ///     1- This endpoint allows <b>FoodBusinessManager</b> or  <b>Diner</b> to create IllnessUser.
        ///     <br></br>
        /// </remarks>
        /// <param name="command">This is Json object user create Illness</param>
        /// <response code="204">The IllnessUser has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create an IllnessUser is invalid.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
        [Route("illnessuser")]

        [Authorize(Roles = "FoodBusinessManager,Diner,Waiter,HotelClient")]
        public async Task<IActionResult> CreateIlnessUser(CreateIllnessUserCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        



        /// <summary> This endpoint is used to update an Illness </summary>
        /// <remarks>
        ///     1- This endpoint allows <b>Support Agent</b> to update Illness.
        ///     <br></br>
        /// </remarks>
        /// <param name="id">id of the illness that would be updated</param>
        /// <param name="command">This is Json object user update Illness</param>
        /// <response code="204">The Illness has been successfully update.</response>
        /// <response code="400">The payload data sent to the backend-server in order to update an Illness is invalid.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Route("{id}")]
        [HttpPut]
        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        public async Task<IActionResult> Update([FromRoute] string id, UpdateIllnessCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> This endpoint is used to List Illnesses </summary>
        /// <remarks>This endpoint allows us to fetch list of illnesses.</remarks>
        /// <param name="currentFilter">illnesses list can be filtred by: <b>name</b></param>
        /// <param name="searchKey">Search keyword</param>
        /// <param name="sortOrder">illnesses list can be sorted by: <b>acs</b> | <b>desc</b>. Default value is: <b>acs</b></param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> illnesses list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch illnesses list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(PagedListDto<IllnessDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin,Diner,Waiter,HotelClient")]
        [HttpGet]
        public Task<IActionResult> GetList(string currentFilter, string searchKey, string sortOrder, int page, int pageSize)
        {
            var query = new GetIllnessesListQuery
            {
                CurrentFilter = currentFilter,
                SearchKey = searchKey,
                SortOrder = sortOrder,
                Page = page,
                PageSize = pageSize,
            };
            return SendWithErrorsHandlingAsync(query);
        }

        /// <summary> This endpoint is used to get Illness by id </summary>
        /// <remarks>This endpoint allows us to fetch Illness details.</remarks>
        /// <param name="id">id of the Illness that would be used to fetch Illness details</param>
        /// <response code="200"> Illness details has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch Illness details is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(IllnessDto), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin,Waiter")]
        public Task<IActionResult> Get([FromRoute] string id)
        {
            return SendWithErrorsHandlingAsync(new GetIllnessByIdQuery { Id = id });
        }

        /// <summary> This endpoint is used to delete Illness  </summary>
        /// <remarks>This endpoint allows <b>Support Agent</b> to delete illness.</remarks>
        /// <param name="id">id of the illness that would be deleted</param>
        /// <response code="204">The illness has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a illness is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]

        [Route("{id}")]
        [HttpDelete]
        [Authorize(Roles = "SupportAgent,SuperAdmin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteIllnessCommand { Id = id });
        }
        /// <summary> This endpoint is used to Get the corresponding illness of ingridient in a liste of deshes </summary>
        /// <remarks>
        ///     1- This endpoint allows <b>FoodBusinessManager ,SupportAgent,FoodBusinessAdministrator,SuperAdmin</b> to Query the Illness of dishes ingredients.
        ///     <br></br>
        /// </remarks>
        /// <param name="command">This is Json object containe the ids of deshes and the ids of illess</param>
        /// <response code="204">The Illness has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to Query Illness is invalid.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(IList<DishIllnessDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [ProducesResponseType(typeof(ExceptionResponse), 401)]
        [ProducesResponseType(typeof(ExceptionResponse), 403)]
        [HttpPost]
        [Route("disheillness")]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin,Diner,Waiter")]
        public async Task<IActionResult> GetDeshesIllness(GetDishesIllnessQuery command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        /// <summary> This endpoint is used to Get the corresponding illness of ingridient in a liste of deshes grouping with ingredients </summary>
        /// <remarks>
        ///     1- This endpoint allows <b>FoodBusinessManager ,SupportAgent,FoodBusinessAdministrator,SuperAdmin</b> to Query the Illness of dishes ingredients.
        ///     <br></br>
        /// </remarks>
        /// <param name="command">This is Json object containe the ids of deshes and the ids of illess</param>
        /// <response code="400">The payload data sent to the backend-server in order to Query Illness is invalid.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(IList<DishIllnessDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [ProducesResponseType(typeof(ExceptionResponse), 401)]
        [ProducesResponseType(typeof(ExceptionResponse), 403)]
        [HttpPost]
        [Route("warningingredentOrder")]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin,Diner,Waiter,HotelClient")]
        public async Task<IActionResult> WarningIngredentOrder(GetWarningIngredientOfOrderWithIllnessQuery command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }






        /// <summary> This endpoint is used to Get the corresponding illness of ingridient in a liste of deshes grouping with ingredients (SmartRestaurant Web )  </summary>
        /// <remarks>
        ///     1- This endpoint allows <b>FoodBusinessManager ,SupportAgent,FoodBusinessAdministrator,SuperAdmin</b> to Query the Illness of dishes ingredients.
        ///     <br></br>
        /// </remarks>
        /// <param name="command">This is Json object containe the ids of deshes</param>
        /// <response code="400">The payload data sent to the backend-server in order to Query Illness is invalid.</response>
        /// <response code="401">
        ///     The cause of 401 error is one of two reasons: Either the user is not logged into the application
        ///     or authentication token is invalid or expired.
        /// </response>
        /// <response code="403">
        ///     The user account you used to log into the application, does not have the necessary privileges to
        ///     execute this request.
        /// </response>
        [ProducesResponseType(typeof(WarningIngredientOfOrder), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [ProducesResponseType(typeof(ExceptionResponse), 401)]
        [ProducesResponseType(typeof(ExceptionResponse), 403)]
        [HttpPost]
        [Route("warningingredentOrderWeb")]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,FoodBusinessAdministrator,SuperAdmin,Diner,Waiter,HotelClient")]
        public async Task<IActionResult> WarningIngredentOrderWeb(GetWarningIngredientOfOrderWithIllnessWebQuery command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> This endpoint is used to List of illness by logged User </summary>
        /// <remarks>This endpoint allows us to fetch list of illness by logged User .</remarks>
        /// <param name="currentFilter">illnesses list can be filtred by: <b>illnessId</b></param>
        /// <param name="searchKey">Search keyword</param>
        /// <param name="sortOrder">illnesses list can be sorted by: <b>acs</b> | <b>desc</b>. Default value is: <b>acs</b></param>
        /// <param name="page">The start position of read pointer in a request results. Default value is: <b>1</b></param>
        /// <param name="pageSize">The max number of Reservations that should be returned. Default value is: <b>10</b>. Max value is: <b>100</b></param>
        /// <response code="200"> illnesses list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch illnesses list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>

        [Route("illnessesOfuser")]
        [ProducesResponseType(typeof(PagedListDto<IllnessUserDto>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [Authorize(Roles = "FoodBusinessManager,Diner,Waiter,HotelClient")]
        [HttpGet]
        public Task<IActionResult> GetAlreadyCheckedIlness(string currentFilter, string searchKey, string sortOrder, int page, int pageSize)
        {
            var query = new GetIlnessessbyUserQuery
            {
                CurrentFilter = currentFilter,
                SearchKey = searchKey,
                SortOrder = sortOrder,
                Page = page,
                PageSize = pageSize,
            };
            return SendWithErrorsHandlingAsync(query);
        }
    }
}
