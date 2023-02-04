using PocketBook.Core.IRepositories;
using PocketBook.Core.Repositories;
using PocketBook.IConfiguration;

namespace PocketBook.Data
{
    public class UnitofWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext context;
        private readonly ILogger logger;

        public UnitofWork(
            AppDbContext context,
            ILoggerFactory loggerFactory)
        {
            this.context = context;
            logger = loggerFactory.CreateLogger("logs");
            User = new UserRepository(context, logger);
        }

        public IUserRepository User { get; private set; }

        public async Task CompleteAsyn()
        {
            await context.SaveChangesAsync();
        }

        //public async Task Dispose()
        //{
        //    await context.DisposeAsync();
        //}

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
