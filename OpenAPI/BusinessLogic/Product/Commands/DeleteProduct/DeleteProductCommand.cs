using MediatR;
using OpenAPI.Repository;

namespace OpenAPI.BusinessLogic.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<int?>
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int?>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int?> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.DeleteAsync(request.Id);

            await _productRepository.SaveChangesAsync(cancellationToken);

            return entity?.Id;
        }
    }
}
