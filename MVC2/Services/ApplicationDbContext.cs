using MVC2.Models.Entities;
using Microsoft.EntityFrameworkCore;
using MVC2.Models;

namespace MVC2.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Reports> Reports => Set<Reports>();
        public DbSet<Player> Players => Set<Player>();

        public DbSet<Health> Teams => Set<Health>();
       
    }
}
