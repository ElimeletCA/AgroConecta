using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace AgroConecta.Presentation.Client.Helpers.Seguridad
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly TokenManager _tokenManager;
        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
            _tokenManager = new TokenManager(jsRuntime);
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await _tokenManager.GetTokenAsync();
            var identity = new ClaimsIdentity();

            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    var claims = ParseClaimsFromJwt(token);
                    identity = new ClaimsIdentity(claims, "jwt");
                }
                catch (Exception ex)
                {
                    // Manejo de error: token inválido o mal formado
                    Console.WriteLine($"Error al parsear el JWT: {ex.Message}");
                    // Opcional: remover token almacenado o registrar el error
                }
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            // Notificar el cambio de estado solo si realmente hay un cambio,
            // de lo contrario se puede llamar a NotifyAuthenticationStateChanged en el lugar donde se actualice el token.
            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            // Separamos el token y obtenemos el payload (la parte central)
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);

            // Usamos JsonElement para poder detectar arrays
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonBytes);
            var claims = new List<Claim>();

            foreach (var kvp in keyValuePairs)
            {
                // Si el valor es un array, iteramos cada elemento y lo agregamos como claim individual
                if (kvp.Value.ValueKind == JsonValueKind.Array)
                {
                    foreach (var item in kvp.Value.EnumerateArray())
                    {
                        claims.Add(new Claim(kvp.Key, item.ToString()));
                    }
                }
                else
                {
                    claims.Add(new Claim(kvp.Key, kvp.Value.ToString()));
                }
            }
            return claims;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            // Aseguramos que la cadena Base64 tenga el padding correcto
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
