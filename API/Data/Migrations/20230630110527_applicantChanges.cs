using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class applicantChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantOccupationHistory");

            migrationBuilder.CreateTable(
                name: "ApplicantEmploymentHistory",
                columns: table => new
                {
                    OccId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfEmployer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationOfEmployer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateExited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Responsibilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantEmploymentHistory", x => x.OccId);
                    table.ForeignKey(
                        name: "FK_ApplicantEmploymentHistory_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantEmploymentHistory_UserId",
                table: "ApplicantEmploymentHistory",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantEmploymentHistory");

            migrationBuilder.CreateTable(
                name: "ApplicantOccupationHistory",
                columns: table => new
                {
                    OccId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateExited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationOfEmployer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfEmployer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsibilities = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantOccupationHistory", x => x.OccId);
                    table.ForeignKey(
                        name: "FK_ApplicantOccupationHistory_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantOccupationHistory_UserId",
                table: "ApplicantOccupationHistory",
                column: "UserId");
        }
    }
}
