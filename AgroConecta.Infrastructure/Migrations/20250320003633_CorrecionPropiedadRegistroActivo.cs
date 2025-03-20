using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgroConecta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionPropiedadRegistroActivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "354ae1c6-cbc8-4427-a1ad-82341673bbb5");

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "871be731-c4f5-46bd-bf75-90c2991c41ec");

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "d67740dc-8e74-40f1-b25d-adb12c16eed7");

            migrationBuilder.DropColumn(
                name: "RegistroActivo",
                table: "TipoSuelo");

            migrationBuilder.DropColumn(
                name: "RegistroActivo",
                table: "TipoMedidaArea");

            migrationBuilder.DropColumn(
                name: "RegistroActivo",
                table: "TipoArrendamiento");

            migrationBuilder.RenameColumn(
                name: "ReferenciaId",
                table: "Archivo",
                newName: "EntidadId");

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "DeletedTimeUtc", "DescripcionPerfil", "IsDeleted", "LastUpdateUtc", "NombrePerfil" },
                values: new object[,]
                {
                    { "013c0fb1-0617-43f3-b115-077a4191e7c7", null, "Agricultor", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agricultor" },
                    { "25200d12-7660-4c8b-b099-337985f2b868", null, "Propietario", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Propietario" },
                    { "3217c11d-b223-4383-b5df-3b59a87e8e79", null, "Inversionista", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inversionista" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "013c0fb1-0617-43f3-b115-077a4191e7c7");

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "25200d12-7660-4c8b-b099-337985f2b868");

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "3217c11d-b223-4383-b5df-3b59a87e8e79");

            migrationBuilder.RenameColumn(
                name: "EntidadId",
                table: "Archivo",
                newName: "ReferenciaId");

            migrationBuilder.AddColumn<bool>(
                name: "RegistroActivo",
                table: "TipoSuelo",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RegistroActivo",
                table: "TipoMedidaArea",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RegistroActivo",
                table: "TipoArrendamiento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "DeletedTimeUtc", "DescripcionPerfil", "IsDeleted", "LastUpdateUtc", "NombrePerfil" },
                values: new object[,]
                {
                    { "354ae1c6-cbc8-4427-a1ad-82341673bbb5", null, "Agricultor", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agricultor" },
                    { "871be731-c4f5-46bd-bf75-90c2991c41ec", null, "Propietario", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Propietario" },
                    { "d67740dc-8e74-40f1-b25d-adb12c16eed7", null, "Inversionista", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inversionista" }
                });
        }
    }
}
