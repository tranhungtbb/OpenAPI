using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenAPI.Controllers.BaseController;
using OpenAPI.BusinessLogic.Product.Commands.CreateProduct;
using OpenAPI.BusinessLogic.Product.Commands.UpdateProduct;
using OpenAPI.BusinessLogic.Product.Commands.DeleteProduct;
using OpenAPI.BusinessLogic.Product.Queries.GetListProduct;
using OpenAPI.BusinessLogic.Product.Queries.GetProduct;
using NSwag.Annotations;

namespace OpenAPI.Controllers
{
    //[Authorize]
    public class ProductController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, UpdateProductCommand command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int?>> Delete(int id)
        {
            return await Mediator.Send(new DeleteProductCommand() { Id = id });
        }

        [HttpGet("detail{id}")]
        public async Task<ActionResult<GetProductQueryVm>> Detail(int id)
        {
            return await Mediator.Send(new GetProductQuery() { Id = id });
        }

        [HttpGet("GetList")]
        [ResponseType(typeof(IEnumerable<GetListProductQueryVm>))]
        public async Task<ActionResult<IEnumerable<GetListProductQueryVm>>> GetList()
        {
            return await Mediator.Send(new GetListProductQuery());
        }

    }
}
