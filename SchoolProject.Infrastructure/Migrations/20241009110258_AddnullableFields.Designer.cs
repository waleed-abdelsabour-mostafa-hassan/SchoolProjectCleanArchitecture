﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolProject.Infrastructure.Context;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241009110258_AddnullableFields")]
    partial class AddnullableFields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolProject.Data.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("InstManagerId")
                        .HasColumnType("int");

                    b.Property<string>("NameAr")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NameEn")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("InstManagerId")
                        .IsUnique()
                        .HasFilter("[InstManagerId] IS NOT NULL");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.DepartmentSubject", b =>
                {
                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("departmentSubjects");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SupervisorId");

                    b.ToTable("instructors");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.InstructorSubject", b =>
                {
                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("InstructorId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("instructorSubjects");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressAr")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("AddressEn")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int?>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("NameAr")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NameEn")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Phone")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DeptId");

                    b.ToTable("students");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.StudentSubject", b =>
                {
                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.Property<decimal?>("grade")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("StudentId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("studentSubjects");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameAr")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NameEn")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Period")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Department", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Instructor", "Instructor")
                        .WithOne("DepartmentManager")
                        .HasForeignKey("SchoolProject.Data.Entities.Department", "InstManagerId");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.DepartmentSubject", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Department", "Department")
                        .WithMany("DepartmentSubjects")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolProject.Data.Entities.Subject", "Subject")
                        .WithMany("DepartmentSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Instructor", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Department", "department")
                        .WithMany("Instructors")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("SchoolProject.Data.Entities.Instructor", "Supervisor")
                        .WithMany("Instructors")
                        .HasForeignKey("SupervisorId");

                    b.Navigation("Supervisor");

                    b.Navigation("department");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.InstructorSubject", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Instructor", "Instructor")
                        .WithMany("InstructorSubjects")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolProject.Data.Entities.Subject", "Subject")
                        .WithMany("InstructorSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Student", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DeptId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.StudentSubject", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Student", "Student")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolProject.Data.Entities.Subject", "Subject")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Department", b =>
                {
                    b.Navigation("DepartmentSubjects");

                    b.Navigation("Instructors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Instructor", b =>
                {
                    b.Navigation("DepartmentManager");

                    b.Navigation("InstructorSubjects");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Student", b =>
                {
                    b.Navigation("StudentSubjects");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Subject", b =>
                {
                    b.Navigation("DepartmentSubjects");

                    b.Navigation("InstructorSubjects");

                    b.Navigation("StudentSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
