using System.ComponentModel.DataAnnotations.Schema;

namespace AgroConecta.Shared.Security;

public class UsuarioDTO
{
    public string nombre_completo { get; set; } = string.Empty;
    public DateTime fecha_nacimiento { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string pasword_without_hash { get; set; } = string.Empty;
    public int[]? perfiles_id { get; set; }
    public string two_factor_code { get; set; } = string.Empty;
    
    //Propiedades navigacionales

    // public ICollection<Terreno>? terrenos { get; set; }
    //
    // public ICollection<Arrendamiento>? arrendamientos { get; set; }
    //
    // public ICollection<Proyecto>? proyectos { get; set; }
    // public ICollection<Perfil>? perfiles { get; set; }
    

}