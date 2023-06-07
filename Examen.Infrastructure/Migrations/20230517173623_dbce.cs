using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dbce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "centreVaccinations",
                columns: table => new
                {
                    CentreVacincationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    NbrChaises = table.Column<int>(type: "int", nullable: false),
                    NumTelephone = table.Column<int>(type: "int", nullable: false),
                    ResponsableCentre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centreVaccinations", x => x.CentreVacincationId);
                });

            migrationBuilder.CreateTable(
                name: "citoyens",
                columns: table => new
                {
                    CIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    CitoyenId = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroEvax = table.Column<int>(type: "int", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<int>(type: "int", nullable: false),
                    AddresseCodePostal = table.Column<int>(name: "Addresse_CodePostal", type: "int", nullable: false),
                    AddresseRue = table.Column<int>(name: "Addresse_Rue", type: "int", nullable: false),
                    AddresseVille = table.Column<string>(name: "Addresse_Ville", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citoyens", x => x.CIN);
                });

            migrationBuilder.CreateTable(
                name: "Exemples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exemples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vaccins",
                columns: table => new
                {
                    VaccinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateValidation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fournisseur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    TypeVaccin = table.Column<int>(type: "int", nullable: false),
                    CentreVacinationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccins", x => x.VaccinId);
                    table.ForeignKey(
                        name: "FK_vaccins_centreVaccinations_CentreVacinationId",
                        column: x => x.CentreVacinationId,
                        principalTable: "centreVaccinations",
                        principalColumn: "CentreVacincationId");
                });

            migrationBuilder.CreateTable(
                name: "rendezVous",
                columns: table => new
                {
                    DateVaccin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VaccinId = table.Column<int>(type: "int", nullable: false),
                    CitoyenId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codeInfirmiere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbreDoses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rendezVous", x => new { x.CitoyenId, x.VaccinId, x.DateVaccin });
                    table.ForeignKey(
                        name: "FK_rendezVous_citoyens_CitoyenId",
                        column: x => x.CitoyenId,
                        principalTable: "citoyens",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rendezVous_vaccins_VaccinId",
                        column: x => x.VaccinId,
                        principalTable: "vaccins",
                        principalColumn: "VaccinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rendezVous_VaccinId",
                table: "rendezVous",
                column: "VaccinId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccins_CentreVacinationId",
                table: "vaccins",
                column: "CentreVacinationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exemples");

            migrationBuilder.DropTable(
                name: "rendezVous");

            migrationBuilder.DropTable(
                name: "citoyens");

            migrationBuilder.DropTable(
                name: "vaccins");

            migrationBuilder.DropTable(
                name: "centreVaccinations");
        }
    }
}
