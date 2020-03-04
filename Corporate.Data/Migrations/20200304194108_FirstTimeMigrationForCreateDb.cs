using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate.Data.Migrations
{
    public partial class FirstTimeMigrationForCreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPublished = table.Column<bool>(nullable: false),
                    CreationDateTime = table.Column<DateTimeOffset>(nullable: true),
                    DeletedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    EditeDateTime = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Src = table.Column<string>(maxLength: 200, nullable: true),
                    Alternate = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    Size = table.Column<int>(nullable: false),
                    MimType = table.Column<string>(maxLength: 10, nullable: true),
                    SeoName = table.Column<string>(maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
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
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityName = table.Column<string>(maxLength: 50, nullable: true),
                    EntityId = table.Column<int>(nullable: false),
                    TagName = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPublished = table.Column<bool>(nullable: false),
                    CreationDateTime = table.Column<DateTimeOffset>(nullable: true),
                    DeletedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    EditeDateTime = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 180, nullable: false),
                    Content = table.Column<string>(maxLength: 4000, nullable: true),
                    Link = table.Column<string>(maxLength: 400, nullable: true),
                    Description = table.Column<string>(maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPublished = table.Column<bool>(nullable: false),
                    CreationDateTime = table.Column<DateTimeOffset>(nullable: true),
                    DeletedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    EditeDateTime = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 180, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 120, nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IncludeInTopMenu = table.Column<bool>(nullable: false),
                    Metakeword = table.Column<string>(maxLength: 300, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 300, nullable: true),
                    PictureId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPublished = table.Column<bool>(nullable: false),
                    CreationDateTime = table.Column<DateTimeOffset>(nullable: true),
                    DeletedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    EditeDateTime = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 120, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    SourceAddress = table.Column<string>(maxLength: 400, nullable: true),
                    SourceName = table.Column<string>(maxLength: 100, nullable: true),
                    PictureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_ProductPictureMapping_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPictureMapping_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityIdentify = table.Column<string>(nullable: true),
                    EntityId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    TranslateKey = table.Column<string>(nullable: true),
                    TranslateValue = table.Column<string>(nullable: true),
                    TopicId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translates_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_ProductCategoryMappings_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
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
                name: "NewsCategoryMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategoryMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsCategoryMappings_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsCategoryMappings_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_PictureId",
                table: "Category",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_News_PictureId",
                table: "News",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsCategoryMappings_CategoryId",
                table: "NewsCategoryMappings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsCategoryMappings_NewsId",
                table: "NewsCategoryMappings",
                column: "NewsId");

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
                name: "IX_Translates_TopicId",
                table: "Translates",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsCategoryMappings");

            migrationBuilder.DropTable(
                name: "ProductCategoryMappings");

            migrationBuilder.DropTable(
                name: "ProductPictureMapping");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Translates");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}
