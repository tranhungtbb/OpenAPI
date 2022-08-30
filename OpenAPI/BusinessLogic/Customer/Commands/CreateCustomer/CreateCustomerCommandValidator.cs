using FluentValidation;
using OpenAPI.Repository;
using System.Linq;

namespace OpenAPI.BusinessLogic.Customer.Commands.CreateCutomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCutomerCommand>
    {


        public CreateCustomerCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");
        }

    }
}
