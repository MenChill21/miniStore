using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace miniStore.Data.EF
{
    public class miniStoreDbContextFactory : IDesignTimeDbContextFactory<miniStoreDbContext>
    {
        public miniStoreDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuration.GetConnectionString("miniStoreDb");

            var optionsBuilder = new DbContextOptionsBuilder<miniStoreDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new miniStoreDbContext(optionsBuilder.Options);
        }
    }
}
