using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NM.Studio.Data.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Service",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Tittle",
                table: "Service",
                newName: "Src");

            migrationBuilder.AddColumn<Guid>(
                name: "OutfitId",
                table: "Photo",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_OutfitId",
                table: "Photo",
                column: "OutfitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Outfit_OutfitId",
                table: "Photo",
                column: "OutfitId",
                principalTable: "Outfit",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Outfit_OutfitId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_OutfitId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "OutfitId",
                table: "Photo");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Service",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Src",
                table: "Service",
                newName: "Tittle");
        }
    }
}
