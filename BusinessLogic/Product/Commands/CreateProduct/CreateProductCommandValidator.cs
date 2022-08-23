using FluentValidation;
using OpenAPI.Repository;
using System.Linq;

namespace OpenAPI.BusinessLogic.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IRepository<Models.Entity.Product> _context;

        public CreateProductCommandValidator(IRepository<Models.Entity.Product> context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        }

        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return (await _context.GetAll()).Exists(l => l.Name != title);
        }
    }
}
