using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class applicantapprove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseRegionalSocialWelfareDir",
                table: "ApplicationApprovals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResponseRegionalSocialWelfareDir",
                table: "ApplicationApprovals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
