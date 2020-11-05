using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate.Data.Migrations
{
    public partial class ProductCategoryMappingAndProductPictureMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationDateTime",
                table: "Categories",
                nullable: true,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 5, 18, 38, 58, 79, DateTimeKind.Unspecified).AddTicks(397), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true,
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 10, 19, 19, 46, 23, 588, DateTimeKind.Unspecified).AddTicks(4593), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPublished = table.Column<bool>(nullable: false),
                    CreationDateTime = table.Column<DateTimeOffset>(nullable: true),
                    DeletedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    EditeDateTime = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Src = table.Column<string>(nullable: true),
                    Alternate = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    MimType = table.Column<string>(nullable: true),
                    SeoName = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPublished = table.Column<bool>(nullable: false),
                    CreationDateTime = table.Column<DateTimeOffset>(nullable: true),
                    DeletedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    EditeDateTime = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 85, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    ShortDescription = table.Column<string>(maxLength: 210, nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategoryMappings_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoryMappings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPictureMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    PictureId = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPictureMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPictureMapping_Picture_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Picture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPictureMapping_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryMappings_CategoryId",
                table: "ProductCategoryMappings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryMappings_ProductId",
                table: "ProductCategoryMappings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictureMapping_PictureId",
                table: "ProductPictureMapping",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictureMapping_ProductId",
                table: "ProductPictureMapping",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductId",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductName",
                table: "Products",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder?.DropTable(
                name: "ProductCategoryMappings");

            migrationBuilder.DropTable(
                name: "ProductPictureMapping");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationDateTime",
                table: "Categories",
                type: "datetimeoffset",
                nullable: true,
                defaultValue: new DateTimeOffset(new DateTime(2020, 10, 19, 19, 46, 23, 588, DateTimeKind.Unspecified).AddTicks(4593), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true,
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 5, 18, 38, 58, 79, DateTimeKind.Unspecified).AddTicks(397), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
