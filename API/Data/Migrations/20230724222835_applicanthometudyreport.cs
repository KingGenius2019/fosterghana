using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class applicanthometudyreport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantaHomeStudyReports",
                columns: table => new
                {
                    HomeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeDocumentTitle = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DocumentPath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApplyId = table.Column<int>(type: "int", nullable: false),
                    FosterApplicationsAppId = table.Column<int>(type: "int", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantaHomeStudyReports", x => x.HomeId);
                    table.ForeignKey(
                        name: "FK_ApplicantaHomeStudyReports_FosterApplications_FosterApplicationsAppId",
                        column: x => x.FosterApplicationsAppId,
                        principalTable: "FosterApplications",
                        principalColumn: "AppId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantaHomeStudyReports_FosterApplicationsAppId",
                table: "ApplicantaHomeStudyReports",
                column: "FosterApplicationsAppId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantaHomeStudyReports");
        }
    }
}
