using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate.Data.Migrations
{
    public partial class RemoveSelfReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                newName: "IX_ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryId",
                table: "Categories",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryId",
                table: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_ParentId",
                table: "Categories",
                newName: "IX_Categories_ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
