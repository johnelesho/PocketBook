using Microsoft.AspNetCore.Mvc;

namespace PocketBook.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class 
    {
        
        Task<IEnumerable<T>> FindAll();
        Task<IEnumerable<T>> FindById(Guid id);

        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
    }
}
