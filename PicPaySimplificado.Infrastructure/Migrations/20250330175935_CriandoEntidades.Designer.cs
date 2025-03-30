﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PicPaySimplificado.Infrastructure.Context;

#nullable disable

namespace PicPaySimplificado.Infrastructure.Migrations
{
    [DbContext(typeof(PicPaySimplificadoContext))]
    [Migration("20250330175935_CriandoEntidades")]
    partial class CriandoEntidades
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PicPaySimplificado.Domain.Entities.Transfer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IdPayee")
                        .HasColumnType("int");

                    b.Property<int>("IdPayer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPayee");

                    b.HasIndex("IdPayer");

                    b.ToTable("Transfers", (string)null);
                });

            modelBuilder.Entity("PicPaySimplificado.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("PicPaySimplificado.Domain.Entities.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.ToTable("Wallets", (string)null);
                });

            modelBuilder.Entity("PicPaySimplificado.Domain.Entities.Transfer", b =>
                {
                    b.HasOne("PicPaySimplificado.Domain.Entities.User", "Payee")
                        .WithMany()
                        .HasForeignKey("IdPayee")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PicPaySimplificado.Domain.Entities.User", "Payer")
                        .WithMany()
                        .HasForeignKey("IdPayer")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Payee");

                    b.Navigation("Payer");
                });

            modelBuilder.Entity("PicPaySimplificado.Domain.Entities.Wallet", b =>
                {
                    b.HasOne("PicPaySimplificado.Domain.Entities.User", "User")
                        .WithOne("Wallet")
                        .HasForeignKey("PicPaySimplificado.Domain.Entities.Wallet", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PicPaySimplificado.Domain.Entities.User", b =>
                {
                    b.Navigation("Wallet")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
