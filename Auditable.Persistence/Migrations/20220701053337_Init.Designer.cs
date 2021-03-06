// <auto-generated />
using System;
using Auditable.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Auditable.Persistence.Migrations
{
    [DbContext(typeof(ZetAuditableContext))]
    [Migration("20220701053337_Init")]
    partial class Init
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

            modelBuilder.Entity("Z.EntityFramework.Plus.AuditEntry", b =>
                {
                    b.Property<int>("AuditEntryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnOrder(6);

                    b.Property<string>("EntitySetName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(1);

                    b.Property<string>("EntityTypeName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(2);

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.Property<string>("StateName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(4);

                    b.HasKey("AuditEntryID");

                    b.ToTable("AuditEntries");
                });

            modelBuilder.Entity("Z.EntityFramework.Plus.AuditEntryProperty", b =>
                {
                    b.Property<int>("AuditEntryPropertyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("AuditEntryID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<string>("NewValueFormatted")
                        .HasColumnType("longtext")
                        .HasColumnName("NewValue")
                        .HasColumnOrder(5);

                    b.Property<string>("OldValueFormatted")
                        .HasColumnType("longtext")
                        .HasColumnName("OldValue")
                        .HasColumnOrder(4);

                    b.Property<string>("PropertyName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(3);

                    b.Property<string>("RelationName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(2);

                    b.HasKey("AuditEntryPropertyID");

                    b.HasIndex("AuditEntryID");

                    b.ToTable("AuditEntryProperty");
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

            modelBuilder.Entity("Z.EntityFramework.Plus.AuditEntryProperty", b =>
                {
                    b.HasOne("Z.EntityFramework.Plus.AuditEntry", "Parent")
                        .WithMany("Properties")
                        .HasForeignKey("AuditEntryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Z.EntityFramework.Plus.AuditEntry", b =>
                {
                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}
