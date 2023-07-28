using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class applicanthometudy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantHomeStudyReports_FosterApplications_FosterApplicationsAppId",
                table: "ApplicantHomeStudyReports");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantHomeStudyReports_FosterApplicationsAppId",
                table: "ApplicantHomeStudyReports");

            migrationBuilder.DropColumn(
                name: "FosterApplicationsAppId",
                table: "ApplicantHomeStudyReports");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantHomeStudyReports_ApplyId",
                table: "ApplicantHomeStudyReports",
                column: "ApplyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantHomeStudyReports_FosterApplications_ApplyId",
                table: "ApplicantHomeStudyReports",
                column: "ApplyId",
                principalTable: "FosterApplications",
                principalColumn: "AppId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantHomeStudyReports_FosterApplications_ApplyId",
                table: "ApplicantHomeStudyReports");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantHomeStudyReports_ApplyId",
                table: "ApplicantHomeStudyReports");

            migrationBuilder.AddColumn<int>(
                name: "FosterApplicationsAppId",
                table: "ApplicantHomeStudyReports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantHomeStudyReports_FosterApplicationsAppId",
                table: "ApplicantHomeStudyReports",
                column: "FosterApplicationsAppId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantHomeStudyReports_FosterApplications_FosterApplicationsAppId",
                table: "ApplicantHomeStudyReports",
                column: "FosterApplicationsAppId",
                principalTable: "FosterApplications",
                principalColumn: "AppId");
        }
    }
}
