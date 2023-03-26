using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DLL.Migrations
{
    /// <inheritdoc />
    public partial class Databasev13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Groups_GroupId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Teachers_TeacherId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_CourseDTOId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_Students_UserId",
                table: "Timesheets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Timesheets",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Timesheets_UserId",
                table: "Timesheets",
                newName: "IX_Timesheets_StudentId");

            migrationBuilder.RenameColumn(
                name: "CourseDTOId",
                table: "Lessons",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "ClassesDate",
                table: "Lessons",
                newName: "LessonDate");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_CourseDTOId",
                table: "Lessons",
                newName: "IX_Lessons_CourseId");

            migrationBuilder.AddForeignKey(
                name: "Course_Group_FK",
                table: "Courses",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Group_Teacher_FK",
                table: "Groups",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Lesson_Group_FK",
                table: "Lessons",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Timesheet_Student_FK",
                table: "Timesheets",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Course_Group_FK",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "Group_Teacher_FK",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "Lesson_Group_FK",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "Timesheet_Student_FK",
                table: "Timesheets");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Timesheets",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Timesheets_StudentId",
                table: "Timesheets",
                newName: "IX_Timesheets_UserId");

            migrationBuilder.RenameColumn(
                name: "LessonDate",
                table: "Lessons",
                newName: "ClassesDate");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Lessons",
                newName: "CourseDTOId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                newName: "IX_Lessons_CourseDTOId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Groups_GroupId",
                table: "Courses",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Teachers_TeacherId",
                table: "Groups",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_CourseDTOId",
                table: "Lessons",
                column: "CourseDTOId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_Students_UserId",
                table: "Timesheets",
                column: "UserId",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
