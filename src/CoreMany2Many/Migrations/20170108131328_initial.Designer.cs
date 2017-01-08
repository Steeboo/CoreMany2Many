using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreMany2Many;

namespace CoreMany2Many.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170108131328_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreMany2Many.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("CoreMany2Many.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CoreMany2Many.ProductColor", b =>
                {
                    b.Property<int>("ColorId");

                    b.Property<int>("ProductId");

                    b.HasKey("ColorId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductColor");
                });

            modelBuilder.Entity("CoreMany2Many.ProductColor", b =>
                {
                    b.HasOne("CoreMany2Many.Color", "Color")
                        .WithMany("ProductColors")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoreMany2Many.Product", "Product")
                        .WithMany("ProductColors")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
