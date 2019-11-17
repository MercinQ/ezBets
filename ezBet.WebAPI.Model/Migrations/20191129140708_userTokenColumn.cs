using Microsoft.EntityFrameworkCore.Migrations;

namespace ezBet.WebAPI.Model.Migrations
{
    public partial class userTokenColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResetPasswordToken",
                schema: "public",
                table: "user",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetPasswordToken",
                schema: "public",
                table: "user");
        }
    }
}
