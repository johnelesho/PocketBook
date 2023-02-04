using PocketBook.Core.IRepositories;
using PocketBook.Data;
using PocketBook.Models;
using System.Linq.Expressions;

namespace PocketBook.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context, ILogger lo) : base(context, lo)
        {
        }

        public Task<string> GetFirstNameAndLastName(Guid id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<User>> FindAll()
        {
            try
            {
                return await base.FindAll();
            }catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} FindAll Method Error", typeof(UserRepository));
                return Enumerable.Empty<User>();

            }
        }

        public override Task<bool> Add(User entity)
        {
            return base.Add(entity);
        }

        public async override Task<bool> Delete(Guid id)
        {
            try
            {
                var user = await FindById(id);
                if (user is not null)
                {
                    _dbSet.Remove(user);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete Method Error", typeof(UserRepository));
                return false;
            }
        }

        public override Task<User> FindById(Guid id)
        {
            return base.FindById(id);
        }

        public override async Task<bool> Update(User entity)
        {
            try
            {
                var user = await FindById(entity.Id);
                if (user is null)
                {
                    await _dbSet.AddAsync(entity);
                    return true;
                }
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Email = entity.Email;

                return true;
            }
            catch(Exception ex){
                _logger.LogError(ex, "{Repo} Update Method Error", typeof(UserRepository));
                return false;

            }

        }
    }
}
