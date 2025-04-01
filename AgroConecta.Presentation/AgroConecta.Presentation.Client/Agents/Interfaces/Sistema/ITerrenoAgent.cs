using AgroConecta.Shared.DTO;
using AgroConecta.Shared.DTO.Tipos;

namespace AgroConecta.Presentation.Client.Agents.Interfaces.Sistema;

public interface ITerrenoAgent : IInitialAgent<TerrenoDTO>
{
   Task<bool> CambiarEstado(string id, int estado);
   Task<IEnumerable<TerrenoDTO>> ObtenerTerrenosPorEstadoAsync(int estado);
   Task<IEnumerable<TerrenoDTO>> ObtenerTerrenosDeUsuarioAsync(string usuarioId);

   Task<IEnumerable<TerrenoDTO>> ObtenerTerrenosDeUsuarioPorEstadoAsync(string usuarioId, int estado);

}