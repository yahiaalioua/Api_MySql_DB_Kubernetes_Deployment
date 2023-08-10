using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using product_api.Brokers;
using product_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace product_db.Unit.Tests.Persistance
{
    public class SqLiteStorageBroker
    {
        private const string InMemoryConnectionString = "Data Source=LocalDatabase.db";
        private readonly SqliteConnection _connection;

        protected readonly StorageBroker _sqlLiteStorageBroker;
       

        protected SqLiteStorageBroker()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<StorageBroker>()
                    .UseSqlite(_connection)
                    .Options;
            _sqlLiteStorageBroker = new StorageBroker(options);
            _sqlLiteStorageBroker.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
