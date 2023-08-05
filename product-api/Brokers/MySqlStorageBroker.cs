using Microsoft.EntityFrameworkCore;
using product_api.Models;
using System.Xml;

namespace product_api.Brokers
{
    public class MySqlStorageBroker : DbContext
    {
        private readonly IConfiguration _configuration;
        public MySqlStorageBroker(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_configuration.GetConnectionString("DbConnStr")!);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .Property<int>("Id")
            .ValueGeneratedOnAdd();
        }
    }
}
