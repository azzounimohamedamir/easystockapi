
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Hotels.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Application.Common.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using SmartRestaurant.Application.Hotels.Queries;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.API.Swagger.Exception;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Hotels")]
    public class HotelsController : ApiController
    {


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




        [Route("byFoodBusinessAdministrator")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent,SuperAdmin,FoodBusinessManager")]
        public Task<IActionResult> GetListOfHotelsByFoodBusinessAdministratorId()
        {
            return SendWithErrorsHandlingAsync(new GetHotelsListByAdmin());
        }






        [Route("byFoodBusinessManager")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,SupportAgent,SuperAdmin")]
        public Task<IActionResult> GetAllHotelsByFoodBusinessManager()
        {
            return SendWithErrorsHandlingAsync(new GetAllHotelsByFoodBusinessManagerQuery());
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


        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
       [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<IActionResult> Create([FromForm]CreateHotelCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
    }



   

}
