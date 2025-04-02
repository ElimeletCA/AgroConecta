namespace AgroConecta.Shared.DTO.Seguridad;

public class AdministrarRolesUsuarioDTO
{
    public string UsuarioId { get; set; }
    public IList<RolUsuarioDTO> RolesUsuario { get; set; }
}