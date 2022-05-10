using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeTo.DataEF.Migrations
{
    public partial class addArticleCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleGroups_ArticleGroupId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ArticleGroupId",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "ArticleCategoryId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleCategoryTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArticleGroupId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleCategory_ArticleGroups_ArticleGroupId",
                        column: x => x.ArticleGroupId,
                        principalTable: "ArticleGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategory_ArticleGroupId",
                table: "ArticleCategory",
                column: "ArticleGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleCategory_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId",
                principalTable: "ArticleCategory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleCategory_ArticleCategoryId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "ArticleCategory");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ArticleCategoryId",
                table: "Articles");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleGroupId",
                table: "Articles",
                column: "ArticleGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleGroups_ArticleGroupId",
                table: "Articles",
                column: "ArticleGroupId",
                principalTable: "ArticleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
