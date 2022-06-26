﻿// <auto-generated />
using System;
using Auditable.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Auditable.Persistence.Migrations
{
    [DbContext(typeof(CustomAuditableContext))]
    [Migration("20220620194739_EntryRelationName")]
    partial class EntryRelationName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Auditable.Domain.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CountryId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Auditable.Domain.CustomAuditEntry", b =>
                {
                    b.Property<long>("CustomAuditEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("ColumnName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NewValue")
                        .HasColumnType("longtext");

                    b.Property<string>("OldValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RelationName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TableName")
                        .HasColumnType("longtext");

                    b.HasKey("CustomAuditEntryId");

                    b.ToTable("AuditEntries");
                });

            modelBuilder.Entity("Auditable.Domain.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PersonId");

                    b.HasIndex("CountryId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Auditable.Domain.Person", b =>
                {
                    b.HasOne("Auditable.Domain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
