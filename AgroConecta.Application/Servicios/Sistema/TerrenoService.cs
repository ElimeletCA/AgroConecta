using AgroConecta.Application.Servicios.Interfaces.Sistema;
using AgroConecta.Domain.Sistema;
using AgroConecta.Infrastructure.Repositorios.Interfaces;
using AgroConecta.Shared.DTO;
using AutoMapper;

namespace AgroConecta.Application.Servicios.Sistema;

public class TerrenoService : BaseService<TerrenoDTO, Terreno>, ITerrenoService
{
    // Se inyectan el repositorio y el Unit of Work en el constructor.
    public TerrenoService(IRepository<Terreno> repository, IUnitOfWork unitOfWork, IMapper mapper)
        : base(repository, unitOfWork, mapper)
    {
    }

    public Task<IEnumerable<Terreno>> GetTerrenosByUbicacionAsync(string ubicacion)
    {
        throw new NotImplementedException();
    }
}