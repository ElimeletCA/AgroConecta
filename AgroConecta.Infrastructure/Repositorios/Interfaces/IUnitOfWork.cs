using AgroConecta.Domain.General;

namespace AgroConecta.Infrastructure.Repositorios.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> GetRepository<T>() where T : BaseEntity;
    
    Task<int> CommitAsync();
}