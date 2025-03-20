using AgroConecta.Application.Servicios.Interfaces.Sistema.General;
using AgroConecta.Domain.Sistema.General;
using AgroConecta.Infrastructure.Repositorios.Interfaces;
using AgroConecta.Shared.DTO;
using AutoMapper;

namespace AgroConecta.Application.Servicios.Sistema.General;

public class MunicipioService: BaseService<MunicipioDTO, Municipio>, IMunicipioService
{
    public MunicipioService(IRepository<Municipio> repository, IUnitOfWork unitOfWork, IMapper mapper)
        : base(repository, unitOfWork, mapper)
    {
    }
}