using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PruebaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class datos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Oficinas",
                columns: new[] { "Id", "Direccion", "Nombre", "UsuarioId" },
                values: new object[] { 2, "Avenida 456", "Oficina 2", null });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Descripción del Proyecto 1", "Proyecto 1" },
                    { 2, "Descripción del Proyecto 2", "Proyecto 2" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "CategoriaId", "Cedula", "Nombre" },
                values: new object[,]
                {
                    { 1, "Perez", 1, "12345678", "Juan" },
                    { 2, "Gomez", 2, "87654321", "Maria" }
                });

            migrationBuilder.InsertData(
                table: "Oficinas",
                columns: new[] { "Id", "Direccion", "Nombre", "UsuarioId" },
                values: new object[] { 1, "Calle 123", "Oficina 1", 1 });

            migrationBuilder.InsertData(
                table: "UsuarioProyectos",
                columns: new[] { "IdProyecto", "IdUsuario" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Oficinas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Oficinas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UsuarioProyectos",
                keyColumns: new[] { "IdProyecto", "IdUsuario" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UsuarioProyectos",
                keyColumns: new[] { "IdProyecto", "IdUsuario" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UsuarioProyectos",
                keyColumns: new[] { "IdProyecto", "IdUsuario" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
