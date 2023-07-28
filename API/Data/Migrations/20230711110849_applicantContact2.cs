using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class applicantContact2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantContacts_AspNetUsers_AppUserId",
                table: "ApplicantContacts");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantContacts_AppUserId",
                table: "ApplicantContacts");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "ApplicantContacts",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantContacts_UserId",
                table: "ApplicantContacts",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantContacts_AspNetUsers_UserId",
                table: "ApplicantContacts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantContacts_AspNetUsers_UserId",
                table: "ApplicantContacts");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantContacts_UserId",
                table: "ApplicantContacts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ApplicantContacts",
                newName: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantContacts_AppUserId",
                table: "ApplicantContacts",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantContacts_AspNetUsers_AppUserId",
                table: "ApplicantContacts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
