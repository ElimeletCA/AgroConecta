using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Seguridad;

namespace AgroConecta.Application.Servicios.Interfaces.Sistema.Seguridad;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDTO>> GetAllExceptAsync(string email);
    Task<UsuarioDTO> GetByIdAsync(string id);
    Task<bool> DeleteAsync(string id);
    Task<IEnumerable<RolDTO>> GetAllRolesAsync();
    Task<bool> AddRoleAsync(string rolName);
    Task<bool> DeleteRoleAsync(string rolId);
    Task<PermisoDTO> GetALlPermisosByRolId(string rolId);
    Task<bool> UpdatePermisos(PermisoDTO permisosRol);
    
}