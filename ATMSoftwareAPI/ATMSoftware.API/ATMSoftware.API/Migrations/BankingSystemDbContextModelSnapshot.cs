// <auto-generated />
using System;
using ATMSoftware.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ATMSoftware.API.Migrations
{
    [DbContext(typeof(BankingSystemDbContext))]
    partial class BankingSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ATMSoftware.API.Models.CustomerData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("AccountNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("BranchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CardPin")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TotalBalance")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("CustomersData");
                });

            modelBuilder.Entity("ATMSoftware.API.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"), 1L, 1);

                    b.Property<long>("AccountNumber")
                        .HasColumnType("bigint");

                    b.Property<float>("AmountTransfer")
                        .HasColumnType("real");

                    b.Property<string>("BranchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("RecipientAccountNumber")
                        .HasColumnType("bigint");

                    b.HasKey("TransactionId");

                    b.ToTable("TransactionRecord");
                });
#pragma warning restore 612, 618
        }
    }
}
