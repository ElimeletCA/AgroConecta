using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgroConecta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProvinciasYMunicipios : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "MunicipioId",
                table: "Terreno",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioPorArea",
                table: "Terreno",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Latitud = table.Column<double>(type: "double precision", nullable: true),
                    Longitud = table.Column<double>(type: "double precision", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ProvinciaId = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Latitud = table.Column<double>(type: "double precision", nullable: true),
                    Longitud = table.Column<double>(type: "double precision", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipio_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "DeletedTimeUtc", "DescripcionPerfil", "IsDeleted", "LastUpdateUtc", "NombrePerfil" },
                values: new object[,]
                {
                    { "006da7fd-3c10-4b70-90c2-7380c3e5febf", null, "Propietario", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Propietario" },
                    { "5286e36d-7418-4940-997b-0880959a2483", null, "Inversionista", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inversionista" },
                    { "cd65bea9-e37d-4672-a7f3-115e1b911eaf", null, "Agricultor", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agricultor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Terreno_MunicipioId",
                table: "Terreno",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_ProvinciaId",
                table: "Municipio",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Terreno_Municipio_MunicipioId",
                table: "Terreno",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Terreno_Municipio_MunicipioId",
                table: "Terreno");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropIndex(
                name: "IX_Terreno_MunicipioId",
                table: "Terreno");

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
                name: "MunicipioId",
                table: "Terreno");

            migrationBuilder.DropColumn(
                name: "PrecioPorArea",
                table: "Terreno");

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
