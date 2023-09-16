using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpIntegradorSofttek.Migrations
{
    public partial class encryptPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trabajo",
                keyColumn: "codTrabajo",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 9, 15, 23, 21, 31, 8, DateTimeKind.Local).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "Trabajo",
                keyColumn: "codTrabajo",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2023, 9, 15, 23, 21, 31, 8, DateTimeKind.Local).AddTicks(14));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "codUsuario",
                keyValue: 1,
                column: "Contrasena",
                value: "ef9c2073b6187696c74a75e1b8c9382fe3c9abea4a777ec9d0fd16435d3c87e6");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "codUsuario",
                keyValue: 2,
                column: "Contrasena",
                value: "ef9c2073b6187696c74a75e1b8c9382fe3c9abea4a777ec9d0fd16435d3c87e6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trabajo",
                keyColumn: "codTrabajo",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 9, 15, 21, 35, 17, 695, DateTimeKind.Local).AddTicks(4940));

            migrationBuilder.UpdateData(
                table: "Trabajo",
                keyColumn: "codTrabajo",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2023, 9, 15, 21, 35, 17, 695, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "codUsuario",
                keyValue: 1,
                column: "Contrasena",
                value: "123456");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "codUsuario",
                keyValue: 2,
                column: "Contrasena",
                value: "123456");
        }
    }
}
