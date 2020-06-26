using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Users.Commands;
using SmartRestaurant.Application.Users.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Web.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            return await Mediator.Send(new GetUsersListQuery());
        }

        [HttpGet("{id}")]
        public async Task<UserDto> GetById(Guid Id)
        {
            return await Mediator.Send(new GetUserByIdQuery { UserId = Id });
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateUserCommand command)
        {
            if (id != command.UserId)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteUserCommand { UserId = id });

            return NoContent();
        }
    }
}
