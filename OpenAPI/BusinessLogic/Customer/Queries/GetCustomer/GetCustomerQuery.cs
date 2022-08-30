using MediatR;
using OpenAPI.Repository;

namespace OpenAPI.BusinessLogic.Customer.Queries.GetCustomer
{
    public record GetCustomerQuery : IRequest<GetCustomerQueryVm> {
        public int Id { get; set; }
    }


    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerQueryVm>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<GetCustomerQueryVm> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(request.Id);
            return new GetCustomerQueryVm
            {
                Id = customer?.Id == null ? 0 : customer.Id,
                Name = customer?.Name,
                Address = customer?.Address
            };
        }
    }
}
