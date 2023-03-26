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
    [Migration("20230326200959_Databasev1.2")]
    partial class Databasev12
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

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
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

                    b.Property<int>("TeacherId")
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

                    b.Property<DateTime>("ClassesDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CourseDTOId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CourseDTOId");

                    b.ToTable("Lessons", (string)null);
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

                    b.Property<string>("Name")
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

                    b.Property<float>("Mark")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonDTOId");

                    b.HasIndex("UserId");

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
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DLL.EntityFramework.TeacherDTO", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .IsRequired()
                        .HasConstraintName("Course_Teacher_FK");

                    b.Navigation("Group");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("DLL.EntityFramework.GroupDTO", b =>
                {
                    b.HasOne("DLL.EntityFramework.TeacherDTO", "Teacher")
                        .WithMany("Groups")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("DLL.EntityFramework.LessonDTO", b =>
                {
                    b.HasOne("DLL.EntityFramework.CourseDTO", "CourseDTO")
                        .WithMany("Classes")
                        .HasForeignKey("CourseDTOId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseDTO");
                });

            modelBuilder.Entity("DLL.EntityFramework.TimesheetDTO", b =>
                {
                    b.HasOne("DLL.EntityFramework.LessonDTO", null)
                        .WithMany("Timesheets")
                        .HasForeignKey("LessonDTOId");

                    b.HasOne("DLL.EntityFramework.StudentDTO", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("DLL.EntityFramework.LessonDTO", b =>
                {
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
