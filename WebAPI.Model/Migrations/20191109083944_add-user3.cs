using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Model.Migrations
{
    public partial class adduser3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "public",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "public",
                newName: "user",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "user",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "public",
                table: "user",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                schema: "public",
                table: "user",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                schema: "public",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                schema: "public",
                newName: "Users",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "public",
                table: "Users",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "public",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "public",
                table: "Users",
                column: "Id");
        }
    }
}
