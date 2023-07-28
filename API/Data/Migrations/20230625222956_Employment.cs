using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Employment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlaceOfWork",
                table: "ApplicantOccupationHistory",
                newName: "Responsibilities");

            migrationBuilder.RenameColumn(
                name: "OfficeAddress",
                table: "ApplicantOccupationHistory",
                newName: "NameOfEmployer");

            migrationBuilder.AddColumn<string>(
                name: "LocationOfEmployer",
                table: "ApplicantOccupationHistory",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationOfEmployer",
                table: "ApplicantOccupationHistory");

            migrationBuilder.RenameColumn(
                name: "Responsibilities",
                table: "ApplicantOccupationHistory",
                newName: "PlaceOfWork");

            migrationBuilder.RenameColumn(
                name: "NameOfEmployer",
                table: "ApplicantOccupationHistory",
                newName: "OfficeAddress");
        }
    }
}
