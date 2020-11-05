using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Corporate.Data.Migrations
{
    public partial class AddDefaultValueForCreationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationDateTime",
                table: "Categories",
                nullable: true,
                defaultValue: new DateTimeOffset(new DateTime(2020, 10, 19, 19, 46, 23, 588, DateTimeKind.Unspecified).AddTicks(4593), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationDateTime",
                table: "Categories",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true,
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 10, 19, 19, 46, 23, 588, DateTimeKind.Unspecified).AddTicks(4593), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
