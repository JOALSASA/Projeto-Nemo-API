using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Nemo.Migrations
{
    /// <inheritdoc />
    public partial class alteracaoPerfis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfilUsuarios");

            migrationBuilder.CreateTable(
                name: "PerfilUsuario",
                columns: table => new
                {
                    PerfisId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUsuario", x => new { x.PerfisId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_PerfilUsuario_Perfis_PerfisId",
                        column: x => x.PerfisId,
                        principalTable: "Perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilUsuario_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuario_UsuariosId",
                table: "PerfilUsuario",
                column: "UsuariosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfilUsuario");

            migrationBuilder.CreateTable(
                name: "PerfilUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfisId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfilUsuarios_Perfis_PerfisId",
                        column: x => x.PerfisId,
                        principalTable: "Perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilUsuarios_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarios_PerfisId",
                table: "PerfilUsuarios",
                column: "PerfisId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarios_UsuariosId",
                table: "PerfilUsuarios",
                column: "UsuariosId");
        }
    }
}
