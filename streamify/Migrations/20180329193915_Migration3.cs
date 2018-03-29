using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace streamify.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlbumArt",
                table: "Music");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlbumArt",
                table: "Music",
                nullable: true);
        }
    }
}
