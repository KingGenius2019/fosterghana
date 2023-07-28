using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class applicantassess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessApplicationFosterApplications");

            migrationBuilder.AddColumn<int>(
                name: "FosterApplicationsAppId",
                table: "AssessApplications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssessApplications_FosterApplicationsAppId",
                table: "AssessApplications",
                column: "FosterApplicationsAppId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssessApplications_FosterApplications_FosterApplicationsAppId",
                table: "AssessApplications",
                column: "FosterApplicationsAppId",
                principalTable: "FosterApplications",
                principalColumn: "AppId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssessApplications_FosterApplications_FosterApplicationsAppId",
                table: "AssessApplications");

            migrationBuilder.DropIndex(
                name: "IX_AssessApplications_FosterApplicationsAppId",
                table: "AssessApplications");

            migrationBuilder.DropColumn(
                name: "FosterApplicationsAppId",
                table: "AssessApplications");

            migrationBuilder.CreateTable(
                name: "AssessApplicationFosterApplications",
                columns: table => new
                {
                    AssessApplicationsAssessId = table.Column<int>(type: "int", nullable: false),
                    FosterApplicationsAppId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessApplicationFosterApplications", x => new { x.AssessApplicationsAssessId, x.FosterApplicationsAppId });
                    table.ForeignKey(
                        name: "FK_AssessApplicationFosterApplications_AssessApplications_AssessApplicationsAssessId",
                        column: x => x.AssessApplicationsAssessId,
                        principalTable: "AssessApplications",
                        principalColumn: "AssessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessApplicationFosterApplications_FosterApplications_FosterApplicationsAppId",
                        column: x => x.FosterApplicationsAppId,
                        principalTable: "FosterApplications",
                        principalColumn: "AppId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessApplicationFosterApplications_FosterApplicationsAppId",
                table: "AssessApplicationFosterApplications",
                column: "FosterApplicationsAppId");
        }
    }
}
