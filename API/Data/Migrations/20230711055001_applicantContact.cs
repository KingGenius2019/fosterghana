using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class applicantContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalAddress",
                table: "ApplicantAddress");

            migrationBuilder.DropColumn(
                name: "PreferenceCorrepondence",
                table: "ApplicantAddress");

            migrationBuilder.CreateTable(
                name: "ApplicantContacts",
                columns: table => new
                {
                    ContId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimaryContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferenceCorrepondence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantContacts", x => x.ContId);
                    table.ForeignKey(
                        name: "FK_ApplicantContacts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantContacts_AppUserId",
                table: "ApplicantContacts",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantContacts");

            migrationBuilder.AddColumn<string>(
                name: "PostalAddress",
                table: "ApplicantAddress",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreferenceCorrepondence",
                table: "ApplicantAddress",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
