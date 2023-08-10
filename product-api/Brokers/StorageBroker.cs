using Microsoft.EntityFrameworkCore;
using product_api.Models;
using System.Xml;

namespace product_api.Brokers
{
    public  class StorageBroker : DbContext
    {
        public StorageBroker(DbContextOptions options) : base(options) { }     
        

        public DbSet<Product> Products { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .Property<int>("Id")
            .ValueGeneratedOnAdd();
        }
    }
}
