using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD_School294.Migrations
{
    public partial class TeachersAndStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentDob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    studentClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentContacts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentContact2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studentContact3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.studentId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    teacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacherSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacherDob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    teacherContacts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentContact2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.teacherId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
