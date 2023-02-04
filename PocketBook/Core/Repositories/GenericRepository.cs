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
        }
        public async Task<bool> Add(T entity)
        {
             await _dbSet.AddAsync(entity);
            return true;
        }

        public Task<bool> Delete(Guid id)
        {
          fineFindById(id);
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await  _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
