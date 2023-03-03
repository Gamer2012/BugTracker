using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTracker.Migrations
{
    /// <inheritdoc />
    public partial class addedOpenedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OpenedBy",
                table: "Bugs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenedBy",
                table: "Bugs");
        }
    }
}
