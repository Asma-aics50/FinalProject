using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class updateDoctorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "DeprtId",
                table: "Doctors",
                newName: "ShiftStartTime");

            migrationBuilder.AddColumn<int>(
                name: "ShiftEndTime",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftEndTime",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "ShiftStartTime",
                table: "Doctors",
                newName: "DeprtId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
