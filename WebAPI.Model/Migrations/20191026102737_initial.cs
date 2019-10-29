using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebAPI.Model.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "game",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    BetStartDate = table.Column<DateTime>(nullable: false),
                    BetEndDate = table.Column<DateTime>(nullable: false),
                    GameState = table.Column<string>(maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "bet",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Score = table.Column<string>(nullable: true),
                    GameID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_bet_game_GameID",
                        column: x => x.GameID,
                        principalSchema: "public",
                        principalTable: "game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bet_GameID",
                schema: "public",
                table: "bet",
                column: "GameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bet",
                schema: "public");

            migrationBuilder.DropTable(
                name: "game",
                schema: "public");
        }
    }
}
