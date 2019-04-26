using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.Data.Migrations
{
    public partial class AddingModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fname = table.Column<string>(maxLength: 50, nullable: true),
                    mname = table.Column<string>(maxLength: 50, nullable: true),
                    lname = table.Column<string>(maxLength: 50, nullable: true),
                    username = table.Column<string>(maxLength: 50, nullable: true),
                    pass = table.Column<string>(maxLength: 300, nullable: true),
                    phone = table.Column<string>(maxLength: 15, nullable: true),
                    mobile = table.Column<string>(maxLength: 15, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    rand_pass = table.Column<string>(maxLength: 100, nullable: true),
                    exp_pass = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fname = table.Column<string>(maxLength: 50, nullable: true),
                    mname = table.Column<string>(maxLength: 50, nullable: true),
                    lname = table.Column<string>(maxLength: 50, nullable: true),
                    username = table.Column<string>(maxLength: 50, nullable: true),
                    pass = table.Column<string>(maxLength: 300, nullable: true),
                    phone = table.Column<string>(maxLength: 15, nullable: true),
                    mobile = table.Column<string>(maxLength: 15, nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    display_name = table.Column<string>(maxLength: 100, nullable: true),
                    gender = table.Column<string>(maxLength: 10, nullable: true),
                    speciality = table.Column<string>(maxLength: 100, nullable: true),
                    time = table.Column<string>(maxLength: 100, nullable: true),
                    address = table.Column<string>(nullable: true),
                    about = table.Column<string>(nullable: true),
                    pr_phone = table.Column<string>(maxLength: 10, nullable: true),
                    pr_mobile = table.Column<string>(maxLength: 10, nullable: true),
                    pr_email = table.Column<string>(maxLength: 10, nullable: true),
                    pr_mname = table.Column<string>(maxLength: 10, nullable: true),
                    pr_address = table.Column<string>(maxLength: 10, nullable: true),
                    pr_about = table.Column<string>(maxLength: 10, nullable: true),
                    pr_time = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "insurances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 100, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    phone = table.Column<string>(maxLength: 15, nullable: true),
                    username = table.Column<string>(maxLength: 50, nullable: true),
                    pass = table.Column<string>(maxLength: 300, nullable: true),
                    address = table.Column<string>(maxLength: 100, nullable: true),
                    fax = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 300, nullable: false),
                    email = table.Column<string>(maxLength: 150, nullable: false),
                    subject = table.Column<string>(maxLength: 150, nullable: false),
                    message = table.Column<string>(nullable: false),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reminder_Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: false),
                    content = table.Column<string>(maxLength: 300, nullable: true),
                    priority = table.Column<string>(maxLength: 10, nullable: true),
                    title = table.Column<string>(maxLength: 100, nullable: true),
                    time = table.Column<DateTime>(nullable: false),
                    adminId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reminder_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reminder_Admins_admins_adminId",
                        column: x => x.adminId,
                        principalTable: "admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assistants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fname = table.Column<string>(maxLength: 50, nullable: true),
                    mname = table.Column<string>(maxLength: 50, nullable: true),
                    lname = table.Column<string>(maxLength: 50, nullable: true),
                    username = table.Column<string>(maxLength: 50, nullable: false),
                    pass = table.Column<string>(maxLength: 300, nullable: false),
                    phone = table.Column<string>(maxLength: 15, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    display_name = table.Column<string>(maxLength: 100, nullable: true),
                    ref_doctor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assistants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_assistants_doctors_ref_doctor",
                        column: x => x.ref_doctor,
                        principalTable: "doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reminder_Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: false),
                    content = table.Column<string>(maxLength: 300, nullable: true),
                    priority = table.Column<string>(maxLength: 10, nullable: true),
                    title = table.Column<string>(maxLength: 100, nullable: true),
                    time = table.Column<DateTime>(nullable: false),
                    doctorId = table.Column<int>(nullable: true)
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
                name: "patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fname = table.Column<string>(maxLength: 50, nullable: true),
                    mname = table.Column<string>(maxLength: 50, nullable: true),
                    lname = table.Column<string>(maxLength: 50, nullable: true),
                    username = table.Column<string>(maxLength: 50, nullable: true),
                    pass = table.Column<string>(maxLength: 300, nullable: true),
                    phone = table.Column<string>(maxLength: 15, nullable: true),
                    mobile = table.Column<string>(maxLength: 15, nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    display_name = table.Column<string>(maxLength: 100, nullable: true),
                    gender = table.Column<string>(maxLength: 10, nullable: true),
                    address = table.Column<string>(maxLength: 200, nullable: true),
                    birthday = table.Column<DateTime>(nullable: false),
                    blood_type = table.Column<string>(maxLength: 4, nullable: true),
                    insurance = table.Column<int>(nullable: false),
                    token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_patients_insurances_insurance",
                        column: x => x.insurance,
                        principalTable: "insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reminder_Insurances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: false),
                    content = table.Column<string>(maxLength: 300, nullable: true),
                    priority = table.Column<string>(maxLength: 10, nullable: true),
                    title = table.Column<string>(maxLength: 100, nullable: true),
                    time = table.Column<DateTime>(nullable: false),
                    insuranceId = table.Column<int>(nullable: true)
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
                name: "reminder_Assistants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: false),
                    content = table.Column<string>(maxLength: 300, nullable: true),
                    priority = table.Column<string>(maxLength: 10, nullable: true),
                    title = table.Column<string>(maxLength: 100, nullable: true),
                    time = table.Column<DateTime>(nullable: false),
                    assistantId = table.Column<int>(nullable: true)
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
                name: "consultations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    patient_id = table.Column<int>(nullable: false),
                    doctor_id = table.Column<int>(nullable: false),
                    title = table.Column<string>(maxLength: 100, nullable: true),
                    type = table.Column<string>(maxLength: 50, nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    symptoms = table.Column<string>(nullable: true),
                    diagnostics = table.Column<string>(nullable: true),
                    temp = table.Column<string>(maxLength: 5, nullable: true),
                    blood_presure = table.Column<string>(maxLength: 5, nullable: true),
                    cost = table.Column<string>(maxLength: 10, nullable: true),
                    treatment = table.Column<string>(nullable: true),
                    insurance_conf = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_consultations_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_consultations_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    patient_id = table.Column<int>(nullable: false),
                    doctorId = table.Column<int>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    time = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: true),
                    alpha = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dates_doctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dates_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    patientId = table.Column<int>(nullable: true),
                    doctorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lists_doctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_lists_patients_patientId",
                        column: x => x.patientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reminder_Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: false),
                    content = table.Column<string>(maxLength: 300, nullable: true),
                    priority = table.Column<string>(maxLength: 10, nullable: true),
                    title = table.Column<string>(maxLength: 100, nullable: true),
                    time = table.Column<DateTime>(nullable: false),
                    patientId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    patientId = table.Column<int>(nullable: true),
                    doctorId = table.Column<int>(nullable: true),
                    insuranceId = table.Column<int>(nullable: true),
                    title = table.Column<string>(maxLength: 100, nullable: true),
                    cost = table.Column<string>(maxLength: 10, nullable: true),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reports_doctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reports_insurances_insuranceId",
                        column: x => x.insuranceId,
                        principalTable: "insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reports_patients_patientId",
                        column: x => x.patientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assistants_ref_doctor",
                table: "assistants",
                column: "ref_doctor");

            migrationBuilder.CreateIndex(
                name: "IX_consultations_doctor_id",
                table: "consultations",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_consultations_patient_id",
                table: "consultations",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_dates_doctorId",
                table: "dates",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_dates_patient_id",
                table: "dates",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_lists_doctorId",
                table: "lists",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_lists_patientId",
                table: "lists",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_patients_insurance",
                table: "patients",
                column: "insurance");

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

            migrationBuilder.CreateIndex(
                name: "IX_reports_doctorId",
                table: "reports",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_reports_insuranceId",
                table: "reports",
                column: "insuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_reports_patientId",
                table: "reports",
                column: "patientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consultations");

            migrationBuilder.DropTable(
                name: "dates");

            migrationBuilder.DropTable(
                name: "lists");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "reminder_Admins");

            migrationBuilder.DropTable(
                name: "reminder_Assistants");

            migrationBuilder.DropTable(
                name: "reminder_Doctors");

            migrationBuilder.DropTable(
                name: "reminder_Insurances");

            migrationBuilder.DropTable(
                name: "reminder_Patients");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "assistants");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "insurances");
        }
    }
}
