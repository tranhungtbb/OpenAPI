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


    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, IEnumerable<GetListProductQueryVm>>
    {
        private readonly IAppReadDbContext _appReadDbContext;
        public GetListProductQueryHandler(IAppReadDbContext appReadDbContext)
        {
            _appReadDbContext = appReadDbContext;
        }
        public async Task<IEnumerable<GetListProductQueryVm>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string querry = "[GetListProduct]";
                return (await _appReadDbContext.QueryStoreAsync<GetListProductQueryVm>(querry, new { GetListProductParam = request.ToDataTable() }));
            }
            catch (Exception ex)
            {
                return new List<GetListProductQueryVm>();
            }

        }
    }
}
