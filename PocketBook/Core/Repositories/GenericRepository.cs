using Microsoft.EntityFrameworkCore;
using PocketBook.Core.IRepositories;
using PocketBook.Data;

namespace PocketBook.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AppDbContext _context;
        protected DbSet<T> _dbSet;

        protected readonly ILogger _logger;

        public GenericRepository(AppDbContext context, ILogger lo
            ) {
            _context = context;
            _logger= lo;
            _dbSet = context.Set<T>();
        }
        public virtual async Task<bool> Add(T entity)
        {
             await _dbSet.AddAsync(entity);
     
            return true;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
          var t = await FindById(id);
            if (t is null)
            {
                return false;
            }
            _dbSet.Remove(t);
            return true;
        }

        public virtual async Task<IEnumerable<T>> FindAll()
        {
            return await  _dbSet.ToListAsync();
        }

        public virtual async Task<T> FindById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
