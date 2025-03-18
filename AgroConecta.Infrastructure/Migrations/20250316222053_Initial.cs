using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgroConecta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    nombre_completo = table.Column<string>(type: "text", nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    NombrePerfil = table.Column<string>(type: "text", nullable: false),
                    DescripcionPerfil = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoArchivo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoArchivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoArrendamiento",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RegistroActivo = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoArrendamiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCultivo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCultivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMedidaArea",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RegistroActivo = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMedidaArea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoSuelo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RegistroActivo = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSuelo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPerfil",
                columns: table => new
                {
                    perfilesId = table.Column<string>(type: "text", nullable: false),
                    usuariosId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPerfil", x => new { x.perfilesId, x.usuariosId });
                    table.ForeignKey(
                        name: "FK_UsuarioPerfil_AspNetUsers_usuariosId",
                        column: x => x.usuariosId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPerfil_Perfil_perfilesId",
                        column: x => x.perfilesId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Archivo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TipoArchivoId = table.Column<string>(type: "text", nullable: false),
                    ReferenciaId = table.Column<string>(type: "text", nullable: false),
                    NombreArchivo = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    UrlArchivo = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Formato = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archivo_TipoArchivo_TipoArchivoId",
                        column: x => x.TipoArchivoId,
                        principalTable: "TipoArchivo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Terreno",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PropietarioId = table.Column<string>(type: "text", nullable: false),
                    TipoMedidaAreaId = table.Column<string>(type: "text", nullable: false),
                    TipoSueloId = table.Column<string>(type: "text", nullable: false),
                    CoordenadaLatitud = table.Column<double>(type: "double precision", nullable: false),
                    CoordenadaLongitud = table.Column<double>(type: "double precision", nullable: false),
                    CantidadAreaSueloTotal = table.Column<double>(type: "double precision", nullable: false),
                    CantidadAreaSueloDisponible = table.Column<double>(type: "double precision", nullable: false),
                    Comentario = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    estado = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terreno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terreno_AspNetUsers_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Terreno_TipoMedidaArea_TipoMedidaAreaId",
                        column: x => x.TipoMedidaAreaId,
                        principalTable: "TipoMedidaArea",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Terreno_TipoSuelo_TipoSueloId",
                        column: x => x.TipoSueloId,
                        principalTable: "TipoSuelo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Arrendamiento",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TerrenoId = table.Column<string>(type: "text", nullable: false),
                    AgricultorId = table.Column<string>(type: "text", nullable: false),
                    TipoArrendamientoId = table.Column<string>(type: "text", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Condiciones = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CantidadAreaSueloArrendada = table.Column<double>(type: "double precision", nullable: false),
                    MontoPago = table.Column<decimal>(type: "numeric", nullable: false),
                    FrecuenciaPago = table.Column<string>(type: "text", nullable: false),
                    Comentario = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrendamiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arrendamiento_AspNetUsers_AgricultorId",
                        column: x => x.AgricultorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Arrendamiento_Terreno_TerrenoId",
                        column: x => x.TerrenoId,
                        principalTable: "Terreno",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Arrendamiento_TipoArrendamiento_TipoArrendamientoId",
                        column: x => x.TipoArrendamientoId,
                        principalTable: "TipoArrendamiento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Proyecto",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ArrendamientoId = table.Column<string>(type: "text", nullable: false),
                    InversionistaId = table.Column<string>(type: "text", nullable: false),
                    TipoCultivoId = table.Column<string>(type: "text", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    MontoTotalPresupuesto = table.Column<decimal>(type: "numeric", nullable: false),
                    Objetivos = table.Column<string>(type: "text", nullable: false),
                    ResultadosEsperados = table.Column<string>(type: "text", nullable: false),
                    MontoTotalRetornoEstimado = table.Column<decimal>(type: "numeric", nullable: false),
                    Comentario = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    RegistroActivo = table.Column<bool>(type: "boolean", nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyecto_Arrendamiento_ArrendamientoId",
                        column: x => x.ArrendamientoId,
                        principalTable: "Arrendamiento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proyecto_AspNetUsers_InversionistaId",
                        column: x => x.InversionistaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proyecto_TipoCultivo_TipoCultivoId",
                        column: x => x.TipoCultivoId,
                        principalTable: "TipoCultivo",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "DeletedTimeUtc", "DescripcionPerfil", "IsDeleted", "LastUpdateUtc", "NombrePerfil" },
                values: new object[,]
                {
                    { "118cf490-f506-43c8-a43b-41143886ea8f", null, "Propietario", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Propietario" },
                    { "28b241ba-5797-4e1f-9ab4-456d18181ec9", null, "Inversionista", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inversionista" },
                    { "5d243871-1b82-4afc-8bed-3657729e615a", null, "Agricultor", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agricultor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archivo_TipoArchivoId",
                table: "Archivo",
                column: "TipoArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrendamiento_AgricultorId",
                table: "Arrendamiento",
                column: "AgricultorId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrendamiento_TerrenoId",
                table: "Arrendamiento",
                column: "TerrenoId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrendamiento_TipoArrendamientoId",
                table: "Arrendamiento",
                column: "TipoArrendamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_ArrendamientoId",
                table: "Proyecto",
                column: "ArrendamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_InversionistaId",
                table: "Proyecto",
                column: "InversionistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_TipoCultivoId",
                table: "Proyecto",
                column: "TipoCultivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Terreno_PropietarioId",
                table: "Terreno",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Terreno_TipoMedidaAreaId",
                table: "Terreno",
                column: "TipoMedidaAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Terreno_TipoSueloId",
                table: "Terreno",
                column: "TipoSueloId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPerfil_usuariosId",
                table: "UsuarioPerfil",
                column: "usuariosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archivo");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Proyecto");

            migrationBuilder.DropTable(
                name: "UsuarioPerfil");

            migrationBuilder.DropTable(
                name: "TipoArchivo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Arrendamiento");

            migrationBuilder.DropTable(
                name: "TipoCultivo");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Terreno");

            migrationBuilder.DropTable(
                name: "TipoArrendamiento");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TipoMedidaArea");

            migrationBuilder.DropTable(
                name: "TipoSuelo");
        }
    }
}
