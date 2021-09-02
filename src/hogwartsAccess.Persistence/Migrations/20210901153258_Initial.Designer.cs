﻿// <auto-generated />
using System;
using Ifx.Services.hogwartsAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ifx.Services.hogwartsAccess.Persistence.Migrations
{
    [DbContext(typeof(AdmissionDbContext))]
    [Migration("20210901153258_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ifx.Services.hogwartsAccess.Domain.Entities.Admission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("age");

                    b.Property<int>("HouseRequest")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("houseRequest");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("identification");

                    b.Property<int>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("Identification");

                    b.ToTable("TBL_ADMISSION");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b47e669d-b685-499a-a6b8-5bf0f694bdaa"),
                            Age = "16",
                            HouseRequest = 3,
                            Identification = "1121931225",
                            Status = 0
                        });
                });

            modelBuilder.Entity("Ifx.Services.hogwartsAccess.Domain.Entities.Student", b =>
                {
                    b.Property<string>("Identification")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("id");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("lastName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Identification");

                    b.ToTable("TBL_STUDENT");

                    b.HasData(
                        new
                        {
                            Identification = "1121931225",
                            LastName = "Cardenas",
                            Name = "Pedro"
                        });
                });

            modelBuilder.Entity("Ifx.Services.hogwartsAccess.Domain.Entities.Admission", b =>
                {
                    b.HasOne("Ifx.Services.hogwartsAccess.Domain.Entities.Student", "Students")
                        .WithMany("Admissions")
                        .HasForeignKey("Identification")
                        .HasConstraintName("FK_STUDENT_ADMISSION")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Ifx.Services.hogwartsAccess.Domain.Entities.Student", b =>
                {
                    b.Navigation("Admissions");
                });
#pragma warning restore 612, 618
        }
    }
}
