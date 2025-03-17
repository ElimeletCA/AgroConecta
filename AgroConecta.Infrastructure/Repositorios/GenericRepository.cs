using AgroConecta.Domain.General;
using AgroConecta.Infrastructure.Repositorios.Data;

namespace AgroConecta.Infrastructure.Repositorios;

public class GenericRepository<T> : Repository<T> where T : BaseEntity
{
    public GenericRepository(AppDbContext context) : base(context)
    {
    }
}