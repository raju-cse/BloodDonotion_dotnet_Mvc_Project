using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonor.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donation_BloodDonor_BloodDonorId",
                table: "Donation");

            migrationBuilder.DropTable(
                name: "BloodDonor");

            migrationBuilder.DropIndex(
                name: "IX_Donation_BloodDonorId",
                table: "Donation");

            migrationBuilder.AddColumn<int>(
                name: "BloodDonorEntityId",
                table: "Donation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BloodDonorEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastDonationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodDonorEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donation_BloodDonorEntityId",
                table: "Donation",
                column: "BloodDonorEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_BloodDonorEntity_BloodDonorEntityId",
                table: "Donation",
                column: "BloodDonorEntityId",
                principalTable: "BloodDonorEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donation_BloodDonorEntity_BloodDonorEntityId",
                table: "Donation");

            migrationBuilder.DropTable(
                name: "BloodDonorEntity");

            migrationBuilder.DropIndex(
                name: "IX_Donation_BloodDonorEntityId",
                table: "Donation");

            migrationBuilder.DropColumn(
                name: "BloodDonorEntityId",
                table: "Donation");

            migrationBuilder.CreateTable(
                name: "BloodDonor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastDonation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodDonor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donation_BloodDonorId",
                table: "Donation",
                column: "BloodDonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_BloodDonor_BloodDonorId",
                table: "Donation",
                column: "BloodDonorId",
                principalTable: "BloodDonor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
