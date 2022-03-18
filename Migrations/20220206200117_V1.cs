using Microsoft.EntityFrameworkCore.Migrations;

namespace Proba1.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodnja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Godina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodnja", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Radnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnik", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Burad",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    ProizvodID = table.Column<int>(type: "int", nullable: true),
                    ProizvodnjaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burad", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Burad_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Burad_Proizvodnja_ProizvodnjaID",
                        column: x => x.ProizvodnjaID,
                        principalTable: "Proizvodnja",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProizvodnjaRadnik",
                columns: table => new
                {
                    ProizvodnjaID = table.Column<int>(type: "int", nullable: false),
                    RadnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodnjaRadnik", x => new { x.ProizvodnjaID, x.RadnikID });
                    table.ForeignKey(
                        name: "FK_ProizvodnjaRadnik_Proizvodnja_ProizvodnjaID",
                        column: x => x.ProizvodnjaID,
                        principalTable: "Proizvodnja",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProizvodnjaRadnik_Radnik_RadnikID",
                        column: x => x.RadnikID,
                        principalTable: "Radnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Burad_ProizvodID",
                table: "Burad",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_Burad_ProizvodnjaID",
                table: "Burad",
                column: "ProizvodnjaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodnjaRadnik_RadnikID",
                table: "ProizvodnjaRadnik",
                column: "RadnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Burad");

            migrationBuilder.DropTable(
                name: "ProizvodnjaRadnik");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Proizvodnja");

            migrationBuilder.DropTable(
                name: "Radnik");
        }
    }
}
