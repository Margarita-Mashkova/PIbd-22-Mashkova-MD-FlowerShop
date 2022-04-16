﻿// <auto-generated />
using System;
using FlowerShopDatabaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlowerShopDatabaseImplement.Migrations
{
    [DbContext(typeof(FlowerShopDatabase))]
    partial class FlowerShopDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FlowerShopDatabaseImplement.Models.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ComponentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("FlowerShopDatabaseImplement.Models.Flower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FlowerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Flowers");
                });

            modelBuilder.Entity("FlowerShopDatabaseImplement.Models.FlowerComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ComponentId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("FlowerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.HasIndex("FlowerId");

                    b.ToTable("FlowerComponents");
                });

            modelBuilder.Entity("FlowerShopDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateImplement")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlowerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FlowerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FlowerShopDatabaseImplement.Models.Storehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResponsibleFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StorehouseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Storehouses");
                });

            modelBuilder.Entity("FlowerShopDatabaseImplement.Models.StorehouseComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ComponentId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("StorehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.HasIndex("StorehouseId");

                    b.ToTable("StorehouseComponents");
                });

            modelBuilder.Entity("FlowerShopDatabaseImplement.Models.FlowerComponent", b =>
                {
                    b.HasOne("FlowerShopDatabaseImplement.Models.Component", "Component")
                        .WithMany("FlowerComponents")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlowerShopDatabaseImplement.Models.Flower", "Flower")
                        .WithMany("FlowerComponents")
                        .HasForeignKey("FlowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Component");

                    b.Navigation("Flower");
                });

            modelBuilder.Entity("FlowerShopDatabaseImplement.Models.Order", b =>
                {
                    b.HasOne("FlowerShopDatabaseImplement.Models.Flower", "Flower")
                        .WithMany("Orders")
                        .HasForeignKey("FlowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flower");
                });

            modelBuilder.Entity("FlowerShopDatabaseImplement.Models.StorehouseComponent", b =>
                {
                    b.HasOne("FlowerShopDatabaseImplement.Models.Component", "Component")
                        .WithMany("StorehouseComponents")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlowerShopDatabaseImplement.Models.Storehouse", "Storehouse")
                        .WithMany("StorehouseComponents")
                        .HasForeignKey("StorehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Component");

                    b.Navigation("Storehouse");
                });

            modelBuilder.Entity("FlowerShopDatabaseImplement.Models.Component", b =>
                {
                    b.Navigation("FlowerComponents");

                    b.Navigation("StorehouseComponents");
                });

            modelBuilder.Entity("FlowerShopDatabaseImplement.Models.Flower", b =>
                {
                    b.Navigation("FlowerComponents");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FlowerShopDatabaseImplement.Models.Storehouse", b =>
                {
                    b.Navigation("StorehouseComponents");
                });
#pragma warning restore 612, 618
        }
    }
}
