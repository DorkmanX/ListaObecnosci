using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DLL.Migrations
{
    /// <inheritdoc />
    public partial class MarksReimplemented : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Marks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Marks_GroupId",
                table: "Marks",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "Marks_Group_FK",
                table: "Marks",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Marks_Group_FK",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_GroupId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Marks");
        }
    }
}
