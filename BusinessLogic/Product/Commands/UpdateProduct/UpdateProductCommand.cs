using MediatR;
using OpenAPI.Repository;

namespace OpenAPI.BusinessLogic.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public int? Category { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Models.Entity.Product()
            {
                Id = request.Id,
                Category = request.Category,
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Quantity = request.Quantity
            };

            _productRepository.Update(entity);

            await _productRepository.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
