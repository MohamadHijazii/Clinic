using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.Data.Migrations
{
    public partial class AddApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fname",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lname",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mname",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "lname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "mname",
                table: "AspNetUsers");
        }
    }
}
