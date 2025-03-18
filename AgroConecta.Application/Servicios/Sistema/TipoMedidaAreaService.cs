using AgroConecta.Application.Servicios.Interfaces.Sistema;
using AgroConecta.Domain.Sistema;
using AgroConecta.Domain.Sistema.Tipos;
using AgroConecta.Infrastructure.Repositorios.Interfaces;
using AgroConecta.Shared.DTO;
using AutoMapper;

namespace AgroConecta.Application.Servicios.Sistema;

public class TipoMedidaAreaService: BaseService<TipoMedidaAreaDTO, TipoMedidaArea>, ITipoMedidaAreaService
{
    public TipoMedidaAreaService(IRepository<TipoMedidaArea> repository, IUnitOfWork unitOfWork, IMapper mapper)
        : base(repository, unitOfWork, mapper)
    {
    }
}