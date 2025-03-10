using Microsoft.JSInterop;

namespace AgroConecta.Presentation.Client.Helpers.Seguridad
{
    public class TokenManager
    {
        private readonly IJSRuntime _jsRuntime;

        public TokenManager(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task SetTokenAsync(string token)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "tokenAuth", token);
        }

        public async Task<string> GetTokenAsync()
        {
            try
            {
                var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "tokenAuth");
                return token;
            }
            catch
            {
                return string.Empty;
            }
        }

        public async Task RemoveTokenAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "tokenAuth");
        }
    }
}