using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Nemo.Migrations
{
    /// <inheritdoc />
    public partial class FKusuarioAquario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioAquarios_Aquarios_UsuariosId",
                table: "UsuarioAquarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioAquarios_Usuarios_AquariosId",
                table: "UsuarioAquarios");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioAquarios_Aquarios_AquariosId",
                table: "UsuarioAquarios",
                column: "AquariosId",
                principalTable: "Aquarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioAquarios_Usuarios_UsuariosId",
                table: "UsuarioAquarios",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioAquarios_Aquarios_AquariosId",
                table: "UsuarioAquarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioAquarios_Usuarios_UsuariosId",
                table: "UsuarioAquarios");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioAquarios_Aquarios_UsuariosId",
                table: "UsuarioAquarios",
                column: "UsuariosId",
                principalTable: "Aquarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioAquarios_Usuarios_AquariosId",
                table: "UsuarioAquarios",
                column: "AquariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
