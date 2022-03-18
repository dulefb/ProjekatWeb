using Microsoft.EntityFrameworkCore.Migrations;

namespace Proba1.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Burad_Proizvod_ProizvodID",
                table: "Burad");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropIndex(
                name: "IX_Burad_ProizvodID",
                table: "Burad");

            migrationBuilder.DropColumn(
                name: "ProizvodID",
                table: "Burad");

            migrationBuilder.AddColumn<string>(
                name: "Proizvod",
                table: "Burad",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proizvod",
                table: "Burad");

            migrationBuilder.AddColumn<int>(
                name: "ProizvodID",
                table: "Burad",
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
                name: "IX_Burad_ProizvodID",
                table: "Burad",
                column: "ProizvodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Burad_Proizvod_ProizvodID",
                table: "Burad",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
