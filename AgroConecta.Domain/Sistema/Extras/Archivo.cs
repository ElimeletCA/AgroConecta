using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroConecta.Domain.General;
using AgroConecta.Domain.Sistema.Tipos;

namespace AgroConecta.Domain.Sistema.Extras;

public class Archivo : BaseEntity
{

    public string TipoArchivoId { get; set; }
    
    public string EntidadId { get; set; }
    [MaxLength(250)]

    public string NombreArchivo { get; set; }
    [MaxLength(250)]
    public string NombreArchivoAlmacenado { get; set; }

    public DateTime FechaCreacion { get; set; }
    [MaxLength(250)]

    public string? Descripcion { get; set; }

    public string? TipoContenido { get; set; }

    public int Estado  { get; set; }
    
    public TipoArchivo TipoArchivo { get; set; }

}