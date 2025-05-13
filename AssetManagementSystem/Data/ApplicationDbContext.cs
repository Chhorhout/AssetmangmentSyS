using AssetManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
     : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<User> Users { get; internal set; }
        public DbSet<Maintainer> Maintainers { get; internal set; }
    }
}
