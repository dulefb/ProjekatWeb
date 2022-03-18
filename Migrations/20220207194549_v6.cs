using Microsoft.EntityFrameworkCore.Migrations;

namespace Proba1.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Burad_Proizvodnja_ProizvodnjaID",
                table: "Burad");

            migrationBuilder.DropTable(
                name: "ProizvodnjaRadnik");

            migrationBuilder.DropColumn(
                name: "Godina",
                table: "Proizvodnja");

            migrationBuilder.DropColumn(
                name: "Proizvod",
                table: "Burad");

            migrationBuilder.RenameColumn(
                name: "ProizvodnjaID",
                table: "Burad",
                newName: "ProizvodID");

            migrationBuilder.RenameIndex(
                name: "IX_Burad_ProizvodnjaID",
                table: "Burad",
                newName: "IX_Burad_ProizvodID");

            migrationBuilder.AddColumn<int>(
                name: "BuradID",
                table: "Proizvodnja",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RadnikID",
                table: "Proizvodnja",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodnja_BuradID",
                table: "Proizvodnja",
                column: "BuradID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodnja_RadnikID",
                table: "Proizvodnja",
                column: "RadnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Burad_Proizvod_ProizvodID",
                table: "Burad",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodnja_Burad_BuradID",
                table: "Proizvodnja",
                column: "BuradID",
                principalTable: "Burad",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodnja_Radnik_RadnikID",
                table: "Proizvodnja",
                column: "RadnikID",
                principalTable: "Radnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Burad_Proizvod_ProizvodID",
                table: "Burad");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodnja_Burad_BuradID",
                table: "Proizvodnja");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodnja_Radnik_RadnikID",
                table: "Proizvodnja");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropIndex(
                name: "IX_Proizvodnja_BuradID",
                table: "Proizvodnja");

            migrationBuilder.DropIndex(
                name: "IX_Proizvodnja_RadnikID",
                table: "Proizvodnja");

            migrationBuilder.DropColumn(
                name: "BuradID",
                table: "Proizvodnja");

            migrationBuilder.DropColumn(
                name: "RadnikID",
                table: "Proizvodnja");

            migrationBuilder.RenameColumn(
                name: "ProizvodID",
                table: "Burad",
                newName: "ProizvodnjaID");

            migrationBuilder.RenameIndex(
                name: "IX_Burad_ProizvodID",
                table: "Burad",
                newName: "IX_Burad_ProizvodnjaID");

            migrationBuilder.AddColumn<int>(
                name: "Godina",
                table: "Proizvodnja",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Proizvod",
                table: "Burad",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

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
                name: "IX_ProizvodnjaRadnik_RadnikID",
                table: "ProizvodnjaRadnik",
                column: "RadnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Burad_Proizvodnja_ProizvodnjaID",
                table: "Burad",
                column: "ProizvodnjaID",
                principalTable: "Proizvodnja",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
