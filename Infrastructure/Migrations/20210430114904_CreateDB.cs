using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bassins",
                columns: table => new
                {
                    BassinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomBassin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bassins", x => x.BassinId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BassinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.StationId);
                    table.ForeignKey(
                        name: "FK_Stations_Bassins_BassinId",
                        column: x => x.BassinId,
                        principalTable: "Bassins",
                        principalColumn: "BassinId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Observateurs",
                columns: table => new
                {
                    ObservateurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPrenomObservateur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observateurs", x => x.ObservateurId);
                    table.ForeignKey(
                        name: "FK_Observateurs_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelativeHumiditys",
                columns: table => new
                {
                    RelativeHumidityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sec = table.Column<float>(type: "real", nullable: false),
                    Mou = table.Column<float>(type: "real", nullable: false),
                    Hum = table.Column<float>(type: "real", nullable: false),
                    ThermometreMin = table.Column<float>(type: "real", nullable: false),
                    ThermometreMax = table.Column<float>(type: "real", nullable: false),
                    ThermometreMoyMaxMin = table.Column<float>(type: "real", nullable: false),
                    ThermometreMA = table.Column<float>(type: "real", nullable: false),
                    ThermometreMI = table.Column<float>(type: "real", nullable: false),
                    Heur = table.Column<int>(type: "int", nullable: false),
                    DateObservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: true),
                    ObservateurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelativeHumiditys", x => x.RelativeHumidityId);
                    table.ForeignKey(
                        name: "FK_RelativeHumiditys_Observateurs_ObservateurId",
                        column: x => x.ObservateurId,
                        principalTable: "Observateurs",
                        principalColumn: "ObservateurId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelativeHumiditys_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Observateurs_StationId",
                table: "Observateurs",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_RelativeHumiditys_ObservateurId",
                table: "RelativeHumiditys",
                column: "ObservateurId");

            migrationBuilder.CreateIndex(
                name: "IX_RelativeHumiditys_StationId",
                table: "RelativeHumiditys",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_BassinId",
                table: "Stations",
                column: "BassinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelativeHumiditys");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Observateurs");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Bassins");
        }
    }
}
