using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using product_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace product_db.Unit.Tests.Persistance
{
    public class SqlLiteStorageBroker:DbContext
    {
        private readonly IConfiguration _configuration;

        public SqlLiteStorageBroker(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("testingDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .Property<int>("Id")
            .ValueGeneratedOnAdd();
        }
    }
}
