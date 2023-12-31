﻿// <auto-generated />
using System;
using BlazorServer.CompositePatternExample.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorServer.CompositePatternExample.Migrations
{
    [DbContext(typeof(CompositePatternContext))]
    [Migration("20231213232355_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("BlazorServer.CompositePatternExample.Domain.Models.Directory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DirectoryId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRoot")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentDirectoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Size")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParentDirectoryId");

                    b.ToTable("Directories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DirectoryId = 0,
                            IsRoot = true,
                            Name = "Root",
                            Size = 10
                        },
                        new
                        {
                            Id = 2,
                            DirectoryId = 1,
                            IsRoot = false,
                            Name = "Documents",
                            Size = 10
                        },
                        new
                        {
                            Id = 3,
                            DirectoryId = 1,
                            IsRoot = false,
                            Name = "Pictures",
                            Size = 10
                        },
                        new
                        {
                            Id = 4,
                            DirectoryId = 3,
                            IsRoot = false,
                            Name = "Snips",
                            Size = 10
                        });
                });

            modelBuilder.Entity("BlazorServer.CompositePatternExample.Domain.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DirectoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Size")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DirectoryId");

                    b.ToTable("Files");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DirectoryId = 1,
                            Name = "Root File",
                            Size = 256
                        },
                        new
                        {
                            Id = 2,
                            DirectoryId = 2,
                            Name = "Document File",
                            Size = 512
                        },
                        new
                        {
                            Id = 3,
                            DirectoryId = 3,
                            Name = "Picture File",
                            Size = 1028
                        },
                        new
                        {
                            Id = 4,
                            DirectoryId = 4,
                            Name = "Snip File",
                            Size = 1028
                        });
                });

            modelBuilder.Entity("BlazorServer.CompositePatternExample.Domain.Models.Directory", b =>
                {
                    b.HasOne("BlazorServer.CompositePatternExample.Domain.Models.Directory", "ParentDirectory")
                        .WithMany()
                        .HasForeignKey("ParentDirectoryId");

                    b.Navigation("ParentDirectory");
                });

            modelBuilder.Entity("BlazorServer.CompositePatternExample.Domain.Models.File", b =>
                {
                    b.HasOne("BlazorServer.CompositePatternExample.Domain.Models.Directory", "ParentDirectory")
                        .WithMany()
                        .HasForeignKey("DirectoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentDirectory");
                });
#pragma warning restore 612, 618
        }
    }
}
