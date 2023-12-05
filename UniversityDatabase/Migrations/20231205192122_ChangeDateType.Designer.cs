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
    [Migration("20231205192122_ChangeDateType")]
    partial class ChangeDateType
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

            modelBuilder.Entity("UniversityDatabase.Models.Sex", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("sex");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("DATE")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("patronymic");

                    b.Property<byte>("SexId")
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("sex_id");

                    b.Property<int>("StudyGroupId")
                        .HasColumnType("int")
                        .HasColumnName("study_group_id");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("surname");

                    b.HasKey("Id");

                    b.HasIndex("SexId");

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

            modelBuilder.Entity("UniversityDatabase.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("DATE")
                        .HasColumnName("date_of_birth");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("department_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("patronymic");

                    b.Property<int>("Salary")
                        .HasColumnType("int")
                        .HasColumnName("salary");

                    b.Property<byte>("SexId")
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("sex_id");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("surname");

                    b.Property<byte>("TeacherPositionId")
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("teacher_position_id");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SexId");

                    b.HasIndex("TeacherPositionId");

                    b.ToTable("teacher");
                });

            modelBuilder.Entity("UniversityDatabase.Models.TeacherPosition", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("teacher_position");
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
                    b.HasOne("UniversityDatabase.Models.Sex", "Sex")
                        .WithMany()
                        .HasForeignKey("SexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityDatabase.Models.StudyGroup", "StudyGroup")
                        .WithMany()
                        .HasForeignKey("StudyGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sex");

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

            modelBuilder.Entity("UniversityDatabase.Models.Teacher", b =>
                {
                    b.HasOne("UniversityDatabase.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityDatabase.Models.Sex", "Sex")
                        .WithMany()
                        .HasForeignKey("SexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityDatabase.Models.TeacherPosition", "TeacherPosition")
                        .WithMany()
                        .HasForeignKey("TeacherPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Sex");

                    b.Navigation("TeacherPosition");
                });
#pragma warning restore 612, 618
        }
    }
}
