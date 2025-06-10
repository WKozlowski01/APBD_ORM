using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolokwium_ORM.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RaceId",
                table: "Racers",
                newName: "RacerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RacerId",
                table: "Racers",
                newName: "RaceId");
        }
    }
}
