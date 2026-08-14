using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Modelo.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ordenCompra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    codigo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenCompra", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    codigo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    tipo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ruc = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    direccion_calle_principal = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    direccion_calle_secundaria = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    direccion_numero = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    direccion_ciudad = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    direccion_pais = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ordenCompraDetalle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductoId = table.Column<Guid>(type: "char(36)", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    OrdenCompraId = table.Column<Guid>(type: "char(36)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenCompraDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ordenCompraDetalle_ordenCompra_OrdenCompraId",
                        column: x => x.OrdenCompraId,
                        principalTable: "ordenCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordenCompraDetalle_productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ordenCompraDetalle_OrdenCompraId",
                table: "ordenCompraDetalle",
                column: "OrdenCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_ordenCompraDetalle_ProductoId",
                table: "ordenCompraDetalle",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_proveedores_ruc",
                table: "proveedores",
                column: "ruc",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ordenCompraDetalle");

            migrationBuilder.DropTable(
                name: "proveedores");

            migrationBuilder.DropTable(
                name: "ordenCompra");

            migrationBuilder.DropTable(
                name: "productos");
        }
    }
}
