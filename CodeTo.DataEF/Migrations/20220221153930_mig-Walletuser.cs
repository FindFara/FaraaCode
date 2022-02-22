using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTo.DataEF.Migrations
{
    public partial class migWalletuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "WalletsId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WalletsId",
                table: "Users");
        }
    }
}
