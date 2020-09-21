﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate.Data.Migrations
{
    public partial class FirstGeneration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPublished = table.Column<bool>(nullable: false),
                    CreationDateTime = table.Column<DateTimeOffset>(nullable: true),
                    DeletedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    EditeDateTime = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IncludeInTopMenu = table.Column<bool>(nullable: false),
                    Metakeword = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    PictureId = table.Column<int>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}