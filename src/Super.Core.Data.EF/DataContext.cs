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

            modelBuilder.Entity<ProductListProduct>()
                .HasKey(x => new { x.ProductListId, x.ProductId });

            modelBuilder.Entity<ProductList>()
                .HasMany(x => x.ProductListProducts)
                .WithOne()
                .HasForeignKey(x => x.ProductListId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<ProductListProduct>()
            //    .HasOne<ProductList>()
            //    .WithMany(x => x.ProductListProducts)
            //    .HasForeignKey(x => x.ProductListId);

            modelBuilder.Entity<Product>()
                .HasMany<ProductListProduct>()
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            //modelBuilder.Entity<ProductListProduct>()
            //    .HasOne(x => x.Product)
            //    .WithMany()
            //    .HasForeignKey(x => x.ProductId);
        }
    }
}
