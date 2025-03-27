using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgroConecta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDescripcionTerreno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "006da7fd-3c10-4b70-90c2-7380c3e5febf");

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "5286e36d-7418-4940-997b-0880959a2483");

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: "cd65bea9-e37d-4672-a7f3-115e1b911eaf");

            migrationBuilder.DropColumn(
                name: "RegistroActivo",
                table: "Proyecto");

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Terreno",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Descripción",
                table: "Terreno",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Proyecto",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Arrendamiento",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Descripción",
                table: "Arrendamiento",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Descripción",
                table: "Terreno");

            migrationBuilder.DropColumn(
                name: "Descripción",
                table: "Arrendamiento");

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Terreno",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Proyecto",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RegistroActivo",
                table: "Proyecto",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Arrendamiento",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "DeletedTimeUtc", "DescripcionPerfil", "IsDeleted", "LastUpdateUtc", "NombrePerfil" },
                values: new object[,]
                {
                    { "006da7fd-3c10-4b70-90c2-7380c3e5febf", null, "Propietario", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Propietario" },
                    { "5286e36d-7418-4940-997b-0880959a2483", null, "Inversionista", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inversionista" },
                    { "cd65bea9-e37d-4672-a7f3-115e1b911eaf", null, "Agricultor", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agricultor" }
                });
        }
    }
}
