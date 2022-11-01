
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


        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
       [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<IActionResult> Create([FromForm]CreateHotelCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
    }



   

}
