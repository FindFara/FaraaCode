using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeTo.DataEF.Migrations
{
    public partial class commentarticloooo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleComments_Articles_ArticleId1",
                table: "ArticleComments");

            migrationBuilder.DropIndex(
                name: "IX_ArticleComments_ArticleId1",
                table: "ArticleComments");

            migrationBuilder.DropColumn(
                name: "ArticleId1",
                table: "ArticleComments");

            migrationBuilder.AlterColumn<long>(
                name: "ArticleId",
                table: "ArticleComments",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_ArticleId",
                table: "ArticleComments",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleComments_Articles_ArticleId",
                table: "ArticleComments",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleComments_Articles_ArticleId",
                table: "ArticleComments");

            migrationBuilder.DropIndex(
                name: "IX_ArticleComments_ArticleId",
                table: "ArticleComments");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "ArticleComments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ArticleId1",
                table: "ArticleComments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_ArticleId1",
                table: "ArticleComments",
                column: "ArticleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleComments_Articles_ArticleId1",
                table: "ArticleComments",
                column: "ArticleId1",
                principalTable: "Articles",
                principalColumn: "Id");
        }
    }
}
