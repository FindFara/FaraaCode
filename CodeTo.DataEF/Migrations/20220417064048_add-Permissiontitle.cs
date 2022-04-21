using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTo.DataEF.Migrations
{
    public partial class addPermissiontitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PermissionTitle",
                table: "RolePermissions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionTitle",
                table: "RolePermissions");
        }
    }
}
