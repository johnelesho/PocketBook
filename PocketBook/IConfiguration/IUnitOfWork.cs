using PocketBook.Core.IRepositories;

namespace PocketBook.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }

        Task CompleteAsyn();
    }
}
