﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Strengths.API.Data;

namespace Strengths.API.Migrations
{
    [DbContext(typeof(StrengthsContext))]
    [Migration("20190608034009_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Strengths.API.Data.Domain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Domain");
                });

            modelBuilder.Entity("Strengths.API.Data.Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DomainId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DomainId");

                    b.ToTable("Theme");
                });

            modelBuilder.Entity("Strengths.API.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int?>("Theme1Id");

                    b.Property<int?>("Theme2Id");

                    b.Property<int?>("Theme3Id");

                    b.Property<int?>("Theme4Id");

                    b.Property<int?>("Theme5Id");

                    b.HasKey("Id");

                    b.HasIndex("Theme1Id");

                    b.HasIndex("Theme2Id");

                    b.HasIndex("Theme3Id");

                    b.HasIndex("Theme4Id");

                    b.HasIndex("Theme5Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Strengths.API.Data.Theme", b =>
                {
                    b.HasOne("Strengths.API.Data.Domain", "Domain")
                        .WithMany("Themes")
                        .HasForeignKey("DomainId");
                });

            modelBuilder.Entity("Strengths.API.Data.User", b =>
                {
                    b.HasOne("Strengths.API.Data.Theme", "Theme1")
                        .WithMany()
                        .HasForeignKey("Theme1Id");

                    b.HasOne("Strengths.API.Data.Theme", "Theme2")
                        .WithMany()
                        .HasForeignKey("Theme2Id");

                    b.HasOne("Strengths.API.Data.Theme", "Theme3")
                        .WithMany()
                        .HasForeignKey("Theme3Id");

                    b.HasOne("Strengths.API.Data.Theme", "Theme4")
                        .WithMany()
                        .HasForeignKey("Theme4Id");

                    b.HasOne("Strengths.API.Data.Theme", "Theme5")
                        .WithMany()
                        .HasForeignKey("Theme5Id");
                });
#pragma warning restore 612, 618
        }
    }
}
