using MediatR;
using OpenAPI.Repository;

namespace OpenAPI.BusinessLogic.Customer.Commands.CreateCutomer
{
    public class CreateCutomerCommand : IRequest<int>
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
    }

    public class CreateCutomerCommandHandler : IRequestHandler<CreateCutomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCutomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> Handle(CreateCutomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Models.Entity.Customer() {
                Address = request.Address,
                Name = request.Name
            };

            await _customerRepository.AddAsync(entity);

            await _customerRepository.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}