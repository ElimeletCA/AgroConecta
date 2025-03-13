using AgroConecta.Presentation.Client;
using AgroConecta.Presentation.Client.Helpers.Seguridad;
using AgroConecta.Presentation.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Identity;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });//AGREGADO
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();//Agregado

builder.Services.AddAuthorizationCore();//Agregado
builder.Services.AddCascadingAuthenticationState();//Agregado	
builder.Services.AddAgents();


await builder.Build().RunAsync();

//Codigo anterior
// var builder = WebAssemblyHostBuilder.CreateDefault(args);
// builder.Services.AddHttpClient<IInitialAgent, InitialAgent>(client =>
// {
//     client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
// });
// builder.Services.AddMudServices();
// builder.Services.AddAuthorizationCore();
// builder.Services.AddCascadingAuthenticationState();
// builder.Services.AddSingleton<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
// await builder.Build().RunAsync();