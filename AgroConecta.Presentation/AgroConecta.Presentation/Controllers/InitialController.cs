using System.Security.Claims;
using AgroConecta.Application.Servicios.Interfaces;
using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Domain.General;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Extensions;
using AgroConecta.Shared.Seguridad.Mensajes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AgroConecta.Presentation.Controllers;

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public abstract class InitialController<TDto, TEntity> : ControllerBase
        where TEntity : BaseEntity
        where TDto : BaseDTO
    {
        protected readonly IBaseService<TDto, TEntity> _service;
        private readonly ILogService _logger;
        protected ClaimsPrincipal? CurrentUser => _actionContextAccessor.ActionContext?.HttpContext.User;
        private readonly IActionContextAccessor _actionContextAccessor;

        // Propiedad para obtener el ControllerContext correctamente
        protected ControllerContext ControllerContext => 
            _actionContextAccessor.ActionContext as ControllerContext 
            ?? throw new InvalidOperationException("ControllerContext no disponible");

        // Método para obtener el nombre completo de la acción
        protected string GetFullActionName()
        {
            var routeData = ControllerContext.RouteData;
            var controllerName = routeData.Values["controller"]?.ToString();
            var actionName = routeData.Values["action"]?.ToString();
            return $"{controllerName}/{actionName}";
        }
        public InitialController(IBaseService<TDto, TEntity> service, ILogService logger, IActionContextAccessor actionContextAccessor)
        {
            _service = service;
            _logger = logger;
            _actionContextAccessor = actionContextAccessor;
        }

        // GET: api/[controller]?includes=Entity&includes=Entity.SecondEntity
        [HttpGet]
        public virtual async Task<IActionResult>  GetAll([FromQuery] string[] includes)
        {
            var fullActionName = GetFullActionName();
            try
            {
                var dtos = await _service.GetAllAsync(includes);
                var response = new ApiResponse<IEnumerable<TDto>>
                {
                    Success = true,
                    Message = dtos
                };
                //Registro de información
                await _logger.LogInformation(
                    action: fullActionName,
                    message: $"Tipo: {typeof(TDto).Name}, Consulta: Obtenidos {dtos.Count()} registros",
                    userEmail: GetCurrentUserEmail(),
                    parameters: null
                );
                
                return Ok(response);

            }
            catch (Exception ex)
            {
                //Registro de error
                await _logger.LogError(
                    action: fullActionName,
                    ex: new Exception($"Excepción al obtener todos los registros-{ex.Message.Truncate(250)}", new Exception(ex.StackTrace?.Truncate(250))),
                    userEmail: GetCurrentUserEmail()
                );
                var responseFailed = new ApiResponse<string>
                {
                    Success = false,
                    Message = "Error interno del servidor. Consulte los logs para más detalles."
                };
                return StatusCode(500, responseFailed);

            }
        }

        // GET: api/[controller]/{id}?includes=Entity&includes=Entity.SecondEntity
        [HttpGet("{id}")]
        public virtual async  Task<IActionResult> GetById(string id, [FromQuery] string[] includes)
        {
            var fullActionName = GetFullActionName();
            try
            {
                var dto = await _service.GetByIdAsync(id, includes);
                if (dto == null)
                {
                    var notFoundResponse = new ApiResponse<string>
                    {
                        Success = false,
                        Message = "Elemento no encontrado."
                    };
                    //Registro de información
                    await _logger.LogWarning(
                        action: fullActionName,
                        message: $"Tipo: {typeof(TDto).Name}, Consulta: Obtener datos por id {id}, no encontrado",
                        userEmail: GetCurrentUserEmail()
                    );
                    return NotFound(notFoundResponse);
                }

                var response = new ApiResponse<TDto>
                {
                    Success = true,
                    Message = dto
                };
                //Registro de información
                await _logger.LogInformation(
                    action: fullActionName,
                    message: $"Tipo: {typeof(TDto).Name}, Consulta: Obtener datos por id {id}",
                    userEmail: GetCurrentUserEmail(),
                    parameters: dto
                );
                return Ok(response);
            }
            catch (Exception ex)
            {
                //Registro de error
                await _logger.LogError(
                    action: fullActionName,
                    ex: new Exception($"Tipo: {typeof(TDto).Name}, Excepción al obtener datos por id {id}-{ex.Message.Truncate(250)}", new Exception(ex.StackTrace?.Truncate(250))),
                    userEmail: GetCurrentUserEmail()
                );
                var responseFailed = new ApiResponse<string>
                {
                    Success = false,
                    Message = "Error interno del servidor. Consulte los logs para más detalles."
                };
                return StatusCode(500, responseFailed);
            }
        }

        // POST: api/[controller]
        [HttpPost]
        public virtual async Task<IActionResult>  Create([FromBody] TDto dto)
        {
            var fullActionName = GetFullActionName();

            try
            {
                await _service.AddAsync(dto);
                var response = new ApiResponse<TDto>
                {
                    Success = true,
                    Message = dto
                };
                //Registro de información
                await _logger.LogInformation(
                    action: fullActionName,
                    message: $"Tipo: {typeof(TDto).Name}, Éxito al agregar registro",
                    userEmail: GetCurrentUserEmail(),
                    parameters: dto
                );
                return Ok(response);
            }
            catch (Exception ex)
            {
                //Registro de error
                await _logger.LogError(
                    action: fullActionName,
                    ex: new Exception($"Tipo: {typeof(TDto).Name}, Excepción al agregar registro-{ex.Message.Truncate(250)}", new Exception(ex.StackTrace?.Truncate(250))),
                    parameters: dto, 
                    userEmail: GetCurrentUserEmail()
                );
                var responseFailed = new ApiResponse<string>
                {
                    Success = false,
                    Message = "Error interno del servidor. Consulte los logs para más detalles."
                };
                return StatusCode(500, responseFailed);
            }
        }

        // PUT: api/[controller]/{id}
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(string id, [FromBody] TDto dto)
        {
            var fullActionName = GetFullActionName();

            try
            {
                if (dto.Id != id)
                {
                    var badRequestResponse = new ApiResponse<string>
                    {
                        Success = false,
                        Message = "El ID del DTO no coincide con el ID de la ruta."
                    };
                    //Registro de información
                    await _logger.LogWarning(
                        action: fullActionName,
                        message: $"Tipo: {typeof(TDto).Name},Error al actualizar, el ID del DTO no coincide con el ID de la query.",
                        userEmail: GetCurrentUserEmail(),
                        parameters: dto
                    );
                    return BadRequest(badRequestResponse);
                }

                await _service.UpdateAsync(dto);
                var response = new ApiResponse<TDto>
                {
                    Success = true,
                    Message = dto
                };
                //Registro de información
                await _logger.LogInformation(
                    action: fullActionName,
                    message: $"Tipo: {typeof(TDto).Name}, Éxito al actualizar registro",
                    userEmail: GetCurrentUserEmail(),
                    parameters: dto
                );
                return Ok(response);
            }
            catch (Exception ex)
            {
                //Registro de error
                await _logger.LogError(
                    action: fullActionName,
                    ex: new Exception($"Tipo: {typeof(TDto).Name}, Excepción al actualizar registro-{ex.Message.Truncate(250)}", new Exception(ex.StackTrace?.Truncate(250))),
                    parameters: dto, 
                    userEmail: GetCurrentUserEmail()
                );
                var responseFailed = new ApiResponse<string>
                {
                    Success = false,
                    Message = "Error interno del servidor. Consulte los logs para más detalles."
                };
                return StatusCode(500, responseFailed);
            }
        }

        // DELETE (SoftDelete): api/[controller]/soft/{id}
        [HttpDelete("soft/{id}")]
        public virtual async Task<IActionResult>  SoftDelete(string id)
        {
            var fullActionName = GetFullActionName();
            try
            {
                await _service.SoftDeleteAsync(id);
                var response = new ApiResponse<string>
                {
                    Success = true,
                    Message = "Elemento eliminado"
                };
                //Registro de información
                await _logger.LogInformation(
                    action: fullActionName,
                    message: $"Tipo: {typeof(TDto).Name}, Éxito al eliminar lógicamente el registro, Id: {id}",
                    userEmail: GetCurrentUserEmail()
                );
                return Ok(response);
            }
            catch (Exception ex)
            {
                //Registro de error
                await _logger.LogError(
                    action: fullActionName,
                    ex: new Exception($"Tipo: {typeof(TDto).Name}, Excepción al eliminar lógicamente un registro , Id: {id}-{ex.Message.Truncate(250)}", new Exception(ex.StackTrace?.Truncate(250))),
                    userEmail: GetCurrentUserEmail()
                );
                var responseFailed = new ApiResponse<string>
                {
                    Success = false,
                    Message = "Error interno del servidor. Consulte los logs para más detalles."
                };
                return StatusCode(500, responseFailed);
            }
        }

        // DELETE (HardDelete): api/[controller]/hard/{id}
        [HttpDelete("hard/{id}")]
        public virtual async Task<IActionResult>  HardDelete(string id)
        {
            var fullActionName = GetFullActionName();
            try
            {
                await _service.HardDeleteAsync(id);
                var response = new ApiResponse<string>
                {
                    Success = true,
                    Message = "Elemento eliminado"
                };
                //Registro de información
                await _logger.LogInformation(
                    action: fullActionName,
                    message: $"Tipo: {typeof(TDto).Name}, Éxito al eliminar hard el registro, Id: {id}",
                    userEmail: GetCurrentUserEmail()
                );
                return Ok(response);
            }
            catch (Exception ex)
            {
                //Registro de error
                await _logger.LogError(
                    action: fullActionName,
                    ex: new Exception($"Tipo: {typeof(TDto).Name}, Excepción al eliminar hard un registro , Id: {id}-{ex.Message.Truncate(250)}", new Exception(ex.StackTrace?.Truncate(250))),
                    userEmail: GetCurrentUserEmail()
                );
                var responseFailed = new ApiResponse<string>
                {
                    Success = false,
                    Message = "Error interno del servidor. Consulte los logs para más detalles."
                };
                return StatusCode(500, responseFailed);
            }
        }
        // Método para obtener el UserId desde las claims
        protected string GetCurrentUserId()
        {
            return CurrentUser?.FindFirstValue(ClaimTypes.NameIdentifier) 
                   ?? CurrentUser?.FindFirstValue("sub") 
                   ?? "anonymous";
        }

        // Método para obtener datos adicionales del usuario
        protected string GetCurrentUserEmail()
        {
            return CurrentUser?.FindFirstValue(ClaimTypes.Email) 
                   ?? CurrentUser?.FindFirstValue("email") 
                   ?? "no-email";
        }
    }