using Microsoft.EntityFrameworkCore;
using OpenAPI.Models.Entity;

namespace OpenAPI.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<T> AddAsync(T entity);
        void Update(T entity);
        Task<T?> DeleteAsync(int Id);
        Task<T?> GetAsync(int id);
        List<T> GetAll();

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }

    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context) {
            this._context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }


        public async Task<T?> DeleteAsync(int Id)
        {
            var entity = await _context.FindAsync<T>(Id);
            _context.Set<T>().Remove(entity);
            return entity;
        }

       
        public async Task<T?> GetAsync(int id)
        {
            return await _context.FindAsync<T>(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
