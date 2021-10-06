﻿// <auto-generated />
using System;
using EFTemplates.EntityRelationshipsExample.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFTemplates.EntityRelationshipsExample.Migrations
{
    [DbContext(typeof(EntityRelationshipsExampleDbContext))]
    [Migration("20211006124925_PaymentOrdersRegister")]
    partial class PaymentOrdersRegister
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.ATMMachine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ServiceEngineerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ServiceEngineerId");

                    b.ToTable("ATMMachines");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("AccountOwnerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AccountOwnerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.AccountOwner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountOwners");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.BankCellsStorage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BankCellsStorages");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.BankDepositBox", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BankCellsStorageId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BankCellsStorageId");

                    b.ToTable("BankDepositBoxes");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.CreditProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CreditProductsGroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreditProductsGroupId");

                    b.ToTable("CreditProducts");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.CreditProductsGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("CreditProductsGroups");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.PaymentOrder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("RegisterCode")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RegisterCode");

                    b.ToTable("PaymentOrders");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.PaymentOrdersRegister", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("PaymentOrdersRegisters");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.ServiceEngineer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ServiceEngineers");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.ATMMachine", b =>
                {
                    b.HasOne("EFTemplates.EntityRelationshipsExample.Models.ServiceEngineer", "ServiceEngineer")
                        .WithMany("ATMMachines")
                        .HasForeignKey("ServiceEngineerId");

                    b.Navigation("ServiceEngineer");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.Account", b =>
                {
                    b.HasOne("EFTemplates.EntityRelationshipsExample.Models.AccountOwner", "AccountOwner")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountOwner");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.BankDepositBox", b =>
                {
                    b.HasOne("EFTemplates.EntityRelationshipsExample.Models.BankCellsStorage", null)
                        .WithMany("BankDepositBoxes")
                        .HasForeignKey("BankCellsStorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.CreditProduct", b =>
                {
                    b.HasOne("EFTemplates.EntityRelationshipsExample.Models.CreditProductsGroup", null)
                        .WithMany("CreditProducts")
                        .HasForeignKey("CreditProductsGroupId");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.PaymentOrder", b =>
                {
                    b.HasOne("EFTemplates.EntityRelationshipsExample.Models.PaymentOrdersRegister", "PaymentOrdersRegister")
                        .WithMany("PaymentOrders")
                        .HasForeignKey("RegisterCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentOrdersRegister");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.AccountOwner", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.BankCellsStorage", b =>
                {
                    b.Navigation("BankDepositBoxes");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.CreditProductsGroup", b =>
                {
                    b.Navigation("CreditProducts");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.PaymentOrdersRegister", b =>
                {
                    b.Navigation("PaymentOrders");
                });

            modelBuilder.Entity("EFTemplates.EntityRelationshipsExample.Models.ServiceEngineer", b =>
                {
                    b.Navigation("ATMMachines");
                });
#pragma warning restore 612, 618
        }
    }
}