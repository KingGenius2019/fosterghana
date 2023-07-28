using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateHouseHold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoOfMale",
                table: "ApplicantHouseholds",
                newName: "NoOfChildrenMale");

            migrationBuilder.RenameColumn(
                name: "NoOfFemale",
                table: "ApplicantHouseholds",
                newName: "NoOfChildrenFemale");

            migrationBuilder.RenameColumn(
                name: "NoOfChildren",
                table: "ApplicantHouseholds",
                newName: "NoOfAdultMale");

            migrationBuilder.RenameColumn(
                name: "AgeGroup",
                table: "ApplicantHouseholds",
                newName: "AgesChildren");

            migrationBuilder.AddColumn<string>(
                name: "AgesAdult",
                table: "ApplicantHouseholds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfAdultFemale",
                table: "ApplicantHouseholds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgesAdult",
                table: "ApplicantHouseholds");

            migrationBuilder.DropColumn(
                name: "NoOfAdultFemale",
                table: "ApplicantHouseholds");

            migrationBuilder.RenameColumn(
                name: "NoOfChildrenMale",
                table: "ApplicantHouseholds",
                newName: "NoOfMale");

            migrationBuilder.RenameColumn(
                name: "NoOfChildrenFemale",
                table: "ApplicantHouseholds",
                newName: "NoOfFemale");

            migrationBuilder.RenameColumn(
                name: "NoOfAdultMale",
                table: "ApplicantHouseholds",
                newName: "NoOfChildren");

            migrationBuilder.RenameColumn(
                name: "AgesChildren",
                table: "ApplicantHouseholds",
                newName: "AgeGroup");
        }
    }
}
