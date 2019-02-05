﻿// <auto-generated />
using BancoManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BancoManager.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("BancoManager.Model.Agencia", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Agencias");
                });

            modelBuilder.Entity("BancoManager.Model.Banco", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("BancoManager.Model.Cliente", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("BancoManager.Model.ContaCorrente", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Saldo");

                    b.Property<string>("TitularId");

                    b.HasKey("Id");

                    b.HasIndex("TitularId");

                    b.ToTable("ContasCorrente");
                });

            modelBuilder.Entity("BancoManager.Model.ContaPoupanca", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Aniversario");

                    b.Property<decimal>("Juros");

                    b.Property<decimal>("Saldo");

                    b.Property<string>("TitularId");

                    b.HasKey("Id");

                    b.HasIndex("TitularId");

                    b.ToTable("ContasPoupanca");
                });

            modelBuilder.Entity("BancoManager.Model.ContaCorrente", b =>
                {
                    b.HasOne("BancoManager.Model.Cliente", "Titular")
                        .WithMany()
                        .HasForeignKey("TitularId");
                });

            modelBuilder.Entity("BancoManager.Model.ContaPoupanca", b =>
                {
                    b.HasOne("BancoManager.Model.Cliente", "Titular")
                        .WithMany()
                        .HasForeignKey("TitularId");
                });
#pragma warning restore 612, 618
        }
    }
}
