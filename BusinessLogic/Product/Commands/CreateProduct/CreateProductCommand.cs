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

    public class CreateTodoListCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IRepository<OpenAPI.Models.Entity.Product> _context;

        public CreateTodoListCommandHandler(IRepository<OpenAPI.Models.Entity.Product> context)
        {
            _context = context;
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

            _context.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}