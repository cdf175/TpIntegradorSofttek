using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpIntegradorSofttek.Migrations
{
    public partial class modclave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Clave",
                table: "Usuario",
                newName: "Contrasena");

            migrationBuilder.AlterColumn<string>(
                name: "Contrasena",
                table: "Usuario",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contrasena",
                table: "Usuario",
                newName: "Clave");

            migrationBuilder.AlterColumn<string>(
                name: "Clave",
                table: "Usuario",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);

            migrationBuilder.UpdateData(
                table: "Trabajo",
                keyColumn: "codTrabajo",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 9, 12, 6, 13, 18, 715, DateTimeKind.Local).AddTicks(1076));

            migrationBuilder.UpdateData(
                table: "Trabajo",
                keyColumn: "codTrabajo",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2023, 9, 12, 6, 13, 18, 715, DateTimeKind.Local).AddTicks(1087));
        }
    }
}
