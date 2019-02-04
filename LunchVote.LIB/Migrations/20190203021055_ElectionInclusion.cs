using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LunchVote.LIB.Migrations
{
    public partial class ElectionInclusion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ElectionId",
                table: "Votes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Elections",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ElectionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elections", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ElectionId",
                table: "Votes",
                column: "ElectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Elections_ElectionId",
                table: "Votes",
                column: "ElectionId",
                principalTable: "Elections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Elections_ElectionId",
                table: "Votes");

            migrationBuilder.DropTable(
                name: "Elections");

            migrationBuilder.DropIndex(
                name: "IX_Votes_ElectionId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "ElectionId",
                table: "Votes");
        }
    }
}
