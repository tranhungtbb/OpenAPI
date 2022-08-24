using FluentValidation;
using OpenAPI.Repository;

namespace OpenAPI.BusinessLogic.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(v => v.Id)
               .NotEmpty().WithMessage("Id is required.");

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
            return await Task.FromResult(_productRepository.GetAll().Exists(l => l.Name != title));
        }
    }
}
