using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeTo.DataEF.Migrations
{
    public partial class Categoriadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategory_ArticleGroups_ArticleGroupId",
                table: "ArticleCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleCategory_ArticleCategoryId",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleCategory",
                table: "ArticleCategory");

            migrationBuilder.RenameTable(
                name: "ArticleCategory",
                newName: "ArticlesCategory");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleCategory_ArticleGroupId",
                table: "ArticlesCategory",
                newName: "IX_ArticlesCategory_ArticleGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticlesCategory",
                table: "ArticlesCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticlesCategory_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId",
                principalTable: "ArticlesCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlesCategory_ArticleGroups_ArticleGroupId",
                table: "ArticlesCategory",
                column: "ArticleGroupId",
                principalTable: "ArticleGroups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticlesCategory_ArticleCategoryId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticlesCategory_ArticleGroups_ArticleGroupId",
                table: "ArticlesCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticlesCategory",
                table: "ArticlesCategory");

            migrationBuilder.RenameTable(
                name: "ArticlesCategory",
                newName: "ArticleCategory");

            migrationBuilder.RenameIndex(
                name: "IX_ArticlesCategory_ArticleGroupId",
                table: "ArticleCategory",
                newName: "IX_ArticleCategory_ArticleGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleCategory",
                table: "ArticleCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategory_ArticleGroups_ArticleGroupId",
                table: "ArticleCategory",
                column: "ArticleGroupId",
                principalTable: "ArticleGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleCategory_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId",
                principalTable: "ArticleCategory",
                principalColumn: "Id");
        }
    }
}
