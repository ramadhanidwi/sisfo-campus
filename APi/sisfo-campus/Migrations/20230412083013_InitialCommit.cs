using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sisfo_campus.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:APi/sisfo-campus/Migrations/20230411064559_initialCommit.cs
    public partial class initialCommit : Migration
========
    public partial class InitialCommit : Migration
>>>>>>>> rama:APi/sisfo-campus/Migrations/20230412083013_InitialCommit.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_faculties",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    building = table.Column<int>(type: "int", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_faculties", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_lecturers",
                columns: table => new
                {
                    nik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    degree = table.Column<string>(type: "nchar(2)", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_lecturers", x => x.nik);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_majors",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    faculty_code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_majors", x => x.code);
                    table.ForeignKey(
                        name: "FK_tb_m_majors_tb_m_faculties_faculty_code",
                        column: x => x.faculty_code,
                        principalTable: "tb_m_faculties",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_courses",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    units = table.Column<int>(type: "int", nullable: false),
                    major_code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_courses", x => x.code);
                    table.ForeignKey(
                        name: "FK_tb_m_courses_tb_m_majors_major_code",
                        column: x => x.major_code,
                        principalTable: "tb_m_majors",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "tb_m_students",
                columns: table => new
                {
                    nim = table.Column<string>(type: "nchar(5)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    major_code = table.Column<int>(type: "int", nullable: true),
                    course_code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_students", x => x.nim);
                    table.ForeignKey(
                        name: "FK_tb_m_students_tb_m_courses_course_code",
                        column: x => x.course_code,
                        principalTable: "tb_m_courses",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_tb_m_students_tb_m_majors_major_code",
                        column: x => x.major_code,
                        principalTable: "tb_m_majors",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "tb_m_accounts",
                columns: table => new
                {
                    student_nim = table.Column<string>(type: "nchar(5)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_accounts", x => x.student_nim);
                    table.ForeignKey(
                        name: "FK_tb_m_accounts_tb_m_students_student_nim",
                        column: x => x.student_nim,
                        principalTable: "tb_m_students",
                        principalColumn: "nim",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_assignments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    upload_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    score = table.Column<int>(type: "int", nullable: true),
                    course_code = table.Column<int>(type: "int", nullable: false),
                    student_nim = table.Column<string>(type: "nchar(5)", nullable: true),
                    lecturer_nik = table.Column<int>(type: "int", nullable: false),
                    attachment_file_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_assignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_assignments_tb_m_courses_course_code",
                        column: x => x.course_code,
                        principalTable: "tb_m_courses",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_assignments_tb_m_lecturers_lecturer_nik",
                        column: x => x.lecturer_nik,
                        principalTable: "tb_m_lecturers",
                        principalColumn: "nik",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_assignments_tb_m_students_student_nim",
                        column: x => x.student_nim,
                        principalTable: "tb_m_students",
                        principalColumn: "nim");
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_account_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<string>(type: "nchar(5)", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_account_roles", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_tr_account_roles_tb_m_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "tb_m_accounts",
                        principalColumn: "student_nim",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_account_roles_tb_m_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "tb_m_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_attachment_files",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_path = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    content_type = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    file_name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    length = table.Column<long>(type: "bigint", nullable: false),
                    AttachmentFileId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_attachment_files", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_attachment_files_tb_m_assignments_AttachmentFileId",
                        column: x => x.AttachmentFileId,
                        principalTable: "tb_m_assignments",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Lecturer" },
                    { 3, "Student" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_assignments_course_code",
                table: "tb_m_assignments",
                column: "course_code");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_assignments_lecturer_nik",
                table: "tb_m_assignments",
                column: "lecturer_nik");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_assignments_student_nim",
                table: "tb_m_assignments",
                column: "student_nim");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_attachment_files_AttachmentFileId",
                table: "tb_m_attachment_files",
                column: "AttachmentFileId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_courses_major_code",
                table: "tb_m_courses",
                column: "major_code");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_majors_faculty_code",
                table: "tb_m_majors",
                column: "faculty_code");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_students_course_code",
                table: "tb_m_students",
                column: "course_code");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_students_major_code",
                table: "tb_m_students",
                column: "major_code");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_roles_account_id",
                table: "tb_tr_account_roles",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_roles_role_id",
                table: "tb_tr_account_roles",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_attachment_files");

            migrationBuilder.DropTable(
                name: "tb_tr_account_roles");

            migrationBuilder.DropTable(
                name: "tb_m_assignments");

            migrationBuilder.DropTable(
                name: "tb_m_accounts");

            migrationBuilder.DropTable(
                name: "tb_m_roles");

            migrationBuilder.DropTable(
                name: "tb_m_lecturers");

            migrationBuilder.DropTable(
                name: "tb_m_students");

            migrationBuilder.DropTable(
                name: "tb_m_courses");

            migrationBuilder.DropTable(
                name: "tb_m_majors");

            migrationBuilder.DropTable(
                name: "tb_m_faculties");
        }
    }
}
