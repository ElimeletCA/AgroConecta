using System.ComponentModel.DataAnnotations;
namespace AgroConecta.Domain.General;

public abstract class BaseEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedTimeUtc { get; set; }
    
    [ConcurrencyCheck]
    public DateTime LastUpdateUtc { get; set; }
}