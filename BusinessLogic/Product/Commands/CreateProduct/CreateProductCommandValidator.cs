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

            RuleFor(v => v.Price)
                .NotEmpty().WithMessage("Price is required.");

            RuleFor(v => v.Category)
                .NotEmpty().WithMessage("Category is required.");
        }

        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return _context.GetAll().Exists(l => l.Name != title);
        }
    }
}
