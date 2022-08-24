using MediatR;
using OpenAPI.Repository;

namespace OpenAPI.BusinessLogic.Customer.Queries.GetListCustomer
{
    public record GetListCustomerQuery : IRequest<List<GetListCustomerQueryVm>>;


    public class GetListCustomerQueryHandler : IRequestHandler<GetListCustomerQuery, List<GetListCustomerQueryVm>>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetListCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Task<List<GetListCustomerQueryVm>> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
        {
            var result = _customerRepository.GetAll().Select(x =>
                new GetListCustomerQueryVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address
                }).ToList();
            return Task.FromResult(result);
        }
    }
}
