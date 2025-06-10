using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolokwium_ORM.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Racers",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racers", x => x.RaceId);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    raceid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    datetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.raceid);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LengthlnKm = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.TrackId);
                });

            migrationBuilder.CreateTable(
                name: "TrackRaces",
                columns: table => new
                {
                    TrackRaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    Laps = table.Column<int>(type: "int", nullable: false),
                    BestTimelnSeconds = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackRaces", x => x.TrackRaceId);
                    table.ForeignKey(
                        name: "FK_TrackRaces_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "raceid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackRaces_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceParticipations",
                columns: table => new
                {
                    TrackRaceId = table.Column<int>(type: "int", nullable: false),
                    RacerId = table.Column<int>(type: "int", nullable: false),
                    FinishTimelnSeconds = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceParticipations", x => new { x.TrackRaceId, x.RacerId });
                    table.ForeignKey(
                        name: "FK_RaceParticipations_Racers_RacerId",
                        column: x => x.RacerId,
                        principalTable: "Racers",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceParticipations_TrackRaces_TrackRaceId",
                        column: x => x.TrackRaceId,
                        principalTable: "TrackRaces",
                        principalColumn: "TrackRaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceParticipations_RacerId",
                table: "RaceParticipations",
                column: "RacerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackRaces_RaceId",
                table: "TrackRaces",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackRaces_TrackId",
                table: "TrackRaces",
                column: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceParticipations");

            migrationBuilder.DropTable(
                name: "Racers");

            migrationBuilder.DropTable(
                name: "TrackRaces");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Tracks");
        }
    }
}
