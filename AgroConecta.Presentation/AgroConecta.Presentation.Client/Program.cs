using AgroConecta.Presentation.Client;
using AgroConecta.Presentation.Client.Agents;
using AgroConecta.Presentation.Client.Agents.Interfaces;
using AgroConecta.Presentation.Client.Agents.Interfaces.Seguridad;
using AgroConecta.Presentation.Client.Agents.Seguridad;
using AgroConecta.Presentation.Client.Helpers.Seguridad;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Identity;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped(typeof(IBaseAgent<>), typeof(BaseAgent<>));
builder.Services.AddScoped<ISeguridadAgent, SeguridadAgent>();

await builder.Build().RunAsync();