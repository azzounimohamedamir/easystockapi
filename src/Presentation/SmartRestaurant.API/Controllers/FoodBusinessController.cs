using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusiness.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Authorize]
    [Route("api/foodbusiness")]
    [ApiController]
    public class FoodBusinessController : ApiController
    {
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent")]
        public Task<IActionResult> Get(int page, int pageSize)
        {
            return SendWithErrorsHandlingAsync(new GetFoodBusinessListQuery {Page = page, PageSize = pageSize});
        }

        [Route("byFoodBusinessAdministrator")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public Task<IActionResult> GetByFoodBusinessAdministratorId()
        {
            return SendWithErrorsHandlingAsync(new GetFoodBusinessListByAdmin());
        }

        [Route("byFoodBusinessManager")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager")]
        public Task<IActionResult> GetAllFoodBusinessByFoodBusinessManager()
        {
            return SendWithErrorsHandlingAsync(new GetAllFoodBusinessByFoodBusinessManagerQuery());
        }

        [Route("{id:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager,FoodBusinessOwner,SupportAgent")]
        public Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return SendWithErrorsHandlingAsync(new GetFoodBusinessByIdQuery {FoodBusinessId = id});
        }

        [HttpPost]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent")]
        public async Task<IActionResult> Create(CreateFoodBusinessCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent")]
        public async Task<IActionResult> Update(UpdateFoodBusinessCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "FoodBusinessAdministrator,SupportAgent")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteFoodBusinessCommand {Id = id});
        }    

        [HttpPatch("updateFourDigitCode")]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> UpdateFourDigitCode(UpdateFourDigitCodeCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpGet("getFourDigitCode")]
        [Authorize(Roles = "FoodBusinessAdministrator,FoodBusinessManager")]
        public async Task<IActionResult> GetFourDigitCode(GetFourDigitCodeFoodBusinessByIdQuery command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
    }
}