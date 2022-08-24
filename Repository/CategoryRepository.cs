using OpenAPI.Models.Entity;

namespace OpenAPI.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        /// thêm các method khác tại đây
        /// 

    }
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}
