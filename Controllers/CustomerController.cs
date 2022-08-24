using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenAPI.Controllers.BaseController;
using OpenAPI.BusinessLogic.Customer.Commands.UpdateCustomer;
using OpenAPI.BusinessLogic.Customer.Commands.DeleteCustomer;
using OpenAPI.BusinessLogic.Customer.Queries.GetListCustomer;
using OpenAPI.BusinessLogic.Customer.Queries.GetCustomer;
using OpenAPI.BusinessLogic.Customer.Commands.CreateCutomer;

namespace OpenAPI.Controllers
{
    //[Authorize]
    public class CustomerController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCutomerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, UpdateCustomerCommand command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int?>> Delete(int id)
        {
            return await Mediator.Send(new DeleteCustomerCommand() { Id = id });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerQueryVm>> Detail(int id)
        {
            return await Mediator.Send(new GetCustomerQuery() { Id = id });
        }

        [HttpGet("GetList")]
        public async Task<ActionResult<List<GetListCustomerQueryVm>>> GetList()
        {
            return await Mediator.Send(new GetListCustomerQuery());
        }

    }
}
