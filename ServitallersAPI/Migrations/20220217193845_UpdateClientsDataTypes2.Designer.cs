﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServitallersAPI.Data;

namespace ServitallersAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220217193845_UpdateClientsDataTypes2")]
    partial class UpdateClientsDataTypes2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServitallersAPI.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("ClientType")
                        .HasColumnType("int");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ContactPhone")
                        .HasColumnType("bigint");

                    b.Property<long?>("ContactPhone2")
                        .HasColumnType("bigint");

                    b.Property<bool>("Credit")
                        .HasColumnType("bit");

                    b.Property<long>("CreditAmount")
                        .HasColumnType("bigint");

                    b.Property<int>("DaysCredit")
                        .HasColumnType("int");

                    b.Property<bool>("Declarant")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MobileNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("NumberOfIdentification")
                        .HasColumnType("int");

                    b.Property<int>("ReteFuente")
                        .HasColumnType("int");

                    b.Property<int>("ReteIva")
                        .HasColumnType("int");

                    b.Property<string>("SecondLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TelephoneNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("TypeOfIdentification")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ServitallersAPI.Models.VehicleBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleBrands");
                });
#pragma warning restore 612, 618
        }
    }
}
