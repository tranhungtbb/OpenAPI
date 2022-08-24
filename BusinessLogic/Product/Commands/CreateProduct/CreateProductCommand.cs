using MediatR;
using OpenAPI.Repository;

namespace OpenAPI.BusinessLogic.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public int? Category { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Models.Entity.Product() {
                Category = request.Category,
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Quantity = request.Quantity
            };

            await _productRepository.AddAsync(entity);

            await _productRepository.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}