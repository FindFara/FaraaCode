using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeTo.DataEF.Migrations
{
    public partial class addvisitcountarticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VisitCount",
                table: "Articles",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitCount",
                table: "Articles");
        }
    }
}
