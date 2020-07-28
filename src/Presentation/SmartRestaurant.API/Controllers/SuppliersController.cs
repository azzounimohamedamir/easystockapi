using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Suppliers.Commands;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult> Create(CreateSupplierCommand command)
        {
            var validationResult =  await Mediator.Send(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);

        }
        [HttpPut]
        public async Task<ActionResult> Update(UpdateSupplierCommand command)
        {
            var validationResult = await Mediator.Send(command).ConfigureAwait(false);
            return ApiCustomResponse(validationResult);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteSupplierCommand { SupplierId = id }).ConfigureAwait(false);
            return NoContent();
        }
    }
}