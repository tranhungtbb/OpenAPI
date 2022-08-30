using Dapper;
using DbContextHelper.Common;
using DbContextHelper.ReadDbContext;
using MediatR;
using OpenAPI.Repository;
using System.Data;

namespace OpenAPI.BusinessLogic.Product.Queries.GetListProduct
{
    public record GetListProductQuery : IRequest<List<GetListProductQueryVm>>
    {
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public int? Category { get; set; }
    }


    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, List<GetListProductQueryVm>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IAppReadDbContext _appReadDbContext;
        public GetListProductQueryHandler(IProductRepository productRepository, IAppReadDbContext appReadDbContext)
        {
            _productRepository = productRepository;
            _appReadDbContext = appReadDbContext;
        }
        public async Task<List<GetListProductQueryVm>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string querry = "[GetListProduct]";
                return (await _appReadDbContext.QueryStoreAsync<GetListProductQueryVm>(querry, new { GetListProductParam = request.ToDataTable() })).ToList();
            }
            catch (Exception ex)
            {
                return new List<GetListProductQueryVm>();
            }

        }
    }
}
