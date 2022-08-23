using Microsoft.EntityFrameworkCore;
using OpenAPI.Models.Entity;

namespace OpenAPI.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        int Add (T entity);
        int Update (T entity);
        int Delete (T entity);
        Task<T> Get (int id);
        Task<List<T>> GetAll();

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }

    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context) {
            this._context = context;
        }

        public int AddAsync(T entity)
        {
            return _context.Set<T>().AddAsync(entity);
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
