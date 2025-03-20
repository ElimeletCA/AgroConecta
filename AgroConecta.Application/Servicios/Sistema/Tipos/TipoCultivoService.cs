using AgroConecta.Application.Servicios.Interfaces.Sistema.Tipos;
using AgroConecta.Domain.Sistema.Tipos;
using AgroConecta.Infrastructure.Repositorios.Interfaces;
using AgroConecta.Shared.DTO.Tipos;
using AutoMapper;

namespace AgroConecta.Application.Servicios.Sistema.Tipos;

public class TipoCultivoService: BaseService<TipoCultivoDTO, TipoCultivo>, ITipoCultivoService
{
    public TipoCultivoService(IRepository<TipoCultivo> repository, IUnitOfWork unitOfWork, IMapper mapper)
        : base(repository, unitOfWork, mapper)
    {
    }
}