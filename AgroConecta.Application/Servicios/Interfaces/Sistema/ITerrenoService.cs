using AgroConecta.Domain.Sistema;
using AgroConecta.Shared.DTO;

namespace AgroConecta.Application.Servicios.Interfaces.Sistema;

public interface ITerrenoService : IBaseService<TerrenoDTO, Terreno>
{
    // Puedes agregar métodos específicos para Terreno, por ejemplo:
    Task<IEnumerable<Terreno>> GetTerrenosByUbicacionAsync(string ubicacion);
}