using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class applicantPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantPhotos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    AppId = table.Column<int>(type: "int", nullable: false),
                    FosterApplicationsAppId = table.Column<int>(type: "int", nullable: true),
                    DateUploded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantPhotos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_ApplicantPhotos_FosterApplications_FosterApplicationsAppId",
                        column: x => x.FosterApplicationsAppId,
                        principalTable: "FosterApplications",
                        principalColumn: "AppId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPhotos_FosterApplicationsAppId",
                table: "ApplicantPhotos",
                column: "FosterApplicationsAppId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantPhotos");
        }
    }
}
