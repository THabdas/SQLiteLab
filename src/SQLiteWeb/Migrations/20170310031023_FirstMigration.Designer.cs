using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SQLiteWeb.Models;

namespace SQLiteWeb.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20170310031023_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("SQLiteWeb.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("School");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });
        }
    }
}
