using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTo.DataEF.Migrations
{
    public partial class migDelWallet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WalletsId",
                table: "WalletTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "WalletsId",
                table: "WalletTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
