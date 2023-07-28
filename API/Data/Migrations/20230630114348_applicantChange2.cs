using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class applicantChange2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantEmploymentHistory_AspNetUsers_UserId",
                table: "ApplicantEmploymentHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantEmploymentHistory",
                table: "ApplicantEmploymentHistory");

            migrationBuilder.RenameTable(
                name: "ApplicantEmploymentHistory",
                newName: "ApplicantEmploymentHistories");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantEmploymentHistory_UserId",
                table: "ApplicantEmploymentHistories",
                newName: "IX_ApplicantEmploymentHistories_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantEmploymentHistories",
                table: "ApplicantEmploymentHistories",
                column: "OccId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantEmploymentHistories_AspNetUsers_UserId",
                table: "ApplicantEmploymentHistories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantEmploymentHistories_AspNetUsers_UserId",
                table: "ApplicantEmploymentHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantEmploymentHistories",
                table: "ApplicantEmploymentHistories");

            migrationBuilder.RenameTable(
                name: "ApplicantEmploymentHistories",
                newName: "ApplicantEmploymentHistory");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantEmploymentHistories_UserId",
                table: "ApplicantEmploymentHistory",
                newName: "IX_ApplicantEmploymentHistory_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantEmploymentHistory",
                table: "ApplicantEmploymentHistory",
                column: "OccId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantEmploymentHistory_AspNetUsers_UserId",
                table: "ApplicantEmploymentHistory",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
