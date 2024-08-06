using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NM.Studio.Data.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Outfits",
                table: "Outfits");

            migrationBuilder.RenameTable(
                name: "Outfits",
                newName: "Outfit");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Photo",
                newName: "Title");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Service",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Photo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AlbumId",
                table: "Photo",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Photo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Href",
                table: "Photo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Src",
                table: "Photo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Outfit",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Outfit",
                table: "Outfit",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AlbumId",
                table: "Photo",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Album_AlbumId",
                table: "Photo",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Album_AlbumId",
                table: "Photo");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropIndex(
                name: "IX_Photo_AlbumId",
                table: "Photo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Outfit",
                table: "Outfit");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "Href",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "Src",
                table: "Photo");

            migrationBuilder.RenameTable(
                name: "Outfit",
                newName: "Outfits");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Photo",
                newName: "Url");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Service",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Photo",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Outfits",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Outfits",
                table: "Outfits",
                column: "Id");
        }
    }
}
