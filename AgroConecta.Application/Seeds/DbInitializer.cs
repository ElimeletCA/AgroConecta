using AgroConecta.Domain.Sistema.Tipos;
using AgroConecta.Infrastructure.Repositorios.Data;

namespace AgroConecta.Application.Seeds;

public static class DbInitializer
{
    public static async Task Seed(AppDbContext context)
    {
        // Verificar y sembrar TipoArrendamiento
        if (!context.TipoArrendamientos.Any())
        {
            context.TipoArrendamientos.AddRange(
                new TipoArrendamiento { Id = Guid.NewGuid().ToString(), Descripcion = "Arrendamiento a 1 mes" },
                new TipoArrendamiento { Id = Guid.NewGuid().ToString(), Descripcion = "Arrendamiento a 3 meses" },
                new TipoArrendamiento { Id = Guid.NewGuid().ToString(), Descripcion = "Arrendamiento a 6 meses" },
                new TipoArrendamiento { Id = Guid.NewGuid().ToString(), Descripcion = "Arrendamiento a 1 año" },
                new TipoArrendamiento { Id = Guid.NewGuid().ToString(), Descripcion = "Arrendamiento a 2 años" }
            );
        }

        // Verificar y sembrar TipoCultivo
        if (!context.TipoCultivos.Any())
        {
            context.TipoCultivos.AddRange(
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de maíz" },
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de trigo" },
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de arroz" },
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de papa" },
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de soya" },
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de caña de azúcar" },
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de algodón" },
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de hortalizas" }
            );
        }

        // Verificar y sembrar TipoMedidaArea
        if (!context.TipoMedidaAreas.Any())
        {
            context.TipoMedidaAreas.AddRange(
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Hectárea" },
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Acre" },
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Decárea" },
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Tarea" },
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Are" },
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Metro cuadrado" },
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Kilómetro cuadrado" },
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Manzana" }
            );
        }

        // Verificar y sembrar TipoSuelo
        if (!context.TipoSuelos.Any())
        {
            context.TipoSuelos.AddRange(
                new TipoSuelo { Id = Guid.NewGuid().ToString(), Descripcion = "Arcilloso" },
                new TipoSuelo { Id = Guid.NewGuid().ToString(), Descripcion = "Arenoso" },
                new TipoSuelo { Id = Guid.NewGuid().ToString(), Descripcion = "Franco" },
                new TipoSuelo { Id = Guid.NewGuid().ToString(), Descripcion = "Limóseo" },
                new TipoSuelo { Id = Guid.NewGuid().ToString(), Descripcion = "Calcáreo" },
                new TipoSuelo { Id = Guid.NewGuid().ToString(), Descripcion = "Orgánico" },
                new TipoSuelo { Id = Guid.NewGuid().ToString(), Descripcion = "Pedregoso" }
            );
        }

        context.SaveChanges();
    }
}
