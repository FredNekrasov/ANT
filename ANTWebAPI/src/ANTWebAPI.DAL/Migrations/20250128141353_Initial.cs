using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANTWebAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ANTCatalogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANTCatalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ANTArticles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catalog_id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_or_banner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANTArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ANTArticles_ANTCatalogs_catalog_id",
                        column: x => x.catalog_id,
                        principalTable: "ANTCatalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ANTContents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    article_id = table.Column<long>(type: "bigint", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANTContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ANTContents_ANTArticles_article_id",
                        column: x => x.article_id,
                        principalTable: "ANTArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ANTArticles_catalog_id",
                table: "ANTArticles",
                column: "catalog_id");

            migrationBuilder.CreateIndex(
                name: "IX_ANTContents_article_id",
                table: "ANTContents",
                column: "article_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ANTContents");

            migrationBuilder.DropTable(
                name: "ANTArticles");

            migrationBuilder.DropTable(
                name: "ANTCatalogs");
        }
    }
}
