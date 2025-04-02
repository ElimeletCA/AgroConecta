using AgroConecta.Shared.DTO;
using AgroConecta.Shared.DTO.Seguridad;
using AgroConecta.Shared.Seguridad;
using AgroConecta.Shared.Seguridad.Mensajes;

namespace AgroConecta.Presentation.Client.Agents.Interfaces.Sistema.Seguridad;

public interface IUsuarioAgent: IBaseAgent
{
    Task<IEnumerable<UsuarioDTO>> GetAllExceptAsync(string email);
    Task<AdministrarRolesUsuarioDTO> GetAllRolesByIdAsync(string userId);
    Task<UsuarioDTO> GetByIdAsync(string userId);
    Task<bool> UpdateRolesById(string userId, AdministrarRolesUsuarioDTO model);
    Task<bool> DeleteAsync(string userId);
    Task<IEnumerable<RolDTO>> GetAllRolesAsync();
    Task<ApiResponse<bool>> AddRoleAsync(RolDTO rol);
    Task<bool> DeleteRoleAsync(string rolId);
    Task<PermisoDTO> GetAllPermisosByRolIdAsync(string rolId );
    Task<ApiResponse<bool>> UpdatePermisosAsync(PermisoDTO permisosRol);
}