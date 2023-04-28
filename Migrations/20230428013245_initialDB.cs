using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Nemo.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Min = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aquarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAquario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Largura = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<int>(type: "int", nullable: false),
                    Comprimento = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aquarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aquarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AquarioParametros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AquariosId = table.Column<int>(type: "int", nullable: false),
                    ParametrosId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AquarioParametros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AquarioParametros_Aquarios_AquariosId",
                        column: x => x.AquariosId,
                        principalTable: "Aquarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AquarioParametros_Parametros_ParametrosId",
                        column: x => x.ParametrosId,
                        principalTable: "Parametros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioAquario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuariosId = table.Column<int>(type: "int", nullable: false),
                    AquariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioAquario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioAquario_Aquarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Aquarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioAquario_Usuarios_AquariosId",
                        column: x => x.AquariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Historicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    AquarioParametroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historicos_AquarioParametros_AquarioParametroId",
                        column: x => x.AquarioParametroId,
                        principalTable: "AquarioParametros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historicos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AquarioParametros_AquariosId",
                table: "AquarioParametros",
                column: "AquariosId");

            migrationBuilder.CreateIndex(
                name: "IX_AquarioParametros_ParametrosId",
                table: "AquarioParametros",
                column: "ParametrosId");

            migrationBuilder.CreateIndex(
                name: "IX_Aquarios_UsuarioId",
                table: "Aquarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Historicos_AquarioParametroId",
                table: "Historicos",
                column: "AquarioParametroId");

            migrationBuilder.CreateIndex(
                name: "IX_Historicos_UsuarioId",
                table: "Historicos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioAquario_AquariosId",
                table: "UsuarioAquario",
                column: "AquariosId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioAquario_UsuariosId",
                table: "UsuarioAquario",
                column: "UsuariosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historicos");

            migrationBuilder.DropTable(
                name: "UsuarioAquario");

            migrationBuilder.DropTable(
                name: "AquarioParametros");

            migrationBuilder.DropTable(
                name: "Aquarios");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
