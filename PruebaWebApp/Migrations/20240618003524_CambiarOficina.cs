using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class CambiarOficina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sueldo",
                table: "Oficinas",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Puesto",
                table: "Oficinas",
                newName: "Direccion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Oficinas",
                newName: "Sueldo");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Oficinas",
                newName: "Puesto");
        }
    }
}
