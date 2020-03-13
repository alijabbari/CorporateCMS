using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate.Data.Migrations
{
    public partial class ChangeRelationKeyProductCategoryMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PictureId1",
                table: "ProductPictureMapping",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Culture = table.Column<string>(maxLength: 6, nullable: false),
                    Rtl = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    Default = table.Column<bool>(nullable: false),
                    SEOName = table.Column<string>(maxLength: 6, nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictureMapping_PictureId1",
                table: "ProductPictureMapping",
                column: "PictureId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPictureMapping_Pictures_PictureId1",
                table: "ProductPictureMapping",
                column: "PictureId1",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPictureMapping_Pictures_PictureId1",
                table: "ProductPictureMapping");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_ProductPictureMapping_PictureId1",
                table: "ProductPictureMapping");

            migrationBuilder.DropColumn(
                name: "PictureId1",
                table: "ProductPictureMapping");
        }
    }
}
