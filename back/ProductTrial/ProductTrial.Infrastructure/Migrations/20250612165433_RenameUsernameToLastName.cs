using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductTrial.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameUsernameToLastName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Lastname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Users",
                newName: "Username");
        }
    }
}
