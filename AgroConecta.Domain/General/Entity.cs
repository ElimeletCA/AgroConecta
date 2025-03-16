namespace AgroConecta.Domain.General;

public abstract class Entity<TId>
{
    public TId Id { get; set; }
}