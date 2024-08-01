using Microsoft.EntityFrameworkCore;
using miniStore.Data.Entities;
using System;
using System.Collections.Generic;

using System.Text;

namespace miniStore.Data.EF
{
    public class miniStoreContext : DbContext
    {
        public miniStoreContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
