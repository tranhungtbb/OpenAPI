using OpenAPI.Models.Entity;

namespace OpenAPI.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        /// thêm các method khác tại đây
        /// 
        
    }
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}
