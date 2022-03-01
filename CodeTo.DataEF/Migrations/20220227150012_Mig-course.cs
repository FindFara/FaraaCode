using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTo.DataEF.Migrations
{
    public partial class Migcourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DemoFileName",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "ArticleTitle",
                table: "ArticleGroups",
                newName: "ArticleGroupTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArticleGroupTitle",
                table: "ArticleGroups",
                newName: "ArticleTitle");

            migrationBuilder.AddColumn<string>(
                name: "DemoFileName",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
