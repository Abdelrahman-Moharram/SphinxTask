
using Microsoft.EntityFrameworkCore;
using SpinxTask.Core.Configurations;
using SpinxTask.Core.Models;

namespace SpinxTask.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ClientConfigurations().Configure(modelBuilder.Entity<Client>());
            new ProductConfigurations().Configure(modelBuilder.Entity<Product>());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Client> Clients { get; set; }  
        public DbSet<ClientProduct> ClientProducts { get; set; }  

        public DbSet<Class> Classes { get; set; }
        public DbSet<State> States { get; set; }


    }
}
