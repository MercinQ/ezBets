using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Model.Migrations
{
    public partial class adduser4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hash",
                schema: "public",
                table: "user",
                newName: "Salt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salt",
                schema: "public",
                table: "user",
                newName: "Hash");
        }
    }
}
