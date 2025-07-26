using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BloodDonor.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class SeeDataForBloodDonor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donation_BloodDonorEntity_BloodDonorEntityId",
                table: "Donation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donation",
                table: "Donation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BloodDonorEntity",
                table: "BloodDonorEntity");

            migrationBuilder.RenameTable(
                name: "Donation",
                newName: "Donations");

            migrationBuilder.RenameTable(
                name: "BloodDonorEntity",
                newName: "BloodDonors");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_BloodDonorEntityId",
                table: "Donations",
                newName: "IX_Donations_BloodDonorEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donations",
                table: "Donations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BloodDonors",
                table: "BloodDonors",
                column: "Id");

            migrationBuilder.InsertData(
                table: "BloodDonors",
                columns: new[] { "Id", "Address", "BloodGroup", "ContactNumber", "DateOfBirth", "Email", "FullName", "LastDonationDate", "ProfilePicture", "Weight" },
                values: new object[,]
                {
                    { 1, "New York", "APositive", "9876543210", new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice@example.com", "Alice Thomas", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "profiles/alice.jpg", 60f },
                    { 2, "Chicago", "ONegative", "9876543211", new DateTime(1985, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob@example.com", "Bob Smith", null, "profiles/bob.jpg", 72f }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_BloodDonors_BloodDonorEntityId",
                table: "Donations",
                column: "BloodDonorEntityId",
                principalTable: "BloodDonors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_BloodDonors_BloodDonorEntityId",
                table: "Donations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donations",
                table: "Donations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BloodDonors",
                table: "BloodDonors");

            migrationBuilder.DeleteData(
                table: "BloodDonors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BloodDonors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Donations",
                newName: "Donation");

            migrationBuilder.RenameTable(
                name: "BloodDonors",
                newName: "BloodDonorEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Donations_BloodDonorEntityId",
                table: "Donation",
                newName: "IX_Donation_BloodDonorEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donation",
                table: "Donation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BloodDonorEntity",
                table: "BloodDonorEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_BloodDonorEntity_BloodDonorEntityId",
                table: "Donation",
                column: "BloodDonorEntityId",
                principalTable: "BloodDonorEntity",
                principalColumn: "Id");
        }
    }
}
