using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class fosterparents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssessApplications",
                columns: table => new
                {
                    AssessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanFoster = table.Column<bool>(type: "bit", nullable: false),
                    Assessedby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplyId = table.Column<int>(type: "int", nullable: false),
                    FosterApplicationsAppId = table.Column<int>(type: "int", nullable: true),
                    AssesDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessApplications", x => x.AssessId);
                    table.ForeignKey(
                        name: "FK_AssessApplications_FosterApplications_FosterApplicationsAppId",
                        column: x => x.FosterApplicationsAppId,
                        principalTable: "FosterApplications",
                        principalColumn: "AppId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessApplications_FosterApplicationsAppId",
                table: "AssessApplications",
                column: "FosterApplicationsAppId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessApplications");
        }
    }
}
