using AgroConecta.Presentation.Client.Agents.Interfaces.Sistema;
using AgroConecta.Presentation.Client.Agents.Interfaces.Sistema.Tipos;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.DTO.Tipos;
using AgroConecta.Shared.Estados;
using Microsoft.JSInterop;

namespace AgroConecta.Presentation.Client.Agents.Sistema;

public class TerrenoAgent : InitialAgent<TerrenoDTO>, ITerrenoAgent
{
    public TerrenoAgent(HttpClient httpClient, IJSRuntime jsRuntime) 
        : base(httpClient, "api/Terrenos", jsRuntime) // Ruta del controlador
    {
    }

    public new async Task<IEnumerable<TerrenoDTO>> GetAllAsync(string[] includes = null)
    {
        var terrenos = await base.GetAllAsync(includes);
        // Aquí puedes agregar lógica adicional específica para TerrenoDTO si es necesario
        return terrenos;
    }
    public async Task<IEnumerable<TerrenoDTO>> ObtenerTerrenosDeUsuarioAsync(string usuarioId)
    {
        var terrenos = await base.GetAllAsync(new[]
        {
            "Municipio", "Municipio.Provincia",
            "TipoMedidaArea",
            "TipoSuelo",
            "Propietario"
                
                
        }); 
        var terrenosResultado = terrenos
            .Where(x => x.PropietarioId == usuarioId);
        
        return terrenosResultado;
        
    }

    public async Task<IEnumerable<TerrenoDTO>> ObtenerTerrenosPorEstadoAsync(int estado)
    {
        var terrenos = await base.GetAllAsync(new[]
        {
            "Municipio", "Municipio.Provincia",
            "TipoMedidaArea",
            "TipoSuelo",
            "Propietario"
                
                
        }); 
        var terrenosResultado = terrenos.Where(x => x.Estado == estado);
        
        return terrenosResultado;
        
    }
    public async Task<IEnumerable<TerrenoDTO>> ObtenerTerrenosDeUsuarioPorEstadoAsync(string usuarioId, int estado)
    {
        var terrenos = await base.GetAllAsync(new[]
        {
            "Municipio", "Municipio.Provincia",
            "TipoMedidaArea",
            "TipoSuelo",
            "Propietario"
                
                
        }); 
        var terrenosResultado = terrenos
            .Where(x => x.Estado == estado 
                        && x.PropietarioId == usuarioId);
        
        return terrenosResultado;
        
    }
    public new async Task<TerrenoDTO> GetByIdAsync(string id, string[] includes = null)
    {
        var terreno = await base.GetByIdAsync(id, includes);
        // Aquí puedes agregar lógica adicional específica para TerrenoDTO si es necesario
        return terreno ?? new TerrenoDTO();
    }
    public  async Task<bool> CambiarEstado(string id, int estado)
    {
        var terreno = await base.GetByIdAsync(id, new[] { "Municipio", "Municipio.Provincia" });
        if (terreno != null)
        {
            terreno.Estado = estado;
            await base.UpdateAsync(id, terreno);
            return true;

        }
        return false;

    }
}