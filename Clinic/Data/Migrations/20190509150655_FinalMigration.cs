using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.Data.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "patients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "insurances",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "doctors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "assistants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "insurances");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "assistants");
        }
    }
}
