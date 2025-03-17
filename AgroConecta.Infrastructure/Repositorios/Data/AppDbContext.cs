using System.Diagnostics;
using AgroConecta.Domain.Sistema;
using AgroConecta.Domain.Sistema.Extras;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Domain.Sistema.Tipos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace AgroConecta.Infrastructure.Repositorios.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        try
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (databaseCreator != null)
            {
                if (!databaseCreator.CanConnect()) databaseCreator.Create();
                if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
            }
        }
        catch (System.Exception e)
        {
            Debug.WriteLine(e.Message);
        }
    }

    public DbSet<Archivo> Archivos { get; set; }
    public DbSet<Perfil> Perfiles { get; set; }
    public DbSet<Arrendamiento> Arrendamientos { get; set; }
    public DbSet<Proyecto> Proyectos { get; set; }
    public DbSet<Terreno> Terrenos { get; set; }
    public DbSet<TipoArchivo> TipoArchivos { get; set; }
    public DbSet<TipoArrendamiento> TipoArrendamientos { get; set; }
    public DbSet<TipoCultivo> TipoCultivos { get; set; }
    public DbSet<TipoMedidaArea> TipoMedidaAreas { get; set; }
    public DbSet<TipoSuelo> TipoSuelos { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        modelbuilder.Entity<Archivo>().ToTable("Archivo");
        modelbuilder.Entity<Perfil>().ToTable("Rol");
        modelbuilder.Entity<Arrendamiento>().ToTable("Arrendamiento");
        modelbuilder.Entity<Proyecto>().ToTable("Proyecto");
        modelbuilder.Entity<Terreno>().ToTable("Terreno");
        modelbuilder.Entity<TipoArchivo>().ToTable("TipoArchivo");
        modelbuilder.Entity<TipoArrendamiento>().ToTable("TipoArrendamiento");
        modelbuilder.Entity<TipoCultivo>().ToTable("TipoCultivo");
        modelbuilder.Entity<TipoMedidaArea>().ToTable("TipoMedidaArea");
        modelbuilder.Entity<TipoSuelo>().ToTable("TipoSuelo");
        modelbuilder.Entity<Perfil>().ToTable("Perfil");

         #region Relaciones Entidad -Terreno-

            modelbuilder.Entity<Terreno>()
                   .HasOne(terreno => terreno.Propietario)
                   .WithMany(usuario => usuario.terrenos)
                   .HasForeignKey(terreno => terreno.PropietarioId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            
            
            modelbuilder.Entity<Terreno>()
                .HasOne(terreno => terreno.TipoMedidaArea)
                .WithMany(tipo_medida_area => tipo_medida_area.Terrenos)
                .HasForeignKey(terreno => terreno.TipoMedidaAreaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelbuilder.Entity<Terreno>()
                .HasOne(terreno => terreno.TipoSuelo)
                .WithMany(tipo_suelo => tipo_suelo.Terrenos)
                .HasForeignKey(terreno => terreno.TipoSueloId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
        #endregion
        
        #region Relaciones Entidad -Arrendamiento-
        
        modelbuilder.Entity<Arrendamiento>()
            .HasOne(arrendamiento => arrendamiento.Agricultor)
            .WithMany(usuario => usuario.arrendamientos)
            .HasForeignKey(arrendamiento => arrendamiento.AgricultorId)
            .OnDelete(DeleteBehavior.ClientSetNull);
            
                
        modelbuilder.Entity<Arrendamiento>()
            .HasOne(arrendamiento => arrendamiento.Terreno)
            .WithMany(terreno => terreno.Arrendamientos)
            .HasForeignKey(arrendamiento => arrendamiento.TerrenoId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        modelbuilder.Entity<Arrendamiento>()
            .HasOne(arrendamiento => arrendamiento.TipoArrendamiento)
            .WithMany(tipo_arrendamiento => tipo_arrendamiento.Arrendamientos)
            .HasForeignKey(arrendamiento => arrendamiento.TipoArrendamientoId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        #endregion
        
        #region Relaciones Entidad -Proyecto-
        
        modelbuilder.Entity<Proyecto>()
            .HasOne(proyecto => proyecto.Inversionista)
            .WithMany(usuario => usuario.proyectos)
            .HasForeignKey(proyecto => proyecto.InversionistaId)
            .OnDelete(DeleteBehavior.ClientSetNull);
            
                
        modelbuilder.Entity<Proyecto>()
            .HasOne(proyecto => proyecto.Arrendamiento)
            .WithMany(arrendamiento => arrendamiento.Proyectos)
            .HasForeignKey(proyecto => proyecto.ArrendamientoId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        modelbuilder.Entity<Proyecto>()
            .HasOne(proyecto => proyecto.TipoCultivo)
            .WithMany(tipo_cultivo => tipo_cultivo.Proyectos)
            .HasForeignKey(proyecto => proyecto.TipoCultivoId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        #endregion
        
        #region Relaciones Entidad -Archivo-
        
        modelbuilder.Entity<Archivo>()
            .HasOne(archivo => archivo.TipoArchivo)
            .WithMany(tipo_archivo => tipo_archivo.Archivos)
            .HasForeignKey(archivo => archivo.TipoArchivoId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        #endregion



        modelbuilder.Entity<Usuario>()
            .HasMany(usuarios => usuarios.perfiles)
            .WithMany("usuarios")
            .UsingEntity(join => join.ToTable("UsuarioPerfil"));
        
        //Conversion a UTC debido a Postgresql
        modelbuilder.Entity<Usuario>()
            .Property(u => u.fecha_nacimiento)
            .HasConversion(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        
        var listaperfiles = new Perfil[]
        {
            new Perfil {Id= Guid.NewGuid().ToString(), NombrePerfil = "Propietario", DescripcionPerfil= "Propietario"},
            new Perfil {Id= Guid.NewGuid().ToString(), NombrePerfil = "Agricultor", DescripcionPerfil = "Agricultor"},
            new Perfil {Id= Guid.NewGuid().ToString(), NombrePerfil = "Inversionista", DescripcionPerfil = "Inversionista"},

        };
        modelbuilder.Entity<Perfil>().HasData(listaperfiles);

        base.OnModelCreating(modelbuilder);

    }
}