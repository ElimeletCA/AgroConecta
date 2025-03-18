using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroConecta.Domain.General;
using AgroConecta.Domain.Sistema.Tipos;

namespace AgroConecta.Domain.Sistema.Extras;

public class Archivo : BaseEntity
{

    public string TipoArchivoId { get; set; }
    
    public string ReferenciaId { get; set; }
    [MaxLength(250)]

    public required string NombreArchivo { get; set; }
    [MaxLength(250)]
    public required string UrlArchivo { get; set; }

    public DateTime FechaCreacion { get; set; }
    [MaxLength(250)]

    public required string Descripcion { get; set; }
    
    public string Formato { get; set; }

    public string Size { get; set; }
    
    public int Estado  { get; set; }
    
    public TipoArchivo TipoArchivo { get; set; }

}