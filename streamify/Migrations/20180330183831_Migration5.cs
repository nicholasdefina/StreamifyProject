using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace streamify.Migrations
{
    public partial class Migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Music_Playlists_PlaylistId",
                table: "Music");

            migrationBuilder.AlterColumn<int>(
                name: "PlaylistId",
                table: "Music",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Music_Playlists_PlaylistId",
                table: "Music",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "PlaylistId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Music_Playlists_PlaylistId",
                table: "Music");

            migrationBuilder.AlterColumn<int>(
                name: "PlaylistId",
                table: "Music",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Music_Playlists_PlaylistId",
                table: "Music",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "PlaylistId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
