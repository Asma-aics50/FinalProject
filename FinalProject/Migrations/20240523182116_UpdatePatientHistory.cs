using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Patients_PatientId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_PatientId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "NoOfTimes",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Prescriptions",
                newName: "DrugInstruction");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "PatientHistories",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "PatientHistoryMedicalAnalyses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "BloodPressure",
                table: "PatientHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "PatientHistories",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "PatientHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReExaminatoinDate",
                table: "PatientHistories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "PatientHistories",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CreateCompanyViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateCompanyViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreateMedicalAnalysisViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateMedicalAnalysisViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreateServiceViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateServiceViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorPatients",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPatients", x => new { x.DoctorId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_DoctorPatients_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientDetailsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDetailsViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientDetailsViewModel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PrescreptionDetailsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PatientHistoryId = table.Column<int>(type: "int", nullable: false),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReExaminatoinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true),
                    BloodPressure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescreptionDetailsViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookedAppointments_DoctorId",
                table: "BookedAppointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedAppointments_PatientId",
                table: "BookedAppointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatients_PatientId",
                table: "DoctorPatients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDetailsViewModel_UserId",
                table: "PatientDetailsViewModel",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedAppointments_Doctors_DoctorId",
                table: "BookedAppointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookedAppointments_Patients_PatientId",
                table: "BookedAppointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedAppointments_Doctors_DoctorId",
                table: "BookedAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_BookedAppointments_Patients_PatientId",
                table: "BookedAppointments");

            migrationBuilder.DropTable(
                name: "CreateCompanyViewModel");

            migrationBuilder.DropTable(
                name: "CreateMedicalAnalysisViewModel");

            migrationBuilder.DropTable(
                name: "CreateServiceViewModel");

            migrationBuilder.DropTable(
                name: "DoctorPatients");

            migrationBuilder.DropTable(
                name: "PatientDetailsViewModel");

            migrationBuilder.DropTable(
                name: "PrescreptionDetailsViewModel");

            migrationBuilder.DropIndex(
                name: "IX_BookedAppointments_DoctorId",
                table: "BookedAppointments");

            migrationBuilder.DropIndex(
                name: "IX_BookedAppointments_PatientId",
                table: "BookedAppointments");

            migrationBuilder.DropColumn(
                name: "BloodPressure",
                table: "PatientHistories");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "PatientHistories");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "PatientHistories");

            migrationBuilder.DropColumn(
                name: "ReExaminatoinDate",
                table: "PatientHistories");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "PatientHistories");

            migrationBuilder.RenameColumn(
                name: "DrugInstruction",
                table: "Prescriptions",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "PatientHistories",
                newName: "DateTime");

            migrationBuilder.AddColumn<int>(
                name: "NoOfTimes",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "PatientHistoryMedicalAnalyses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PatientId",
                table: "Doctors",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Patients_PatientId",
                table: "Doctors",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
