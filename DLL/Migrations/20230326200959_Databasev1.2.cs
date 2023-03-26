using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DLL.Migrations
{
    /// <inheritdoc />
    public partial class Databasev12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_ClassesDTO_ClassesDTOId",
                table: "Timesheets");

            migrationBuilder.DropTable(
                name: "ClassesDTO");

            migrationBuilder.RenameColumn(
                name: "ClassesDTOId",
                table: "Timesheets",
                newName: "LessonDTOId");

            migrationBuilder.RenameIndex(
                name: "IX_Timesheets_ClassesDTOId",
                table: "Timesheets",
                newName: "IX_Timesheets_LessonDTOId");

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    CourseDTOId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_CourseDTOId",
                        column: x => x.CourseDTOId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseDTOId",
                table: "Lessons",
                column: "CourseDTOId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_Lessons_LessonDTOId",
                table: "Timesheets",
                column: "LessonDTOId",
                principalTable: "Lessons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_Lessons_LessonDTOId",
                table: "Timesheets");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.RenameColumn(
                name: "LessonDTOId",
                table: "Timesheets",
                newName: "ClassesDTOId");

            migrationBuilder.RenameIndex(
                name: "IX_Timesheets_LessonDTOId",
                table: "Timesheets",
                newName: "IX_Timesheets_ClassesDTOId");

            migrationBuilder.CreateTable(
                name: "ClassesDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseDTOId = table.Column<int>(type: "int", nullable: false),
                    ClassesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassesDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassesDTO_Courses_CourseDTOId",
                        column: x => x.CourseDTOId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassesDTO_CourseDTOId",
                table: "ClassesDTO",
                column: "CourseDTOId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_ClassesDTO_ClassesDTOId",
                table: "Timesheets",
                column: "ClassesDTOId",
                principalTable: "ClassesDTO",
                principalColumn: "Id");
        }
    }
}
