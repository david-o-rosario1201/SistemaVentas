using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaVentasDavid.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    NumeroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.NumeroId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Representante = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CedulaRepresentante = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    NumeroCuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Banco = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TipoContribuyenteId = table.Column<int>(type: "int", nullable: false),
                    RNC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "TiposContribuyente",
                columns: table => new
                {
                    TipoContribuyenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoContribuyente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposContribuyente", x => x.TipoContribuyenteId);
                });

            migrationBuilder.CreateTable(
                name: "ProveedoresDetalle",
                columns: table => new
                {
                    ProveedorDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    ContactoId = table.Column<int>(type: "int", nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedoresDetalle", x => x.ProveedorDetalleId);
                    table.ForeignKey(
                        name: "FK_ProveedoresDetalle_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contactos",
                columns: new[] { "NumeroId", "Numero" },
                values: new object[,]
                {
                    { 1, "Teléfono" },
                    { 2, "Fax" }
                });

            migrationBuilder.InsertData(
                table: "TiposContribuyente",
                columns: new[] { "TipoContribuyenteId", "TipoContribuyente" },
                values: new object[,]
                {
                    { 1, "Persona Fisica" },
                    { 2, "Persona Juridica" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProveedoresDetalle_ProveedorId",
                table: "ProveedoresDetalle",
                column: "ProveedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "ProveedoresDetalle");

            migrationBuilder.DropTable(
                name: "TiposContribuyente");

            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
