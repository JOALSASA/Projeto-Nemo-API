using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Nemo.Migrations
{
    /// <inheritdoc />
    public partial class Alerta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Min = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false),
                    EstadoAlerta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AquarioId = table.Column<int>(type: "int", nullable: false),
                    AquarioParametroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerta_AquarioParametros_AquarioParametroId",
                        column: x => x.AquarioParametroId,
                        principalTable: "AquarioParametros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alerta_Aquarios_AquarioId",
                        column: x => x.AquarioId,
                        principalTable: "Aquarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerta_AquarioId",
                table: "Alerta",
                column: "AquarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerta_AquarioParametroId",
                table: "Alerta",
                column: "AquarioParametroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerta");
        }
    }
}
