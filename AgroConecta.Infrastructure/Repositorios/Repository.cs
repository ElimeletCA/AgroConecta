using AgroConecta.Domain.General;
using AgroConecta.Infrastructure.Repositorios.Data;
using AgroConecta.Infrastructure.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AgroConecta.Infrastructure.Repositorios;

public abstract class Repository<T> : IRepository<T>
    where T : BaseEntity
{
    private readonly AppDbContext _context;
    protected DbSet<T> Entities => _context.Set<T>();

    protected Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<T?> GetByIdAsync(string id, params string[] includes)
    {
        IQueryable<T> query = Entities.Where(e => e.Id == id && !e.IsDeleted);

        if (includes != null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.FirstOrDefaultAsync();
        //return await Entities.FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
    }

    public async Task<IEnumerable<T>> GetAllAsync(params string[] includes)
    {
        
        IQueryable<T> query = Entities.Where(e => !e.IsDeleted);
        
        if (includes != null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        // Retornar todas las entidades que no estén marcadas como eliminadas (soft delete)
        //return await Entities.Where(e => !e.IsDeleted).ToListAsync();
        return await query.ToListAsync();

    }

    public async Task AddAsync(T entity)
    {
        // Agregar la entidad al DbSet de EF Core
        await Entities.AddAsync(entity);
    }

    public void Update(T entity)
    {
        // Marcar la entidad como modificada para que EF Core la actualice en el SaveChanges
        entity.LastUpdateUtc = DateTime.UtcNow;
        Entities.Update(entity);
        
    }

    public async Task SoftDeleteAsync(T entity)
    {
        // Marcar la entidad como eliminada lógicamente
        entity.IsDeleted = true;
        entity.LastUpdateUtc = DateTime.UtcNow;
        // Actualizar la entidad en el contexto
        Entities.Update(entity);
        await Task.CompletedTask;
    }

    public async Task HardDeleteAsync(T entity)
    {
        // Remover la entidad de forma permanente
        Entities.Remove(entity);
        await Task.CompletedTask;
    }
}