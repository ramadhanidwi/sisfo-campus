﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sisfo_campus.Contexts;

#nullable disable

namespace sisfo_campus.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230410185231_InitalCommit")]
    partial class InitalCommit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("sisfo_campus.Models.Account", b =>
                {
                    b.Property<string>("StudentNim")
                        .HasColumnType("nchar(5)")
                        .HasColumnName("student_nim");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.HasKey("StudentNim");

                    b.ToTable("tb_m_accounts");
                });

            modelBuilder.Entity("sisfo_campus.Models.AccountRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nchar(5)")
                        .HasColumnName("account_id");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("tb_tr_account_roles");
                });

            modelBuilder.Entity("sisfo_campus.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseCode")
                        .HasColumnType("int")
                        .HasColumnName("course_code");

                    b.Property<int>("LecturerNik")
                        .HasColumnType("int")
                        .HasColumnName("lecturer_nik");

                    b.Property<int?>("Score")
                        .HasColumnType("int")
                        .HasColumnName("score");

                    b.Property<string>("StudentNim")
                        .HasColumnType("nchar(5)")
                        .HasColumnName("student_nim");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("upload_date");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CourseCode");

                    b.HasIndex("LecturerNik");

                    b.HasIndex("StudentNim");

                    b.ToTable("tb_m_assignments");
                });

            modelBuilder.Entity("sisfo_campus.Models.Course", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("code");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Code"));

                    b.Property<int?>("MajorCode")
                        .HasColumnType("int")
                        .HasColumnName("major_code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("Units")
                        .HasColumnType("int")
                        .HasColumnName("units");

                    b.HasKey("Code");

                    b.HasIndex("MajorCode");

                    b.ToTable("tb_m_courses");
                });

            modelBuilder.Entity("sisfo_campus.Models.Faculty", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("code");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Code"));

                    b.Property<int>("Building")
                        .HasColumnType("int")
                        .HasColumnName("building");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("Code");

                    b.ToTable("tb_m_faculties");
                });

            modelBuilder.Entity("sisfo_campus.Models.Lecturer", b =>
                {
                    b.Property<int>("Nik")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("nik");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Nik"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("address");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nchar(2)")
                        .HasColumnName("degree");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("Nik");

                    b.ToTable("tb_m_lecturers");
                });

            modelBuilder.Entity("sisfo_campus.Models.Major", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("code");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Code"));

                    b.Property<int>("FacultyCode")
                        .HasColumnType("int")
                        .HasColumnName("faculty_code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Code");

                    b.HasIndex("FacultyCode");

                    b.ToTable("tb_m_majors");
                });

            modelBuilder.Entity("sisfo_campus.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("tb_m_roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Lecturer"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Student"
                        });
                });

            modelBuilder.Entity("sisfo_campus.Models.Student", b =>
                {
                    b.Property<string>("Nim")
                        .HasColumnType("nchar(5)")
                        .HasColumnName("nim");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("address");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthdate");

                    b.Property<int?>("CourseCode")
                        .HasColumnType("int")
                        .HasColumnName("course_code");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<int?>("MajorCode")
                        .HasColumnType("int")
                        .HasColumnName("major_code");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("Nim");

                    b.HasIndex("CourseCode");

                    b.HasIndex("MajorCode");

                    b.ToTable("tb_m_students");
                });

            modelBuilder.Entity("sisfo_campus.Models.Account", b =>
                {
                    b.HasOne("sisfo_campus.Models.Student", "Student")
                        .WithOne("Account")
                        .HasForeignKey("sisfo_campus.Models.Account", "StudentNim")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("sisfo_campus.Models.AccountRole", b =>
                {
                    b.HasOne("sisfo_campus.Models.Account", "Account")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sisfo_campus.Models.Role", "Role")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("sisfo_campus.Models.Assignment", b =>
                {
                    b.HasOne("sisfo_campus.Models.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sisfo_campus.Models.Lecturer", "Lecturer")
                        .WithMany("Assignments")
                        .HasForeignKey("LecturerNik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sisfo_campus.Models.Student", "Student")
                        .WithMany("Assignment")
                        .HasForeignKey("StudentNim");

                    b.Navigation("Course");

                    b.Navigation("Lecturer");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("sisfo_campus.Models.Course", b =>
                {
                    b.HasOne("sisfo_campus.Models.Major", "Major")
                        .WithMany("Courses")
                        .HasForeignKey("MajorCode");

                    b.Navigation("Major");
                });

            modelBuilder.Entity("sisfo_campus.Models.Major", b =>
                {
                    b.HasOne("sisfo_campus.Models.Faculty", "Faculty")
                        .WithMany("Majors")
                        .HasForeignKey("FacultyCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("sisfo_campus.Models.Student", b =>
                {
                    b.HasOne("sisfo_campus.Models.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseCode");

                    b.HasOne("sisfo_campus.Models.Major", "Major")
                        .WithMany()
                        .HasForeignKey("MajorCode");

                    b.Navigation("Course");

                    b.Navigation("Major");
                });

            modelBuilder.Entity("sisfo_campus.Models.Account", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("sisfo_campus.Models.Course", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("sisfo_campus.Models.Faculty", b =>
                {
                    b.Navigation("Majors");
                });

            modelBuilder.Entity("sisfo_campus.Models.Lecturer", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("sisfo_campus.Models.Major", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("sisfo_campus.Models.Role", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("sisfo_campus.Models.Student", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("Assignment");
                });
#pragma warning restore 612, 618
        }
    }
}
