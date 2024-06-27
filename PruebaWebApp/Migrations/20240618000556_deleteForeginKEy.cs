using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class deleteForeginKEy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "DetalleUsuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "DetalleUsuarios",
                type: "int",
                nullable: true);
        }
    }
}
