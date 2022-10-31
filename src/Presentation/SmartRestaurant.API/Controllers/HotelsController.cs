
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
