using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonor.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class ProfilePictureInBloodDonorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "profilePicture",
                table: "BloodDonorEntity",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profilePicture",
                table: "BloodDonorEntity");
        }
    }
}
