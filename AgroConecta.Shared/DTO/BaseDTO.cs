namespace AgroConecta.Shared.DTO;

public abstract class BaseDTO
{
    public string Id { get; set; }

    public bool IsViewMode { get; set; }
    
    public bool IsDeleted { get; set; }
    public DateTime? DeletedTimeUtc { get; set; }
    
    public DateTime LastUpdateUtc { get; set; }
}