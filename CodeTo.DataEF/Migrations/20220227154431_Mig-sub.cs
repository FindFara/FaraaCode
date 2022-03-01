using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTo.DataEF.Migrations
{
    public partial class Migsub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubGroup",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SubGroup",
                table: "Courses",
                column: "SubGroup");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseGroups_SubGroup",
                table: "Courses",
                column: "SubGroup",
                principalTable: "CourseGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseGroups_SubGroup",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_SubGroup",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SubGroup",
                table: "Courses");
        }
    }
}
