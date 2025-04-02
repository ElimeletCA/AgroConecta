using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgroConecta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionArchivoEntidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "6e6814a0-87a7-491e-ae54-5090bda9be18");

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "b75acc40-3491-45cc-b80e-58e9b559cdd7");

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "f80e11d8-e9d1-4b7f-b106-a49e0173ab58");

            migrationBuilder.DropColumn(
                name: "Formato",
                table: "Archivo");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Archivo");

            migrationBuilder.RenameColumn(
                name: "UrlArchivo",
                table: "Archivo",
                newName: "NombreArchivoAlmacenado");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Archivo",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "TipoContenido",
                table: "Archivo",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "DeletedTimeUtc", "DescripcionPerfil", "IsDeleted", "LastUpdateUtc", "NombrePerfil" },
                values: new object[,]
                {
                    { "89e89c4f-34a6-463d-95a4-59bc2e883577", null, "Inversionista", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inversionista" },
                    { "ed0a445a-a4d5-4cdc-8b90-8af7b3f2636f", null, "Agricultor", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agricultor" },
                    { "eec5cda8-94d5-4cf2-8519-675ca3803fb7", null, "Propietario", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Propietario" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "89e89c4f-34a6-463d-95a4-59bc2e883577");

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "ed0a445a-a4d5-4cdc-8b90-8af7b3f2636f");

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "eec5cda8-94d5-4cf2-8519-675ca3803fb7");

            migrationBuilder.DropColumn(
                name: "TipoContenido",
                table: "Archivo");

            migrationBuilder.RenameColumn(
                name: "NombreArchivoAlmacenado",
                table: "Archivo",
                newName: "UrlArchivo");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Archivo",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Formato",
                table: "Archivo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Archivo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "DeletedTimeUtc", "DescripcionPerfil", "IsDeleted", "LastUpdateUtc", "NombrePerfil" },
                values: new object[,]
                {
                    { "6e6814a0-87a7-491e-ae54-5090bda9be18", null, "Inversionista", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inversionista" },
                    { "b75acc40-3491-45cc-b80e-58e9b559cdd7", null, "Propietario", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Propietario" },
                    { "f80e11d8-e9d1-4b7f-b106-a49e0173ab58", null, "Agricultor", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agricultor" }
                });
        }
    }
}
