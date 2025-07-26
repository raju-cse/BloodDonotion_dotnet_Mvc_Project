using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonor.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class ChangLastDonortionDateTimeToAllowNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "profilePicture",
                table: "BloodDonorEntity",
                newName: "ProfilePicture");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastDonationDate",
                table: "BloodDonorEntity",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePicture",
                table: "BloodDonorEntity",
                newName: "profilePicture");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastDonationDate",
                table: "BloodDonorEntity",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
