using MediatR;
using OpenAPI.Repository;

namespace OpenAPI.BusinessLogic.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Models.Entity.Customer()
            {
                Id = request.Id,
                Address = request.Address,
                Name = request.Name
            };

            _customerRepository.Update(entity);

            await _customerRepository.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
