using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Seguridad;

namespace AgroConecta.Presentation.Client.Agents.Interfaces.Sistema.Seguridad;

public interface IUsuarioAgent: IBaseAgent
{
    Task<IEnumerable<UsuarioDTO>> GetAllExceptAsync(string email);
    Task<AdministrarRolesUsuarioDTO> GetAllRolesByIdAsync(string userId);
    Task<UsuarioDTO> GetByIdAsync(string userId);
    Task<bool> UpdateRolesById(string userId, AdministrarRolesUsuarioDTO model);
    Task<bool> DeleteAsync(string userId);

}