using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ezBet.WebAPI.Model.Migrations
{
    public partial class UserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "public",
                table: "task");

            migrationBuilder.AddColumn<string>(
                name: "Info",
                schema: "public",
                table: "task",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "State",
                schema: "public",
                table: "task",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "user",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "Info",
                schema: "public",
                table: "task");

            migrationBuilder.DropColumn(
                name: "State",
                schema: "public",
                table: "task");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                schema: "public",
                table: "task",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
