using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTo.DataEF.Migrations
{
    public partial class miByteToint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_WalletTypes_WalletTypeTypeId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_WalletTypeTypeId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "WalletTypeTypeId",
                table: "Wallets");

            migrationBuilder.AlterColumn<int>(
                name: "WalletTypeId",
                table: "Wallets",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_WalletTypeId",
                table: "Wallets",
                column: "WalletTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_WalletTypes_WalletTypeId",
                table: "Wallets",
                column: "WalletTypeId",
                principalTable: "WalletTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_WalletTypes_WalletTypeId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_WalletTypeId",
                table: "Wallets");

            migrationBuilder.AlterColumn<byte>(
                name: "WalletTypeId",
                table: "Wallets",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WalletTypeTypeId",
                table: "Wallets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_WalletTypeTypeId",
                table: "Wallets",
                column: "WalletTypeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_WalletTypes_WalletTypeTypeId",
                table: "Wallets",
                column: "WalletTypeTypeId",
                principalTable: "WalletTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
