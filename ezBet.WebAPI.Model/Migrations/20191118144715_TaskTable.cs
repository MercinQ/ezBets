using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ezBet.WebAPI.Model.Migrations
{
    public partial class TaskTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bet_game_GameID",
                schema: "public",
                table: "bet");

            migrationBuilder.RenameColumn(
                name: "GameID",
                schema: "public",
                table: "bet",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_bet_GameID",
                schema: "public",
                table: "bet",
                newName: "IX_bet_GameId");

            migrationBuilder.CreateTable(
                name: "task",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Type = table.Column<byte>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_bet_game_GameId",
                schema: "public",
                table: "bet",
                column: "GameId",
                principalSchema: "public",
                principalTable: "game",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bet_game_GameId",
                schema: "public",
                table: "bet");

            migrationBuilder.DropTable(
                name: "task",
                schema: "public");

            migrationBuilder.RenameColumn(
                name: "GameId",
                schema: "public",
                table: "bet",
                newName: "GameID");

            migrationBuilder.RenameIndex(
                name: "IX_bet_GameId",
                schema: "public",
                table: "bet",
                newName: "IX_bet_GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_bet_game_GameID",
                schema: "public",
                table: "bet",
                column: "GameID",
                principalSchema: "public",
                principalTable: "game",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
