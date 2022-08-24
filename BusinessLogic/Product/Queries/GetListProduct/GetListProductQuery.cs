using MediatR;
using OpenAPI.Repository;

namespace OpenAPI.BusinessLogic.Product.Queries.GetListProduct
{
    public record GetListProductQuery : IRequest<List<GetListProductQueryVm>> {

    }


    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, List<GetListProductQueryVm>>
    {
        private readonly IProductRepository _productRepository;
        public GetListProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<List<GetListProductQueryVm>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            var result = _productRepository.GetAll().Select(x =>
                new GetListProductQueryVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    Quantity = x.Quantity,
                    Category = x.Category
                }).ToList();
            return Task.FromResult(result);
        }
    }
}
