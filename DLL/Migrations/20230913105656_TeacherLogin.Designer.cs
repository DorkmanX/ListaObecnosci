﻿// <auto-generated />
using System;
using DLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DLL.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230913105656_TeacherLogin")]
    partial class TeacherLogin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DLL.EntityFramework.CourseDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("DLL.EntityFramework.GroupDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Groups", (string)null);
                });

            modelBuilder.Entity("DLL.EntityFramework.LessonDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LessonDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lessons", (string)null);
                });

            modelBuilder.Entity("DLL.EntityFramework.MarkDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("GroupId");

                    b.HasIndex("StudentId");

                    b.ToTable("Marks", (string)null);
                });

            modelBuilder.Entity("DLL.EntityFramework.StudentDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Surname");

                    b.HasKey("Id");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("DLL.EntityFramework.TeacherDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers", (string)null);
                });

            modelBuilder.Entity("DLL.EntityFramework.TimesheetDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPresence")
                        .HasColumnType("bit");

                    b.Property<int?>("LessonDTOId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonDTOId");

                    b.HasIndex("StudentId");

                    b.ToTable("Timesheets", (string)null);
                });

            modelBuilder.Entity("GroupDTOStudentDTO", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("GroupsId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("GroupsUsers", (string)null);
                });

            modelBuilder.Entity("DLL.EntityFramework.CourseDTO", b =>
                {
                    b.HasOne("DLL.EntityFramework.GroupDTO", "Group")
                        .WithMany("Courses")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("Course_Group_FK");

                    b.HasOne("DLL.EntityFramework.TeacherDTO", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("Course_Teacher_FK");

                    b.Navigation("Group");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("DLL.EntityFramework.GroupDTO", b =>
                {
                    b.HasOne("DLL.EntityFramework.TeacherDTO", "Teacher")
                        .WithMany("Groups")
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("Group_Teacher_FK");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("DLL.EntityFramework.LessonDTO", b =>
                {
                    b.HasOne("DLL.EntityFramework.CourseDTO", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Lesson_Group_FK");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("DLL.EntityFramework.MarkDTO", b =>
                {
                    b.HasOne("DLL.EntityFramework.CourseDTO", "Course")
                        .WithMany("Marks")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Marks_Course_FK");

                    b.HasOne("DLL.EntityFramework.GroupDTO", "Group")
                        .WithMany("Marks")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Marks_Group_FK");

                    b.HasOne("DLL.EntityFramework.StudentDTO", "Student")
                        .WithMany("Marks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Marks_Student_FK");

                    b.Navigation("Course");

                    b.Navigation("Group");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DLL.EntityFramework.TimesheetDTO", b =>
                {
                    b.HasOne("DLL.EntityFramework.LessonDTO", null)
                        .WithMany("Timesheets")
                        .HasForeignKey("LessonDTOId");

                    b.HasOne("DLL.EntityFramework.StudentDTO", "Student")
                        .WithMany("Timesheets")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Timesheet_Student_FK");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GroupDTOStudentDTO", b =>
                {
                    b.HasOne("DLL.EntityFramework.GroupDTO", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DLL.EntityFramework.StudentDTO", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DLL.EntityFramework.CourseDTO", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("Marks");
                });

            modelBuilder.Entity("DLL.EntityFramework.GroupDTO", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Marks");
                });

            modelBuilder.Entity("DLL.EntityFramework.LessonDTO", b =>
                {
                    b.Navigation("Timesheets");
                });

            modelBuilder.Entity("DLL.EntityFramework.StudentDTO", b =>
                {
                    b.Navigation("Marks");

                    b.Navigation("Timesheets");
                });

            modelBuilder.Entity("DLL.EntityFramework.TeacherDTO", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}
