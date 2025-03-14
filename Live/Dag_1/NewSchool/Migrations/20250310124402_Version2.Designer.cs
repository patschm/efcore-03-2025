﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewSchool.NewModels;

#nullable disable

namespace NewSchool.Migrations
{
    [DbContext(typeof(ShopDatabaseContext))]
    [Migration("20250310124402_Version2")]
    partial class Version2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NewSchool.NewModels.Merk", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Website")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("Id");

                    b.ToTable("Brands", "Core");
                });

            modelBuilder.Entity("NewSchool.NewModels.Price", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<double>("BasePrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("PriceDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProductId" }, "IX_Prices_ProductId");

                    b.ToTable("Prices", "Core");
                });

            modelBuilder.Entity("NewSchool.NewModels.PriceHistory", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<double>("BasePrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("PriceDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("PriceHistory", "Core");
                });

            modelBuilder.Entity("NewSchool.NewModels.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BrandId")
                        .HasColumnType("bigint");

                    b.Property<string>("Image")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("ProductGroupId")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "BrandId" }, "IX_Products_BrandId");

                    b.HasIndex(new[] { "ProductGroupId" }, "IX_Products_ProductGroupId");

                    b.ToTable("Products", "Core");
                });

            modelBuilder.Entity("NewSchool.NewModels.ProductGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Image")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("ProductGroups", "Core");
                });

            modelBuilder.Entity("NewSchool.NewModels.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DateBought")
                        .HasColumnType("datetime2");

                    b.Property<string>("Organization")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("ReviewType")
                        .HasColumnType("int");

                    b.Property<string>("ReviewUrl")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<long?>("ReviewerId")
                        .HasColumnType("bigint");

                    b.Property<byte>("Score")
                        .HasColumnType("tinyint");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProductId" }, "IX_Reviews_ProductId");

                    b.HasIndex(new[] { "ReviewerId" }, "IX_Reviews_ReviewerId");

                    b.ToTable("Reviews", "Core");
                });

            modelBuilder.Entity("NewSchool.NewModels.Reviewer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Reviewers", "Core");
                });

            modelBuilder.Entity("NewSchool.NewModels.Specification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool?>("BoolValue")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double?>("NumberValue")
                        .HasColumnType("float");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("StringValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProductId" }, "IX_Specifications_ProductId");

                    b.ToTable("Specifications", "Core");
                });

            modelBuilder.Entity("NewSchool.NewModels.SpecificationDefinition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("ProductGroupId")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProductGroupId" }, "IX_SpecificationDefinitions_ProductGroupId");

                    b.ToTable("SpecificationDefinitions", "Core");
                });

            modelBuilder.Entity("NewSchool.NewModels.Price", b =>
                {
                    b.HasOne("NewSchool.NewModels.Product", "Product")
                        .WithMany("Prices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NewSchool.NewModels.Product", b =>
                {
                    b.HasOne("NewSchool.NewModels.Merk", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewSchool.NewModels.ProductGroup", "ProductGroup")
                        .WithMany("Products")
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("ProductGroup");
                });

            modelBuilder.Entity("NewSchool.NewModels.Review", b =>
                {
                    b.HasOne("NewSchool.NewModels.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewSchool.NewModels.Reviewer", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId");

                    b.Navigation("Product");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("NewSchool.NewModels.Specification", b =>
                {
                    b.HasOne("NewSchool.NewModels.Product", "Product")
                        .WithMany("Specifications")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NewSchool.NewModels.SpecificationDefinition", b =>
                {
                    b.HasOne("NewSchool.NewModels.ProductGroup", "ProductGroup")
                        .WithMany("SpecificationDefinitions")
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductGroup");
                });

            modelBuilder.Entity("NewSchool.NewModels.Merk", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NewSchool.NewModels.Product", b =>
                {
                    b.Navigation("Prices");

                    b.Navigation("Reviews");

                    b.Navigation("Specifications");
                });

            modelBuilder.Entity("NewSchool.NewModels.ProductGroup", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SpecificationDefinitions");
                });

            modelBuilder.Entity("NewSchool.NewModels.Reviewer", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
