using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class updatePrescreptinAndPatientHitory : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_BookedAppointments_DoctorId",
                table: "BookedAppointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedAppointments_PatientId",
                table: "BookedAppointments",
                column: "PatientId");

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
