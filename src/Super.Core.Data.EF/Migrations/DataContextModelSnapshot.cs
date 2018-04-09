﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Super.Core.Data.EF;
using System;

namespace Super.Core.Data.EF.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Super.Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("PhotoUrl");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Super.Core.Entities.ProductList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ProductLists");
                });

            modelBuilder.Entity("Super.Core.Entities.ProductListProduct", b =>
                {
                    b.Property<Guid>("ProductListId");

                    b.Property<Guid>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("ProductListId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductListProduct");
                });

            modelBuilder.Entity("Super.Core.Entities.ProductStorePrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("StoreId");

                    b.Property<DateTimeOffset>("ValidFrom");

                    b.Property<DateTimeOffset?>("ValidTo");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("Super.Core.Entities.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.Property<string>("Name");

                    b.Property<Guid>("StoreChainId");

                    b.HasKey("Id");

                    b.HasIndex("StoreChainId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Super.Core.Entities.StoreChain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("StoreChains");
                });

            modelBuilder.Entity("Super.Core.Entities.ProductListProduct", b =>
                {
                    b.HasOne("Super.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Super.Core.Entities.ProductList")
                        .WithMany("ProductListProducts")
                        .HasForeignKey("ProductListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Super.Core.Entities.ProductStorePrice", b =>
                {
                    b.HasOne("Super.Core.Entities.Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Super.Core.Entities.Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Super.Core.Entities.Store", b =>
                {
                    b.HasOne("Super.Core.Entities.StoreChain")
                        .WithMany("Stores")
                        .HasForeignKey("StoreChainId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
