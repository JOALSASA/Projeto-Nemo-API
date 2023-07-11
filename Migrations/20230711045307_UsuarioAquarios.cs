using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Nemo.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioAquarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioAquario_Aquarios_UsuariosId",
                table: "UsuarioAquario");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioAquario_Usuarios_AquariosId",
                table: "UsuarioAquario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioAquario",
                table: "UsuarioAquario");

            migrationBuilder.RenameTable(
                name: "UsuarioAquario",
                newName: "UsuarioAquarios");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioAquario_UsuariosId",
                table: "UsuarioAquarios",
                newName: "IX_UsuarioAquarios_UsuariosId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioAquario_AquariosId",
                table: "UsuarioAquarios",
                newName: "IX_UsuarioAquarios_AquariosId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioAquarios",
                table: "UsuarioAquarios",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioAquarios_Aquarios_UsuariosId",
                table: "UsuarioAquarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioAquarios_Usuarios_AquariosId",
                table: "UsuarioAquarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioAquarios",
                table: "UsuarioAquarios");

            migrationBuilder.RenameTable(
                name: "UsuarioAquarios",
                newName: "UsuarioAquario");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioAquarios_UsuariosId",
                table: "UsuarioAquario",
                newName: "IX_UsuarioAquario_UsuariosId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioAquarios_AquariosId",
                table: "UsuarioAquario",
                newName: "IX_UsuarioAquario_AquariosId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioAquario",
                table: "UsuarioAquario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioAquario_Aquarios_UsuariosId",
                table: "UsuarioAquario",
                column: "UsuariosId",
                principalTable: "Aquarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioAquario_Usuarios_AquariosId",
                table: "UsuarioAquario",
                column: "AquariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
