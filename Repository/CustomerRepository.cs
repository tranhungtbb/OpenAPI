using OpenAPI.Models.Entity;

namespace OpenAPI.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// thêm các method khác tại đây
        /// 

    }
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}
