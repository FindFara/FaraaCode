using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTo.DataEF.Migrations
{
    public partial class addparentid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "RolePermissions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_ParentId",
                table: "RolePermissions",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_RolePermissions_ParentId",
                table: "RolePermissions",
                column: "ParentId",
                principalTable: "RolePermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_RolePermissions_ParentId",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_ParentId",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "RolePermissions");
        }
    }
}
