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
    [Migration("20231228040837_AddedParentField")]
    partial class AddedParentField
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

            modelBuilder.Entity("UniversityDatabase.Models.FormOfControl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("form_of_control");
                });

            modelBuilder.Entity("UniversityDatabase.Models.GradeValue", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("id");

                    b.Property<int>("FormOfControlId")
                        .HasColumnType("int")
                        .HasColumnName("form_of_control_id");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("FormOfControlId");

                    b.ToTable("grade_value");
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

                    b.Property<string>("Parent")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("parent");

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

            modelBuilder.Entity("UniversityDatabase.Models.StudentGrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<byte?>("GradeValueId")
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("grade_value_id");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("student_id");

                    b.Property<int>("StudyPlanId")
                        .HasColumnType("int")
                        .HasColumnName("study_plan_id");

                    b.HasKey("Id");

                    b.HasIndex("GradeValueId");

                    b.HasIndex("StudentId");

                    b.HasIndex("StudyPlanId");

                    b.ToTable("student_grade");
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

            modelBuilder.Entity("UniversityDatabase.Models.StudyPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<byte>("CourseId")
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("course_id");

                    b.Property<int>("FormOfControlId")
                        .HasColumnType("int")
                        .HasColumnName("form_of_control");

                    b.Property<int>("RemainingHours")
                        .HasColumnType("int")
                        .HasColumnName("remaining_hours");

                    b.Property<byte>("SemesterId")
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("semester_id");

                    b.Property<int>("StudyGroupId")
                        .HasColumnType("int")
                        .HasColumnName("study_group_id");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnName("subject_id");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int")
                        .HasColumnName("total_hours");

                    b.Property<int>("TypeOfOccupationId")
                        .HasColumnType("int")
                        .HasColumnName("type_of_occupation");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("FormOfControlId");

                    b.HasIndex("SemesterId");

                    b.HasIndex("StudyGroupId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TypeOfOccupationId");

                    b.ToTable("study_plan");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("subject");
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

            modelBuilder.Entity("UniversityDatabase.Models.TypeOfOccupation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("type_of_occupation");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Workload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("StudyPlanId")
                        .HasColumnType("int")
                        .HasColumnName("study_plan_id");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int")
                        .HasColumnName("teacher_id");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int")
                        .HasColumnName("total_hours");

                    b.HasKey("Id");

                    b.HasIndex("StudyPlanId");

                    b.HasIndex("TeacherId");

                    b.ToTable("workload");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Department", b =>
                {
                    b.HasOne("UniversityDatabase.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Faculty", b =>
                {
                    b.HasOne("UniversityDatabase.Models.Dean", "Dean")
                        .WithMany()
                        .HasForeignKey("DeanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Dean");
                });

            modelBuilder.Entity("UniversityDatabase.Models.GradeValue", b =>
                {
                    b.HasOne("UniversityDatabase.Models.FormOfControl", "FormOfControl")
                        .WithMany()
                        .HasForeignKey("FormOfControlId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FormOfControl");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Student", b =>
                {
                    b.HasOne("UniversityDatabase.Models.Sex", "Sex")
                        .WithMany()
                        .HasForeignKey("SexId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniversityDatabase.Models.StudyGroup", "StudyGroup")
                        .WithMany()
                        .HasForeignKey("StudyGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Sex");

                    b.Navigation("StudyGroup");
                });

            modelBuilder.Entity("UniversityDatabase.Models.StudentGrade", b =>
                {
                    b.HasOne("UniversityDatabase.Models.GradeValue", "GradeValue")
                        .WithMany()
                        .HasForeignKey("GradeValueId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UniversityDatabase.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniversityDatabase.Models.StudyPlan", "StudyPlan")
                        .WithMany()
                        .HasForeignKey("StudyPlanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GradeValue");

                    b.Navigation("Student");

                    b.Navigation("StudyPlan");
                });

            modelBuilder.Entity("UniversityDatabase.Models.StudyGroup", b =>
                {
                    b.HasOne("UniversityDatabase.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniversityDatabase.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("UniversityDatabase.Models.StudyPlan", b =>
                {
                    b.HasOne("UniversityDatabase.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniversityDatabase.Models.FormOfControl", "FormOfControl")
                        .WithMany()
                        .HasForeignKey("FormOfControlId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniversityDatabase.Models.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniversityDatabase.Models.StudyGroup", "StudyGroup")
                        .WithMany()
                        .HasForeignKey("StudyGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniversityDatabase.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniversityDatabase.Models.TypeOfOccupation", "TypeOfOccupation")
                        .WithMany()
                        .HasForeignKey("TypeOfOccupationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("FormOfControl");

                    b.Navigation("Semester");

                    b.Navigation("StudyGroup");

                    b.Navigation("Subject");

                    b.Navigation("TypeOfOccupation");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Teacher", b =>
                {
                    b.HasOne("UniversityDatabase.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniversityDatabase.Models.Sex", "Sex")
                        .WithMany()
                        .HasForeignKey("SexId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniversityDatabase.Models.TeacherPosition", "TeacherPosition")
                        .WithMany()
                        .HasForeignKey("TeacherPositionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Sex");

                    b.Navigation("TeacherPosition");
                });

            modelBuilder.Entity("UniversityDatabase.Models.Workload", b =>
                {
                    b.HasOne("UniversityDatabase.Models.StudyPlan", "StudyPlan")
                        .WithMany()
                        .HasForeignKey("StudyPlanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniversityDatabase.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("StudyPlan");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
