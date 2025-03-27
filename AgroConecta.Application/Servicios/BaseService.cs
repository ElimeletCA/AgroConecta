using AgroConecta.Application.Servicios.Interfaces;
using AgroConecta.Domain.General;
using AgroConecta.Infrastructure.Repositorios.Interfaces;
using AgroConecta.Shared.DTO;
using AutoMapper;

namespace AgroConecta.Application.Servicios;

public class BaseService<TDto, TEntity> : IBaseService<TDto, TEntity>
    where TEntity : BaseEntity
    where TDto : BaseDTO
{
    protected readonly IRepository<TEntity> _repository;
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    public BaseService(IRepository<TEntity> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(TDto dto)
    {
        // Mapear de DTO a entidad
        var entity = _mapper.Map<TEntity>(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<TDto>> GetAllAsync(params string[] includes)
    {
        var entities = await _repository.GetAllAsync(includes);
        // Mapear de entidad a DTO
        return _mapper.Map<IEnumerable<TDto>>(entities);
    }

    public async Task<TDto?> GetByIdAsync(string id, params string[] includes)
    {
        var entity = await _repository.GetByIdAsync(id, includes);
        return entity is null ? null : _mapper.Map<TDto>(entity);
    }

    public async Task UpdateAsync(TDto dto)
    {
        // Primero obtenemos la entidad actual para luego mapear los cambios
        var entity = await _repository.GetByIdAsync(dto.Id);
        if (entity is null)
            return;

        // Mapear el DTO sobre la entidad existente
        _mapper.Map(dto, entity);
        _repository.Update(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task SoftDeleteAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return;

        await _repository.SoftDeleteAsync(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task HardDeleteAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return;

        await _repository.HardDeleteAsync(entity);
        await _unitOfWork.CommitAsync();
    }
}