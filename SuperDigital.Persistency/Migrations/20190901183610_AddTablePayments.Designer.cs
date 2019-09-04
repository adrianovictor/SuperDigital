﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperDigital.Persistency.DataContexts;

namespace SuperDigital.Persistency.Migrations
{
    [DbContext(typeof(SuperDigitalContext))]
    [Migration("20190901183610_AddTablePayments")]
    partial class AddTablePayments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SuperDigital.Domain.Model.Accounts.AccountHolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AccountBalance");

                    b.Property<string>("AccountDigit")
                        .IsRequired()
                        .HasMaxLength(4)
                        .IsUnicode(false);

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false);

                    b.Property<string>("Agency")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false);

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedBy");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int?>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("AccountHolder","accounts");
                });

            modelBuilder.Entity("SuperDigital.Domain.Model.Accounts.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountHolderId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedBy");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int?>("UpdatedBy");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.ToTable("Payment","accounts");
                });

            modelBuilder.Entity("SuperDigital.Domain.Model.Accounts.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false);

                    b.Property<int>("AccountHolderId");

                    b.Property<string>("Agency")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false);

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasMaxLength(4)
                        .IsUnicode(false);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int?>("UpdatedBy");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.ToTable("Transfer","accounts");
                });

            modelBuilder.Entity("SuperDigital.Domain.Model.Accounts.Withdrawal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountHolderId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedBy");

                    b.Property<string>("Equipament")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int?>("UpdatedBy");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.ToTable("Withdrawal","accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
