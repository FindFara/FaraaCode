using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeTo.DataEF.Migrations
{
    public partial class romoveadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticlesCategory_ArticleCategoryId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "ArticlesCategory");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ArticleCategoryId",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "ArticleGroups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleGroupId",
                table: "Articles",
                column: "ArticleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleGroups_ParentID",
                table: "ArticleGroups",
                column: "ParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleGroups_ArticleGroups_ParentID",
                table: "ArticleGroups",
                column: "ParentID",
                principalTable: "ArticleGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleGroups_ArticleGroupId",
                table: "Articles",
                column: "ArticleGroupId",
                principalTable: "ArticleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleGroups_ArticleGroups_ParentID",
                table: "ArticleGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleGroups_ArticleGroupId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ArticleGroupId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_ArticleGroups_ParentID",
                table: "ArticleGroups");

            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "ArticleGroups");

            migrationBuilder.AddColumn<int>(
                name: "ArticleCategoryId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArticlesCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleGroupId = table.Column<int>(type: "int", nullable: true),
                    ArticleCategoryTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlesCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticlesCategory_ArticleGroups_ArticleGroupId",
                        column: x => x.ArticleGroupId,
                        principalTable: "ArticleGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticlesCategory_ArticleGroupId",
                table: "ArticlesCategory",
                column: "ArticleGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticlesCategory_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId",
                principalTable: "ArticlesCategory",
                principalColumn: "Id");
        }
    }
}
