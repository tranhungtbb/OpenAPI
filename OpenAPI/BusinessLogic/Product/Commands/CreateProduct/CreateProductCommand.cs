using Dapper;
using DbContextHelper.WriteDbContext;
using MediatR;
using OpenAPI.Repository;
using System.Data;

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
        private readonly IAppWriteDbContext _appWriteDbContext;

        public CreateProductCommandHandler(IProductRepository productRepository, IAppWriteDbContext appWriteDbContext)
        {
            _productRepository = productRepository;
            _appWriteDbContext = appWriteDbContext;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new
            {
                Category = request.Category,
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Quantity = request.Quantity
            };
            using (var conn = _appWriteDbContext.GetConnection())
            using (var trans = _appWriteDbContext.BeginTransaction())
            {
                try
                {
                    int result = await _appWriteDbContext.ExecuteScalarStoreAsync<int>("Proc_ProductInsert", entity, trans);
                    await _appWriteDbContext.CommitAsync();
                    return result;
                }
                catch (Exception ex)
                {
                    await _appWriteDbContext.RollbackAsync();
                    return -1;
                }

            }
        }
    }
}