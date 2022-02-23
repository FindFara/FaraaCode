using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTo.DataEF.Migrations
{
    public partial class Databaseee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ISpay",
                table: "Wallets",
                newName: "Ispay");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Wallets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ispay",
                table: "Wallets",
                newName: "ISpay");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Wallets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
