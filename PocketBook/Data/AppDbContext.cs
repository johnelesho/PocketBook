using Microsoft.EntityFrameworkCore;
using PocketBook.Models;

namespace PocketBook.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options): base(options) { }
         public DbSet<User> Users { get; set; } 
    }

 
}
