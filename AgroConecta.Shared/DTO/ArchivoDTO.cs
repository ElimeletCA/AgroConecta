namespace AgroConecta.Shared.DTO;

public class ArchivoDTO : BaseDTO
{
    public string TipoArchivoId { get; set; }
    
    public string EntidadId { get; set; }

    public string NombreArchivo { get; set; }
    
    public string NombreArchivoAlmacenado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? Descripcion { get; set; }

    public string? TipoContenido { get; set; }

    public int Estado  { get; set; }
    
}