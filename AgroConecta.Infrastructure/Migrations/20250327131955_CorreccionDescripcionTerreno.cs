using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgroConecta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionDescripcionTerreno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "5423b4eb-84f3-4521-9330-c7a70e8f8727");

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "5d81051d-27c5-44aa-bd98-06d4f6d3e958");

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "713c5c63-9aed-4226-8d71-ad5ea18db88d");

            migrationBuilder.RenameColumn(
                name: "Descripción",
                table: "Terreno",
                newName: "Descripcion");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Terreno",
                newName: "Descripción");

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "DeletedTimeUtc", "DescripcionPerfil", "IsDeleted", "LastUpdateUtc", "NombrePerfil" },
                values: new object[,]
                {
                    { "5423b4eb-84f3-4521-9330-c7a70e8f8727", null, "Agricultor", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agricultor" },
                    { "5d81051d-27c5-44aa-bd98-06d4f6d3e958", null, "Inversionista", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inversionista" },
                    { "713c5c63-9aed-4226-8d71-ad5ea18db88d", null, "Propietario", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Propietario" }
                });
        }
    }
}
