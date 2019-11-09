using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Model.Migrations
{
    public partial class adduser : Migration
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
