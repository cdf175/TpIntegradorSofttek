using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpIntegradorSofttek.Migrations
{
    public partial class renameClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trabajo",
                keyColumn: "codTrabajo",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 9, 15, 1, 39, 38, 904, DateTimeKind.Local).AddTicks(9906));

            migrationBuilder.UpdateData(
                table: "Trabajo",
                keyColumn: "codTrabajo",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2023, 9, 15, 1, 39, 38, 904, DateTimeKind.Local).AddTicks(9917));
        }
    }
}
