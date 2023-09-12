using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpIntegradorSofttek.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyecto",
                columns: table => new
                {
                    codProyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto", x => x.codProyecto);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    codServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descr = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.codServicio);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    codUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Clave = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.codUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Trabajo",
                columns: table => new
                {
                    codTrabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    codProyecto = table.Column<int>(type: "int", nullable: false),
                    codServicio = table.Column<int>(type: "int", nullable: false),
                    CantHoras = table.Column<int>(type: "int", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajo", x => x.codTrabajo);
                    table.ForeignKey(
                        name: "FK_Trabajo_Proyecto_codProyecto",
                        column: x => x.codProyecto,
                        principalTable: "Proyecto",
                        principalColumn: "codProyecto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trabajo_Servicio_codServicio",
                        column: x => x.codServicio,
                        principalTable: "Servicio",
                        principalColumn: "codServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Proyecto",
                columns: new[] { "codProyecto", "Direccion", "Estado", "FechaBaja", "Nombre" },
                values: new object[,]
                {
                    { 1, "Malargüe, Mendoza", 1, null, "Puesto Rojas" },
                    { 2, "Cuenca Neuquina Sur", 2, null, "Bandurria Sur" }
                });

            migrationBuilder.InsertData(
                table: "Servicio",
                columns: new[] { "codServicio", "Descr", "Estado", "FechaBaja", "ValorHora" },
                values: new object[,]
                {
                    { 1, "Construccion torre petrolera", true, null, 40000m },
                    { 2, "Refinamiento petroleo", true, null, 25000m }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "codUsuario", "Clave", "Dni", "Email", "FechaBaja", "Nombre", "Tipo" },
                values: new object[,]
                {
                    { 1, "123456", 1111, "admin@gmail.com", null, "Admin", 1 },
                    { 2, "123456", 2222, "test@gmail.com", null, "Test", 2 }
                });

            migrationBuilder.InsertData(
                table: "Trabajo",
                columns: new[] { "codTrabajo", "CantHoras", "Costo", "Fecha", "FechaBaja", "codProyecto", "codServicio", "ValorHora" },
                values: new object[] { 1, 700, 49000000m, new DateTime(2023, 9, 12, 6, 13, 18, 715, DateTimeKind.Local).AddTicks(1076), null, 1, 1, 70000m });

            migrationBuilder.InsertData(
                table: "Trabajo",
                columns: new[] { "codTrabajo", "CantHoras", "Costo", "Fecha", "FechaBaja", "codProyecto", "codServicio", "ValorHora" },
                values: new object[] { 2, 820, 58220000m, new DateTime(2023, 9, 12, 6, 13, 18, 715, DateTimeKind.Local).AddTicks(1087), null, 2, 1, 71000m });

            migrationBuilder.CreateIndex(
                name: "IX_Trabajo_codProyecto",
                table: "Trabajo",
                column: "codProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajo_codServicio",
                table: "Trabajo",
                column: "codServicio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabajo");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Proyecto");

            migrationBuilder.DropTable(
                name: "Servicio");
        }
    }
}
