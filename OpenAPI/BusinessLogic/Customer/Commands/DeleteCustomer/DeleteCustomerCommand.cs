using MediatR;
using OpenAPI.Repository;

namespace OpenAPI.BusinessLogic.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<int?>
    {
        public int Id { get; set; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, int?>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int?> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _customerRepository.DeleteAsync(request.Id);

            await _customerRepository.SaveChangesAsync(cancellationToken);

            return entity?.Id;
        }
    }
}
