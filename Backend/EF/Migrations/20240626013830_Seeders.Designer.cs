﻿// <auto-generated />
using System;
using Backend.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.EF.Migrations
{
    [DbContext(typeof(SaverContext))]
    [Migration("20240626013830_Seeders")]
    partial class Seeders
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Backend.Finances.Models.Finance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("finances", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("1366e7ad-4e5d-4f0d-b3d4-48832fa7bb8f"),
                            Amount = 10000.0,
                            Description = "Salary",
                            Type = "income",
                            UserId = new Guid("d5af0c60-f6e5-4b3d-af69-2d992b7ae096")
                        },
                        new
                        {
                            Id = new Guid("5f6fb1ce-55d4-425f-9435-2c23106c6611"),
                            Amount = 250.0,
                            Description = "Groceries",
                            Type = "expense",
                            UserId = new Guid("d5af0c60-f6e5-4b3d-af69-2d992b7ae096")
                        },
                        new
                        {
                            Id = new Guid("58edcbda-81aa-4ceb-b200-7365008ec9b1"),
                            Amount = 1000.0,
                            Description = "Clothing",
                            Type = "expense",
                            UserId = new Guid("d5af0c60-f6e5-4b3d-af69-2d992b7ae096")
                        },
                        new
                        {
                            Id = new Guid("a34f644b-abdd-4100-bbc0-6acd2015440c"),
                            Amount = 10000000.0,
                            Description = "Salary",
                            Type = "income",
                            UserId = new Guid("70359af3-ca94-410d-87fb-f909cde413ac")
                        },
                        new
                        {
                            Id = new Guid("83414412-8015-45f6-acae-bfcb70e065f7"),
                            Amount = 250215.0,
                            Description = "Party",
                            Type = "expense",
                            UserId = new Guid("70359af3-ca94-410d-87fb-f909cde413ac")
                        },
                        new
                        {
                            Id = new Guid("74512627-490d-44b6-8882-831010aeeacb"),
                            Amount = 999999.0,
                            Description = "Clothing",
                            Type = "expense",
                            UserId = new Guid("70359af3-ca94-410d-87fb-f909cde413ac")
                        },
                        new
                        {
                            Id = new Guid("ab85ccfd-8fd8-4f9e-bc89-b2ea558e230e"),
                            Amount = 15000.0,
                            Description = "Salary",
                            Type = "income",
                            UserId = new Guid("548dfcc0-a38e-456f-9430-17ad3950ab39")
                        },
                        new
                        {
                            Id = new Guid("a983e4ad-4958-48d1-9e83-45a97533de4f"),
                            Amount = 1000.0,
                            Description = "Fine",
                            Type = "expense",
                            UserId = new Guid("70359af3-ca94-410d-87fb-f909cde413ac")
                        },
                        new
                        {
                            Id = new Guid("2b2af71f-0849-437f-81a9-6b370a3ada07"),
                            Amount = 1534.0,
                            Description = "Groceries",
                            Type = "expense",
                            UserId = new Guid("70359af3-ca94-410d-87fb-f909cde413ac")
                        },
                        new
                        {
                            Id = new Guid("f9bd5e33-ec28-46d9-8ecf-d24319954002"),
                            Amount = 2565.0,
                            Description = "Clothing",
                            Type = "expense",
                            UserId = new Guid("70359af3-ca94-410d-87fb-f909cde413ac")
                        },
                        new
                        {
                            Id = new Guid("8c9737b3-7f9f-4513-94b0-f0c55adf5f76"),
                            Amount = 20000.0,
                            Description = "Salary",
                            Type = "income",
                            UserId = new Guid("105b06df-73cc-4a6e-9a14-f6ee4912e8b1")
                        },
                        new
                        {
                            Id = new Guid("59dab4c4-b698-4d73-9ecb-54cad193fb65"),
                            Amount = 1000.0,
                            Description = "Tax Refund",
                            Type = "income",
                            UserId = new Guid("105b06df-73cc-4a6e-9a14-f6ee4912e8b1")
                        },
                        new
                        {
                            Id = new Guid("10c13555-30f2-4dee-adb0-43ce0b245d7e"),
                            Amount = 30000.0,
                            Description = "Salary",
                            Type = "income",
                            UserId = new Guid("7c149996-5bba-4c04-8450-f0ab2f888299")
                        },
                        new
                        {
                            Id = new Guid("0f16ba2e-64a1-47a5-bd33-b690ca254a99"),
                            Amount = 5548.0,
                            Description = "Clothing",
                            Type = "expense",
                            UserId = new Guid("7c149996-5bba-4c04-8450-f0ab2f888299")
                        },
                        new
                        {
                            Id = new Guid("52a675e8-c2ab-45e2-89d5-1b04a3d92465"),
                            Amount = 2544.0,
                            Description = "Salon",
                            Type = "expense",
                            UserId = new Guid("7c149996-5bba-4c04-8450-f0ab2f888299")
                        },
                        new
                        {
                            Id = new Guid("b16e7375-6f47-4885-a29a-4d341abd1c25"),
                            Amount = 2400.0,
                            Description = "Hairdresser",
                            Type = "expense",
                            UserId = new Guid("7c149996-5bba-4c04-8450-f0ab2f888299")
                        },
                        new
                        {
                            Id = new Guid("4dc02086-add7-4997-ad44-c1c4775b6327"),
                            Amount = 250.0,
                            Description = "Clothing",
                            Type = "expense",
                            UserId = new Guid("7c149996-5bba-4c04-8450-f0ab2f888299")
                        });
                });

            modelBuilder.Entity("Backend.Users.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d5af0c60-f6e5-4b3d-af69-2d992b7ae096"),
                            Email = "alexandrepato@email.com",
                            IdentificationNumber = "39212783090",
                            IsActive = true,
                            Name = "Alexandre Pato",
                            Password = "patopato123"
                        },
                        new
                        {
                            Id = new Guid("70359af3-ca94-410d-87fb-f909cde413ac"),
                            Email = "neymarjr@email.com",
                            IdentificationNumber = "34546715072",
                            IsActive = true,
                            Name = "Neymar Jr",
                            Password = "adultoNey123"
                        },
                        new
                        {
                            Id = new Guid("548dfcc0-a38e-456f-9430-17ad3950ab39"),
                            Email = "craqueneto@email.com",
                            IdentificationNumber = "47420061009",
                            IsActive = true,
                            Name = "Craque Neto",
                            Password = "netaoBomBeef"
                        },
                        new
                        {
                            Id = new Guid("105b06df-73cc-4a6e-9a14-f6ee4912e8b1"),
                            Email = "denilson@email.com",
                            IdentificationNumber = "09755120050",
                            IsActive = true,
                            Name = "Denílson",
                            Password = "denilson123"
                        },
                        new
                        {
                            Id = new Guid("7c149996-5bba-4c04-8450-f0ab2f888299"),
                            Email = "renatafan@email.com",
                            IdentificationNumber = "04951619008",
                            IsActive = true,
                            Name = "Renata Fan",
                            Password = "renatafanJogoAberto"
                        });
                });

            modelBuilder.Entity("Backend.Finances.Models.Finance", b =>
                {
                    b.HasOne("Backend.Users.Models.User", "User")
                        .WithMany("Finances")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Users.Models.User", b =>
                {
                    b.Navigation("Finances");
                });
#pragma warning restore 612, 618
        }
    }
}
