﻿// <auto-generated />
using System;
using Infrastructure.Construction_Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ConstructionContext))]
    [Migration("20230719041613_init5")]
    partial class init5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Models.About.AboutPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<byte[]>("bg")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("header")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SectionId")
                        .IsUnique();

                    b.ToTable("AboutPage");
                });

            modelBuilder.Entity("Data.Models.About.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("Data.Models.Service.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ServicePageId")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ServicePageId")
                        .IsUnique();

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Data.Models.Service.ServiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceItems");
                });

            modelBuilder.Entity("Data.Models.Service.ServicePage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("bg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("header")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ServicePage");
                });

            modelBuilder.Entity("Data.Models.About.AboutPage", b =>
                {
                    b.HasOne("Data.Models.About.Section", "Section")
                        .WithOne("Aboutpage")
                        .HasForeignKey("Data.Models.About.AboutPage", "SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("Data.Models.Service.Service", b =>
                {
                    b.HasOne("Data.Models.Service.ServicePage", "ServicePage")
                        .WithOne("Service")
                        .HasForeignKey("Data.Models.Service.Service", "ServicePageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServicePage");
                });

            modelBuilder.Entity("Data.Models.Service.ServiceItem", b =>
                {
                    b.HasOne("Data.Models.Service.Service", "Service")
                        .WithMany("serviceItems")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Data.Models.About.Section", b =>
                {
                    b.Navigation("Aboutpage");
                });

            modelBuilder.Entity("Data.Models.Service.Service", b =>
                {
                    b.Navigation("serviceItems");
                });

            modelBuilder.Entity("Data.Models.Service.ServicePage", b =>
                {
                    b.Navigation("Service")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
