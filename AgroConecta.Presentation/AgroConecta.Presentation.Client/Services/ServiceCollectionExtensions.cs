using AgroConecta.Presentation.Client.Agents.Interfaces;

namespace AgroConecta.Presentation.Client.Services;

public static class ServiceCollectionExtensions
{
    public static void AddAgents(this IServiceCollection services)
    {
        var agentInterfaceType = typeof(IBaseAgent<>);
        var agentTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsClass && !type.IsAbstract && agentInterfaceType.IsAssignableFrom(type));

        foreach (var implementationType in agentTypes)
        {
            var interfaceType = implementationType.GetInterfaces().FirstOrDefault(i => i != agentInterfaceType && agentInterfaceType.IsAssignableFrom(i));
            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, implementationType);
            }
        }
    }
}
