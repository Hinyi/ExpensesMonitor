﻿// <auto-generated />
using System;
using ExpensesMonitor.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExpensesMonitor.Infrastructure.EF.Migrations
{
    [DbContext(typeof(ShoppingListDbContext))]
    [Migration("20230628123553_Init_2")]
    partial class Init_2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("shopping")
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ExpensesMonitor.Domain.Entities.ShoppingList", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ShoppingList", "shopping");
                });

            modelBuilder.Entity("ExpensesMonitor.Domain.ValueObjects.ProductList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ShoppingListId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("ProductList", "shopping");
                });

            modelBuilder.Entity("ExpensesMonitor.Domain.ValueObjects.ProductList", b =>
                {
                    b.HasOne("ExpensesMonitor.Domain.Entities.ShoppingList", null)
                        .WithMany("_items")
                        .HasForeignKey("ShoppingListId");
                });

            modelBuilder.Entity("ExpensesMonitor.Domain.Entities.ShoppingList", b =>
                {
                    b.Navigation("_items");
                });
#pragma warning restore 612, 618
        }
    }
}
