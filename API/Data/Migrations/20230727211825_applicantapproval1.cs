using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class applicantapproval1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationApprovals_AspNetUsers_UserId",
                table: "ApplicationApprovals");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationApprovals_UserId",
                table: "ApplicationApprovals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ApplicationApprovals");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "ApplicationApprovals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "ApplicationApprovals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "ApplicationApprovals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateApprovalWasDone",
                table: "ApplicationApprovals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "FosterParentApproved",
                table: "ApplicationApprovals",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "ApplicationApprovals");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "ApplicationApprovals");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "ApplicationApprovals");

            migrationBuilder.DropColumn(
                name: "DateApprovalWasDone",
                table: "ApplicationApprovals");

            migrationBuilder.DropColumn(
                name: "FosterParentApproved",
                table: "ApplicationApprovals");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ApplicationApprovals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationApprovals_UserId",
                table: "ApplicationApprovals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationApprovals_AspNetUsers_UserId",
                table: "ApplicationApprovals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
