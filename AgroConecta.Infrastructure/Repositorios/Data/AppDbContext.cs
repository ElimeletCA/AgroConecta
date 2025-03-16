using System.Diagnostics;
using AgroConecta.Domain.Sistema;
using AgroConecta.Domain.Sistema.Extras;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Domain.Sistema.Tipos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
namespace AgroConecta.Infrastructure.Repositorio.Data;

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
                   .HasOne(terreno => terreno.propietario)
                   .WithMany(usuario => usuario.terrenos)
                   .HasForeignKey(terreno => terreno.propietario_id)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            
            
            modelbuilder.Entity<Terreno>()
                .HasOne(terreno => terreno.tipo_medida_area)
                .WithMany(tipo_medida_area => tipo_medida_area.terrenos)
                .HasForeignKey(terreno => terreno.tipo_medida_area_id)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelbuilder.Entity<Terreno>()
                .HasOne(terreno => terreno.tipo_suelo)
                .WithMany(tipo_suelo => tipo_suelo.terrenos)
                .HasForeignKey(terreno => terreno.tipo_suelo_id)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
        #endregion
        
        #region Relaciones Entidad -Arrendamiento-
        
        modelbuilder.Entity<Arrendamiento>()
            .HasOne(arrendamiento => arrendamiento.agricultor)
            .WithMany(usuario => usuario.arrendamientos)
            .HasForeignKey(arrendamiento => arrendamiento.agricultor_id)
            .OnDelete(DeleteBehavior.ClientSetNull);
            
                
        modelbuilder.Entity<Arrendamiento>()
            .HasOne(arrendamiento => arrendamiento.terreno)
            .WithMany(terreno => terreno.arrendamientos)
            .HasForeignKey(arrendamiento => arrendamiento.terreno_id)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        modelbuilder.Entity<Arrendamiento>()
            .HasOne(arrendamiento => arrendamiento.tipo_arrendamiento)
            .WithMany(tipo_arrendamiento => tipo_arrendamiento.arrendamientos)
            .HasForeignKey(arrendamiento => arrendamiento.tipo_arrendamiento_id)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        #endregion
        
        #region Relaciones Entidad -Proyecto-
        
        modelbuilder.Entity<Proyecto>()
            .HasOne(proyecto => proyecto.inversionista)
            .WithMany(usuario => usuario.proyectos)
            .HasForeignKey(proyecto => proyecto.inversionista_id)
            .OnDelete(DeleteBehavior.ClientSetNull);
            
                
        modelbuilder.Entity<Proyecto>()
            .HasOne(proyecto => proyecto.arrendamiento)
            .WithMany(arrendamiento => arrendamiento.proyectos)
            .HasForeignKey(proyecto => proyecto.arrendamiento_id)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        modelbuilder.Entity<Proyecto>()
            .HasOne(proyecto => proyecto.tipo_cultivo)
            .WithMany(tipo_cultivo => tipo_cultivo.proyectos)
            .HasForeignKey(proyecto => proyecto.tipo_cultivo_id)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        #endregion
        
        #region Relaciones Entidad -Archivo-
        
        modelbuilder.Entity<Archivo>()
            .HasOne(archivo => archivo.tipo_archivo)
            .WithMany(tipo_archivo => tipo_archivo.archivos)
            .HasForeignKey(archivo => archivo.tipo_archivo_id)
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
            new Perfil {id= 1, nombre_perfil = "Propietario", descripcion_perfil= "Propietario"},
            new Perfil {id= 2, nombre_perfil = "Agricultor", descripcion_perfil = "Agricultor"},
            new Perfil {id= 3, nombre_perfil = "Inversionista", descripcion_perfil = "Inversionista"},

        };
        modelbuilder.Entity<Perfil>().HasData(listaperfiles);

        base.OnModelCreating(modelbuilder);

    }
}