using AgroConecta.Application.Servicios.Interfaces.Sistema.General;
using AgroConecta.Domain.Sistema.Extras;
using AgroConecta.Infrastructure.Repositorios.Interfaces;
using AgroConecta.Shared.DTO;
using AutoMapper;

namespace AgroConecta.Application.Servicios.Sistema.General;


public class ArchivoService: BaseService<ArchivoDTO, Archivo>, IArchivoService
{
    public ArchivoService(IRepository<Archivo> repository, IUnitOfWork unitOfWork, IMapper mapper)
        : base(repository, unitOfWork, mapper)
    {
    }
}