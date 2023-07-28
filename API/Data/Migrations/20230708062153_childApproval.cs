using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class childApproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAssesed",
                table: "AssessApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.CreateTable(
                name: "ChildApprovals",
                columns: table => new
                {
                    AppId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildApprovals", x => x.AppId);
                    table.ForeignKey(
                        name: "FK_ChildApprovals_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "ld",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessApplicationFosterApplications_FosterApplicationsAppId",
                table: "AssessApplicationFosterApplications",
                column: "FosterApplicationsAppId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildApprovals_ChildId",
                table: "ChildApprovals",
                column: "ChildId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessApplicationFosterApplications");

            migrationBuilder.DropTable(
                name: "ChildApprovals");

            migrationBuilder.DropColumn(
                name: "DateAssesed",
                table: "AssessApplications");

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
    }
}
