using AgroConecta.Application.Servicios.Interfaces.Sistema.General;
using AgroConecta.Domain.Sistema.General;
using AgroConecta.Infrastructure.Repositorios.Interfaces;
using AgroConecta.Shared.DTO;
using AutoMapper;

namespace AgroConecta.Application.Servicios.Sistema.General;

public class ProvinciaService: BaseService<ProvinciaDTO, Provincia>, IProvinciaService
{
    public ProvinciaService(IRepository<Provincia> repository, IUnitOfWork unitOfWork, IMapper mapper)
        : base(repository, unitOfWork, mapper)
    {
    }
}