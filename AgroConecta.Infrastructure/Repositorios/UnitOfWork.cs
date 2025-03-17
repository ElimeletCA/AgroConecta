using AgroConecta.Domain.General;
using AgroConecta.Infrastructure.Repositorios.Data;
using AgroConecta.Infrastructure.Repositorios.Interfaces;

namespace AgroConecta.Infrastructure.Repositorios;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly Dictionary<Type, object> _repositories;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    public IRepository<T> GetRepository<T>() where T : BaseEntity
    {
        if (_repositories.ContainsKey(typeof(T)))
            return (IRepository<T>)_repositories[typeof(T)];

        // Ahora se utiliza la clase concreta que tiene un constructor público.
        var repository = new GenericRepository<T>(_context);
        _repositories.Add(typeof(T), repository);
        return repository;
    }


    public async Task<int> CommitAsync()
    {
        // Guarda los cambios realizados en el contexto de EF Core
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        // Libera el contexto y otros recursos
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
