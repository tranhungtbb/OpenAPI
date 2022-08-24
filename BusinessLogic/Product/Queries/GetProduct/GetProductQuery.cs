using MediatR;
using OpenAPI.Repository;

namespace OpenAPI.BusinessLogic.Product.Queries.GetProduct
{
    public record GetProductQuery : IRequest<GetProductQueryVm> {
        public int Id { get; set; }
    }


    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductQueryVm>
    {
        private readonly IProductRepository _productRepository;
        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<GetProductQueryVm> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetAsync(request.Id);
            return new GetProductQueryVm
            {
                Id = result == null || result.Id == null ? 0 : result.Id,
                Name = result.Name,
                Quantity = result.Quantity,
                Description = result.Description,
                Category = result.Category
            };
        }
    }
}
