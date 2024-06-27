using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class changeForeginKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_DetalleUsuarios_DetalleUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DetalleUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DetalleUsuarioId",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "DetalleUsuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleUsuarios_UsuarioId",
                table: "DetalleUsuarios",
                column: "UsuarioId",
                unique: true,
                filter: "[UsuarioId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleUsuarios_Usuarios_UsuarioId",
                table: "DetalleUsuarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleUsuarios_Usuarios_UsuarioId",
                table: "DetalleUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_DetalleUsuarios_UsuarioId",
                table: "DetalleUsuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "DetalleUsuarios");

            migrationBuilder.AddColumn<int>(
                name: "DetalleUsuarioId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DetalleUsuarioId",
                table: "Usuarios",
                column: "DetalleUsuarioId",
                unique: true,
                filter: "[DetalleUsuarioId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_DetalleUsuarios_DetalleUsuarioId",
                table: "Usuarios",
                column: "DetalleUsuarioId",
                principalTable: "DetalleUsuarios",
                principalColumn: "Id");
        }
    }
}
