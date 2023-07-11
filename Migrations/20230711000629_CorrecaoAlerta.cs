using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Nemo.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoAlerta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerta_AquarioParametros_AquarioParametroId",
                table: "Alerta");

            migrationBuilder.DropForeignKey(
                name: "FK_Alerta_Aquarios_AquarioId",
                table: "Alerta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alerta",
                table: "Alerta");

            migrationBuilder.RenameTable(
                name: "Alerta",
                newName: "Alertas");

            migrationBuilder.RenameIndex(
                name: "IX_Alerta_AquarioParametroId",
                table: "Alertas",
                newName: "IX_Alertas_AquarioParametroId");

            migrationBuilder.RenameIndex(
                name: "IX_Alerta_AquarioId",
                table: "Alertas",
                newName: "IX_Alertas_AquarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alertas",
                table: "Alertas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alertas_AquarioParametros_AquarioParametroId",
                table: "Alertas",
                column: "AquarioParametroId",
                principalTable: "AquarioParametros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alertas_Aquarios_AquarioId",
                table: "Alertas",
                column: "AquarioId",
                principalTable: "Aquarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alertas_AquarioParametros_AquarioParametroId",
                table: "Alertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Alertas_Aquarios_AquarioId",
                table: "Alertas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alertas",
                table: "Alertas");

            migrationBuilder.RenameTable(
                name: "Alertas",
                newName: "Alerta");

            migrationBuilder.RenameIndex(
                name: "IX_Alertas_AquarioParametroId",
                table: "Alerta",
                newName: "IX_Alerta_AquarioParametroId");

            migrationBuilder.RenameIndex(
                name: "IX_Alertas_AquarioId",
                table: "Alerta",
                newName: "IX_Alerta_AquarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alerta",
                table: "Alerta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerta_AquarioParametros_AquarioParametroId",
                table: "Alerta",
                column: "AquarioParametroId",
                principalTable: "AquarioParametros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alerta_Aquarios_AquarioId",
                table: "Alerta",
                column: "AquarioId",
                principalTable: "Aquarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
