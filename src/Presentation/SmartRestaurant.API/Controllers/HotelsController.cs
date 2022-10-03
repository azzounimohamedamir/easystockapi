
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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


    }
}
