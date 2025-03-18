using System.Reflection;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using AgroConecta.Presentation.Client.Pages;
using AgroConecta.Presentation.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AgroConecta.Application.Seeds;
using AgroConecta.Application.Servicios;
using AgroConecta.Application.Servicios.Interfaces;
using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Application.Servicios.Interfaces.Sistema.Seguridad;
using AgroConecta.Application.Servicios.Seguridad;
using AgroConecta.Application.Servicios.Sistema.Seguridad;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Infrastructure.Repositorios;
using AgroConecta.Infrastructure.Repositorios.Data;
using AgroConecta.Infrastructure.Repositorios.Interfaces;
using AgroConecta.Presentation.Seguridad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddAuthorizationCore();//Agregado
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();//Agregado
builder.Services.AddControllers();//agregado
builder.Services.AddHttpClient();//Agregado
builder.Services.AddCascadingAuthenticationState();//Agregado


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));

#region Carga de servicios de lógica de negocio
var serviceAssembly = Assembly.Load("AgroConecta.Application");
var baseServiceType = typeof(IBaseService<,>);

// Busca todas las clases concretas que implementan IBaseService<,>
var serviceTypes = serviceAssembly.GetTypes()
    .Where(type => 
        type.IsClass && 
        !type.IsAbstract && 
        !type.IsGenericType
    )
    .Select(type => new
    {
        Implementation = type,
        Interfaces = type.GetInterfaces()
            .Where(i => 
                i.IsGenericType && 
                i.GetGenericTypeDefinition() == baseServiceType
            )
            .ToList()
    })
    .Where(t => t.Interfaces.Any())
    .ToList();

// Registra cada servicio encontrado
foreach (var service in serviceTypes)
{
    foreach (var serviceInterface in service.Interfaces)
    {
        // Registra la implementación bajo IBaseService<,>
        builder.Services.AddScoped(serviceInterface, service.Implementation);
        
        // También registra la implementación bajo su interfaz específica (ITerrenoService)
        var specificInterface = service.Implementation.GetInterfaces()
            .FirstOrDefault(i => !i.IsGenericType && i != serviceInterface);
        
        if (specificInterface != null)
        {
            builder.Services.AddScoped(specificInterface, service.Implementation);
        }
    }
}
#endregion


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseNpgsql(connectionString);
    }

);

builder.Services.AddIdentity<Usuario, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedEmail = true;
    options.Lockout.AllowedForNewUsers = false;

}).AddEntityFrameworkStores<AppDbContext>() 
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateActor = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            RequireExpirationTime=true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

    });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger("app");
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate(); // Aplica migraciones pendientes
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Ocurrió un error al aplicar las migraciones.");
    }
    try
    {
        logger.LogInformation("Comenzando seed de datos iniciales");

        var userManager = services.GetRequiredService<UserManager<Usuario>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await DefaultRoles.SembrarAsync(userManager, roleManager);
        await DefaultUsers.SembrarUsuarioAdministradorAsync(
            userManager, 
            roleManager, 
            builder.Configuration["DefaultUser:Email"],
            builder.Configuration["DefaultUser:Password"]);
        
        await DefaultUsers.SembrarUsuariosDummyAsync(userManager, 10);

        logger.LogInformation("Seed de datos iniciales terminado");
        logger.LogInformation("Iniciando Aplicacicon...");
    }
    catch (Exception ex)
    {
        logger.LogWarning(ex, "Error al enviar los datos seed a la DB");

    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseStatusCodePagesWithReExecute("/Error/{0}");
app.UseAntiforgery();

app.MapControllers();//agregado
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(AgroConecta.Presentation.Client._Imports).Assembly);

app.Run();