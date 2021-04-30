using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bassin",
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
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BassinId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.StationId);
                    table.ForeignKey(
                        name: "FK_Stations_Bassins_BassinId",
                        column: x => x.BassinId,
                        principalTable: "Bassin",
                        principalColumn: "BassinId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Observateur",
                columns: table => new
                {
                    ObservateurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPrenomObservateur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observateurs", x => x.ObservateurId);
                    table.ForeignKey(
                        name: "FK_Observateurs_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Station",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelativeHumidity",
                columns: table => new
                {
                    RelativeHumidityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sec = table.Column<float>(type: "real", nullable: false),
                    Mou = table.Column<float>(type: "real", nullable: false),
                    Hum = table.Column<float>(type: "real", nullable: false),
                    ThermometreMin = table.Column<float>(type: "real", nullable: true),
                    ThermometreMax = table.Column<float>(type: "real", nullable: true),
                    ThermometreMoyMaxMin = table.Column<float>(type: "real", nullable: true),
                    ThermometreMA = table.Column<float>(type: "real", nullable: true),
                    ThermometreMI = table.Column<float>(type: "real", nullable: true),
                    Heur = table.Column<int>(type: "int", nullable: false),
                    DateObservation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    ObservateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelativeHumiditys", x => x.RelativeHumidityId);
                    table.ForeignKey(
                        name: "FK_RelativeHumiditys_Observateurs_ObservateurId",
                        column: x => x.ObservateurId,
                        principalTable: "Observateur",
                        principalColumn: "ObservateurId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelativeHumiditys_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Station",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Observateurs_StationId",
                table: "Observateur",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_RelativeHumiditys_ObservateurId",
                table: "RelativeHumidity",
                column: "ObservateurId");

            migrationBuilder.CreateIndex(
                name: "IX_RelativeHumiditys_StationId",
                table: "RelativeHumidity",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_BassinId",
                table: "Station",
                column: "BassinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelativeHumidity");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Observateur");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "Bassin");
        }
    }
}
