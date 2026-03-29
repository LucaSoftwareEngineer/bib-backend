using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class NoleggioEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Noleggi",
                columns: table => new
                {
                    NoleggioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtenteId = table.Column<int>(type: "int", nullable: false),
                    LibroId = table.Column<int>(type: "int", nullable: false),
                    DataNoleggio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRestituzione = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noleggi", x => x.NoleggioId);
                    table.ForeignKey(
                        name: "FK_Noleggi_Libri_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libri",
                        principalColumn: "LibroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Noleggi_Utenti_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utenti",
                        principalColumn: "UtenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Noleggi_LibroId",
                table: "Noleggi",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_Noleggi_UtenteId",
                table: "Noleggi",
                column: "UtenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Noleggi");
        }
    }
}
