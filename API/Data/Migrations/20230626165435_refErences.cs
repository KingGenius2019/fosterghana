using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class refErences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantReferences",
                columns: table => new
                {
                    RefId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfReferee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationshipWithReferee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfRelationship = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefereePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefereeEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantReferences", x => x.RefId);
                    table.ForeignKey(
                        name: "FK_ApplicantReferences_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantReferences_UserId",
                table: "ApplicantReferences",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantReferences");
        }
    }
}
