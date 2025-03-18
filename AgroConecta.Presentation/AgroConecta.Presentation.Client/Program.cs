using System.Reflection;
using AgroConecta.Presentation.Client;
using AgroConecta.Presentation.Client.Agents;
using AgroConecta.Presentation.Client.Agents.Interfaces;
using AgroConecta.Presentation.Client.Agents.Interfaces.Seguridad;
using AgroConecta.Presentation.Client.Agents.Interfaces.Sistema.Seguridad;
using AgroConecta.Presentation.Client.Agents.Seguridad;
using AgroConecta.Presentation.Client.Agents.Sistema.Seguridad;
using AgroConecta.Presentation.Client.Helpers.Seguridad;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Identity;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddMudServices(config =>
{
 config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;

 config.SnackbarConfiguration.PreventDuplicates = false;
 config.SnackbarConfiguration.NewestOnTop = false;
 config.SnackbarConfiguration.ShowCloseIcon = true;
 config.SnackbarConfiguration.VisibleStateDuration = 5000;
 config.SnackbarConfiguration.HideTransitionDuration = 500;
 config.SnackbarConfiguration.ShowTransitionDuration = 500;
 config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

#region Carga de agents
 builder.Services.AddScoped(typeof(IBaseAgent), typeof(BaseAgent));
 builder.Services.AddScoped<ISeguridadAgent, SeguridadAgent>();
 builder.Services.AddScoped<IUsuarioAgent, UsuarioAgent>();

 var clientAssembly = typeof(Program).Assembly;  // Asumiendo que los agents están en el mismo ensamblado
 var baseAgentInterface  = typeof(IInitialAgent<>);

 var agentTypes = clientAssembly.GetTypes()
  .Where(t => t.IsClass && !t.IsAbstract && !t.IsGenericType)
  .Select(type => new {
   Implementation = type,
   Interfaces = type.GetInterfaces()
    .Where(i => i.IsGenericType && 
                i.GetGenericTypeDefinition() == baseAgentInterface)
    .ToList()
  })
  .Where(t => t.Interfaces.Any())
  .ToList();

 foreach (var agent in agentTypes)
 {
  // Registrar bajo la interfaz específica (ej: ITipoMedidaAreaAgent)
  var specificInterface = agent.Implementation.GetInterfaces()
   .FirstOrDefault(i => !i.IsGenericType && i != typeof(IBaseAgent));
    
  if (specificInterface != null)
  {
   builder.Services.AddScoped(specificInterface, agent.Implementation);
  }
  
 }
#endregion



await builder.Build().RunAsync();