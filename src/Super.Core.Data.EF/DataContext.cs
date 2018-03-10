using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Super.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Data.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductList> ProductLists { get; set; }

        public DbSet<ProductPrice> Prices { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<StoreChain> StoreChains { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
