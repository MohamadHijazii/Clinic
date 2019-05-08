using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.Data.Migrations
{
    public partial class ModificationModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "blood_type",
                table: "patients",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "blood_type",
                table: "patients",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
