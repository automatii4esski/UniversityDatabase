﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityDatabase.Data;

#nullable disable

namespace UniversityDatabase.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231204180134_AddStudentTable")]
    partial class AddStudentTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UniversityDatabase.Models.Course", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("id");

                    b.Property<byte>("Number")
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("number");

                    b.HasKey("Id");

                    b.ToTable("course");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Dean", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("dean");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int")
                        .HasColumnName("faculty_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("department");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("DeanId")
                        .HasColumnType("int")
                        .HasColumnName("dean_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.HasIndex("DeanId");

                    b.ToTable("faculty");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Semester", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("id");

                    b.Property<byte>("Number")
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("number");

                    b.HasKey("Id");

                    b.ToTable("semester");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("patronymic");

                    b.Property<byte>("SexNumber")
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("sex");

                    b.Property<int>("StudyGroupId")
                        .HasColumnType("int")
                        .HasColumnName("study_group_id");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("surname");

                    b.HasKey("Id");

                    b.HasIndex("StudyGroupId");

                    b.ToTable("student");
                });

            modelBuilder.Entity("UniversityDatabase.Models.StudyGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<byte>("CourseId")
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("course_id");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int")
                        .HasColumnName("faculty_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<int>("RecruitmentYear")
                        .HasColumnType("int")
                        .HasColumnName("recruitment_year");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("FacultyId");

                    b.ToTable("study_group");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Department", b =>
                {
                    b.HasOne("UniversityDatabase.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Faculty", b =>
                {
                    b.HasOne("UniversityDatabase.Models.Dean", "Dean")
                        .WithMany()
                        .HasForeignKey("DeanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dean");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Student", b =>
                {
                    b.HasOne("UniversityDatabase.Models.StudyGroup", "StudyGroup")
                        .WithMany()
                        .HasForeignKey("StudyGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudyGroup");
                });

            modelBuilder.Entity("UniversityDatabase.Models.StudyGroup", b =>
                {
                    b.HasOne("UniversityDatabase.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityDatabase.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Faculty");
                });
#pragma warning restore 612, 618
        }
    }
}
