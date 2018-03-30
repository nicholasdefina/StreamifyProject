using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace streamify.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Album",
                table: "Music");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Album",
                table: "Music",
                nullable: true);
        }
    }
}
