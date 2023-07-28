using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class applicantapproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplyId = table.Column<int>(type: "int", nullable: false),
                    FosterApplicationsAppId = table.Column<int>(type: "int", nullable: true),
                    ResponseRegionalSocialWelfareDir = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationApprovals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationApprovals_FosterApplications_FosterApplicationsAppId",
                        column: x => x.FosterApplicationsAppId,
                        principalTable: "FosterApplications",
                        principalColumn: "AppId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationApprovals_FosterApplicationsAppId",
                table: "ApplicationApprovals",
                column: "FosterApplicationsAppId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationApprovals_UserId",
                table: "ApplicationApprovals",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationApprovals");
        }
    }
}
