using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.Data.Migrations
{
    public partial class MigrationReminder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reminder_Admins_admins_adminId",
                table: "reminder_Admins");

            migrationBuilder.DropTable(
                name: "reminder_Assistants");

            migrationBuilder.DropTable(
                name: "reminder_Doctors");

            migrationBuilder.DropTable(
                name: "reminder_Insurances");

            migrationBuilder.DropTable(
                name: "reminder_Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reminder_Admins",
                table: "reminder_Admins");

            migrationBuilder.DropIndex(
                name: "IX_reminder_Admins_adminId",
                table: "reminder_Admins");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "assistants");

            migrationBuilder.DropColumn(
                name: "adminId",
                table: "reminder_Admins");

            migrationBuilder.DropColumn(
                name: "priority",
                table: "reminder_Admins");

            migrationBuilder.RenameTable(
                name: "reminder_Admins",
                newName: "reminders");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "reminders",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_reminders",
                table: "reminders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_reminders_UserID",
                table: "reminders",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_reminders_AspNetUsers_UserID",
                table: "reminders",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reminders_AspNetUsers_UserID",
                table: "reminders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reminders",
                table: "reminders");

            migrationBuilder.DropIndex(
                name: "IX_reminders_UserID",
                table: "reminders");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "reminders");

            migrationBuilder.RenameTable(
                name: "reminders",
                newName: "reminder_Admins");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "patients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "doctors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "assistants",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "adminId",
                table: "reminder_Admins",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "priority",
                table: "reminder_Admins",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_reminder_Admins",
                table: "reminder_Admins",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "reminder_Assistants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    assistantId = table.Column<int>(nullable: true),
                    content = table.Column<string>(maxLength: 300, nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    priority = table.Column<string>(maxLength: 10, nullable: true),
                    time = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reminder_Assistants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reminder_Assistants_assistants_assistantId",
                        column: x => x.assistantId,
                        principalTable: "assistants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reminder_Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    content = table.Column<string>(maxLength: 300, nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    doctorId = table.Column<int>(nullable: true),
                    priority = table.Column<string>(maxLength: 10, nullable: true),
                    time = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reminder_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reminder_Doctors_doctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reminder_Insurances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    content = table.Column<string>(maxLength: 300, nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    insuranceId = table.Column<int>(nullable: true),
                    priority = table.Column<string>(maxLength: 10, nullable: true),
                    time = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reminder_Insurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reminder_Insurances_insurances_insuranceId",
                        column: x => x.insuranceId,
                        principalTable: "insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reminder_Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    content = table.Column<string>(maxLength: 300, nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    patientId = table.Column<int>(nullable: true),
                    priority = table.Column<string>(maxLength: 10, nullable: true),
                    time = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reminder_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reminder_Patients_patients_patientId",
                        column: x => x.patientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reminder_Admins_adminId",
                table: "reminder_Admins",
                column: "adminId");

            migrationBuilder.CreateIndex(
                name: "IX_reminder_Assistants_assistantId",
                table: "reminder_Assistants",
                column: "assistantId");

            migrationBuilder.CreateIndex(
                name: "IX_reminder_Doctors_doctorId",
                table: "reminder_Doctors",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_reminder_Insurances_insuranceId",
                table: "reminder_Insurances",
                column: "insuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_reminder_Patients_patientId",
                table: "reminder_Patients",
                column: "patientId");

            migrationBuilder.AddForeignKey(
                name: "FK_reminder_Admins_admins_adminId",
                table: "reminder_Admins",
                column: "adminId",
                principalTable: "admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
