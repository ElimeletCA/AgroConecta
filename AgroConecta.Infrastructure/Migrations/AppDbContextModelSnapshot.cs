﻿// <auto-generated />
using System;
using AgroConecta.Infrastructure.Repositorio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgroConecta.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AgroConecta.Domain.System.Arrendamiento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("agricultor_id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("cantidad_area_suelo_arrendada")
                        .HasColumnType("double precision");

                    b.Property<string>("comentario")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("condiciones")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("estado")
                        .HasColumnType("integer");

                    b.Property<DateTime>("fecha_fin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("fecha_inicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("frecuencia_pago")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("monto_pago")
                        .HasColumnType("numeric");

                    b.Property<bool>("registro_activo")
                        .HasColumnType("boolean");

                    b.Property<int>("terreno_id")
                        .HasColumnType("integer");

                    b.Property<int>("tipo_arrendamiento_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("agricultor_id");

                    b.HasIndex("terreno_id");

                    b.HasIndex("tipo_arrendamiento_id");

                    b.ToTable("Arrendamiento", (string)null);
                });

            modelBuilder.Entity("AgroConecta.Domain.System.Extras.Archivo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("estado")
                        .HasColumnType("integer");

                    b.Property<DateTime>("fecha_creacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("formato")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nombre_archivo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("referencia_id")
                        .HasColumnType("integer");

                    b.Property<string>("size")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("tipo_archivo_id")
                        .HasColumnType("integer");

                    b.Property<string>("url_archivo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("tipo_archivo_id");

                    b.ToTable("Archivo", (string)null);
                });

            modelBuilder.Entity("AgroConecta.Domain.System.Proyecto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("arrendamiento_id")
                        .HasColumnType("integer");

                    b.Property<string>("comentario")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("estado")
                        .HasColumnType("integer");

                    b.Property<DateTime>("fecha_fin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("fecha_inicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("inversionista_id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("monto_total_presupuesto")
                        .HasColumnType("numeric");

                    b.Property<decimal>("monto_total_retorno_estimado")
                        .HasColumnType("numeric");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("objetivos")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("registro_activo")
                        .HasColumnType("boolean");

                    b.Property<string>("resultados_esperados")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("tipo_cultivo_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("arrendamiento_id");

                    b.HasIndex("inversionista_id");

                    b.HasIndex("tipo_cultivo_id");

                    b.ToTable("Proyecto", (string)null);
                });

            modelBuilder.Entity("AgroConecta.Domain.System.Seguridad.Perfil", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion_perfil")
                        .HasColumnType("text");

                    b.Property<string>("nombre_perfil")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Perfil", (string)null);

                    b.HasData(
                        new
                        {
                            id = 1,
                            descripcion_perfil = "Propietario",
                            nombre_perfil = "Propietario"
                        },
                        new
                        {
                            id = 2,
                            descripcion_perfil = "Agricultor",
                            nombre_perfil = "Agricultor"
                        },
                        new
                        {
                            id = 3,
                            descripcion_perfil = "Inversionista",
                            nombre_perfil = "Inversionista"
                        });
                });

            modelBuilder.Entity("AgroConecta.Domain.System.Seguridad.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("fecha_nacimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("nombre_completo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("AgroConecta.Domain.System.Terreno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<double>("cantidad_area_suelo_disponible")
                        .HasColumnType("double precision");

                    b.Property<double>("cantidad_area_suelo_total")
                        .HasColumnType("double precision");

                    b.Property<string>("comentario")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<double>("coordenada_latitud")
                        .HasColumnType("double precision");

                    b.Property<double>("coordenada_longitud")
                        .HasColumnType("double precision");

                    b.Property<int>("estado")
                        .HasColumnType("integer");

                    b.Property<string>("propietario_id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("registro_activo")
                        .HasColumnType("boolean");

                    b.Property<int>("tipo_medida_area_id")
                        .HasColumnType("integer");

                    b.Property<int>("tipo_suelo_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("propietario_id");

                    b.HasIndex("tipo_medida_area_id");

                    b.HasIndex("tipo_suelo_id");

                    b.ToTable("Terreno", (string)null);
                });

            modelBuilder.Entity("AgroConecta.Domain.System.TipoArchivo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("registro_activo")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.ToTable("TipoArchivo", (string)null);
                });

            modelBuilder.Entity("AgroConecta.Domain.System.TipoArrendamiento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("registro_activo")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.ToTable("TipoArrendamiento", (string)null);
                });

            modelBuilder.Entity("AgroConecta.Domain.System.TipoCultivo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("registro_activo")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.ToTable("TipoCultivo", (string)null);
                });

            modelBuilder.Entity("AgroConecta.Domain.System.TipoMedidaArea", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("registro_activo")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.ToTable("TipoMedidaArea", (string)null);
                });

            modelBuilder.Entity("AgroConecta.Domain.System.TipoSuelo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("registro_activo")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.ToTable("TipoSuelo", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PerfilUsuario", b =>
                {
                    b.Property<int>("perfilesid")
                        .HasColumnType("integer");

                    b.Property<string>("usuariosId")
                        .HasColumnType("text");

                    b.HasKey("perfilesid", "usuariosId");

                    b.HasIndex("usuariosId");

                    b.ToTable("UsuarioPerfil", (string)null);
                });

            modelBuilder.Entity("AgroConecta.Domain.System.Arrendamiento", b =>
                {
                    b.HasOne("AgroConecta.Domain.System.Seguridad.Usuario", "agricultor")
                        .WithMany("arrendamientos")
                        .HasForeignKey("agricultor_id")
                        .IsRequired();

                    b.HasOne("AgroConecta.Domain.System.Terreno", "terreno")
                        .WithMany("arrendamientos")
                        .HasForeignKey("terreno_id")
                        .IsRequired();

                    b.HasOne("AgroConecta.Domain.System.TipoArrendamiento", "tipo_arrendamiento")
                        .WithMany("arrendamientos")
                        .HasForeignKey("tipo_arrendamiento_id")
                        .IsRequired();

                    b.Navigation("agricultor");

                    b.Navigation("terreno");

                    b.Navigation("tipo_arrendamiento");
                });

            modelBuilder.Entity("AgroConecta.Domain.System.Extras.Archivo", b =>
                {
                    b.HasOne("AgroConecta.Domain.System.TipoArchivo", "tipo_archivo")
                        .WithMany("archivos")
                        .HasForeignKey("tipo_archivo_id")
                        .IsRequired();

                    b.Navigation("tipo_archivo");
                });

            modelBuilder.Entity("AgroConecta.Domain.System.Proyecto", b =>
                {
                    b.HasOne("AgroConecta.Domain.System.Arrendamiento", "arrendamiento")
                        .WithMany("proyectos")
                        .HasForeignKey("arrendamiento_id")
                        .IsRequired();

                    b.HasOne("AgroConecta.Domain.System.Seguridad.Usuario", "inversionista")
                        .WithMany("proyectos")
                        .HasForeignKey("inversionista_id")
                        .IsRequired();

                    b.HasOne("AgroConecta.Domain.System.TipoCultivo", "tipo_cultivo")
                        .WithMany("proyectos")
                        .HasForeignKey("tipo_cultivo_id")
                        .IsRequired();

                    b.Navigation("arrendamiento");

                    b.Navigation("inversionista");

                    b.Navigation("tipo_cultivo");
                });

            modelBuilder.Entity("AgroConecta.Domain.System.Terreno", b =>
                {
                    b.HasOne("AgroConecta.Domain.System.Seguridad.Usuario", "propietario")
                        .WithMany("terrenos")
                        .HasForeignKey("propietario_id")
                        .IsRequired();

                    b.HasOne("AgroConecta.Domain.System.TipoMedidaArea", "tipo_medida_area")
                        .WithMany("terrenos")
                        .HasForeignKey("tipo_medida_area_id")
                        .IsRequired();

                    b.HasOne("AgroConecta.Domain.System.TipoSuelo", "tipo_suelo")
                        .WithMany("terrenos")
                        .HasForeignKey("tipo_suelo_id")
                        .IsRequired();

                    b.Navigation("propietario");

                    b.Navigation("tipo_medida_area");

                    b.Navigation("tipo_suelo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AgroConecta.Domain.System.Seguridad.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AgroConecta.Domain.System.Seguridad.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroConecta.Domain.System.Seguridad.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AgroConecta.Domain.System.Seguridad.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PerfilUsuario", b =>
                {
                    b.HasOne("AgroConecta.Domain.System.Seguridad.Perfil", null)
                        .WithMany()
                        .HasForeignKey("perfilesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroConecta.Domain.System.Seguridad.Usuario", null)
                        .WithMany()
                        .HasForeignKey("usuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgroConecta.Domain.System.Arrendamiento", b =>
                {
                    b.Navigation("proyectos");
                });

            modelBuilder.Entity("AgroConecta.Domain.System.Seguridad.Usuario", b =>
                {
                    b.Navigation("arrendamientos");

                    b.Navigation("proyectos");

                    b.Navigation("terrenos");
                });

            modelBuilder.Entity("AgroConecta.Domain.System.Terreno", b =>
                {
                    b.Navigation("arrendamientos");
                });

            modelBuilder.Entity("AgroConecta.Domain.System.TipoArchivo", b =>
                {
                    b.Navigation("archivos");
                });

            modelBuilder.Entity("AgroConecta.Domain.System.TipoArrendamiento", b =>
                {
                    b.Navigation("arrendamientos");
                });

            modelBuilder.Entity("AgroConecta.Domain.System.TipoCultivo", b =>
                {
                    b.Navigation("proyectos");
                });

            modelBuilder.Entity("AgroConecta.Domain.System.TipoMedidaArea", b =>
                {
                    b.Navigation("terrenos");
                });

            modelBuilder.Entity("AgroConecta.Domain.System.TipoSuelo", b =>
                {
                    b.Navigation("terrenos");
                });
#pragma warning restore 612, 618
        }
    }
}
