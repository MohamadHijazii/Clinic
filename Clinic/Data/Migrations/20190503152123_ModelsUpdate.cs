using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.Data.Migrations
{
    public partial class ModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_insurances_insurance",
                table: "patients");

            migrationBuilder.RenameColumn(
                name: "insurance",
                table: "patients",
                newName: "insurance_id");

            migrationBuilder.RenameIndex(
                name: "IX_patients_insurance",
                table: "patients",
                newName: "IX_patients_insurance_id");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_insurances_insurance_id",
                table: "patients",
                column: "insurance_id",
                principalTable: "insurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_insurances_insurance_id",
                table: "patients");

            migrationBuilder.RenameColumn(
                name: "insurance_id",
                table: "patients",
                newName: "insurance");

            migrationBuilder.RenameIndex(
                name: "IX_patients_insurance_id",
                table: "patients",
                newName: "IX_patients_insurance");
     

            migrationBuilder.AddForeignKey(
                name: "FK_patients_insurances_insurance",
                table: "patients",
                column: "insurance",
                principalTable: "insurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
