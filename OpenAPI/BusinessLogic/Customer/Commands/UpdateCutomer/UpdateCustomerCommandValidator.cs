using FluentValidation;
using OpenAPI.Repository;

namespace OpenAPI.BusinessLogic.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(v => v.Id)
               .NotEmpty().WithMessage("Id is required.");

            RuleFor(v => v.Name)
               .NotEmpty().WithMessage("Name is required.")
               .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");
        }
    }
}
