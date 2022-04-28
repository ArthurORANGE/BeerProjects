using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetMvcBeer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beer",
                columns: table => new
                {
                    BeerID = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    AlcoolDegree = table.Column<float>(type: "REAL", nullable: false),
                    Size = table.Column<int>(type: "INTEGER", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beer", x => x.BeerID);
                });

            migrationBuilder.CreateTable(
                name: "Devis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClientName = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonCompte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonCompte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LigneDeVieDevis",
                columns: table => new
                {
                    LigneDeVieDevisID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    BeerID = table.Column<int>(type: "INTEGER", nullable: false),
                    DevisID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LigneDeVieDevis", x => x.LigneDeVieDevisID);
                    table.ForeignKey(
                        name: "FK_LigneDeVieDevis_Beer_BeerID",
                        column: x => x.BeerID,
                        principalTable: "Beer",
                        principalColumn: "BeerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LigneDeVieDevis_Devis_DevisID",
                        column: x => x.DevisID,
                        principalTable: "Devis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LigneDeVieDevis_BeerID",
                table: "LigneDeVieDevis",
                column: "BeerID");

            migrationBuilder.CreateIndex(
                name: "IX_LigneDeVieDevis_DevisID",
                table: "LigneDeVieDevis",
                column: "DevisID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LigneDeVieDevis");

            migrationBuilder.DropTable(
                name: "MonCompte");

            migrationBuilder.DropTable(
                name: "Beer");

            migrationBuilder.DropTable(
                name: "Devis");
        }
    }
}
