﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreDB.DB;

namespace StoreDB.Migrations
{
    [DbContext(typeof(StoreDBContext))]
    [Migration("20190721134739_StoreDB.DB.StoreDBContext")]
    partial class StoreDBDBStoreDBContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StoreDB.User", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            Email = "kennyrg@gmail.com",
                            FirstName = "Kenny",
                            LastName = "Rogers"
                        },
                        new
                        {
                            UserId = "2",
                            Email = "barryr@gmail.com",
                            FirstName = "Barry",
                            LastName = "White"
                        },
                        new
                        {
                            UserId = "3",
                            Email = "janefonda@gmail.com",
                            FirstName = "Jane",
                            LastName = "Fonda"
                        },
                        new
                        {
                            UserId = "4",
                            Email = "sametto@gmail.com",
                            FirstName = "Sam",
                            LastName = "Etto"
                        },
                        new
                        {
                            UserId = "5",
                            Email = "adamsandler@gmail.com",
                            FirstName = "Adam",
                            LastName = "Sandler"
                        },
                        new
                        {
                            UserId = "6",
                            Email = "oliviastone@gmail.com",
                            FirstName = "Olivia",
                            LastName = "stone"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
