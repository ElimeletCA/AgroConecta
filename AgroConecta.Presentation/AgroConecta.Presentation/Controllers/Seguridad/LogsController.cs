using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Domain.Sistema.Seguridad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgroConecta.Presentation.Controllers.Seguridad;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class LogsController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IConfiguration _config;


        public LogsController(ILogService logservice, IConfiguration config )
        {
            _logService = logservice;
            _config = config;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllLogs()
        {
            var logs = await _logService.GetAllLogsAsync();
            return Ok(logs);
        }
        [HttpDelete("cleanup/{daysToKeep}")]
        public async Task<IActionResult> CleanupOldLogs(int daysToKeep)
        {
            try
            {
                await _logService.DeleteOldLogsAsync(daysToKeep);
                return Ok($"Logs anteriores a {daysToKeep} días eliminados");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("keep-recent/{count}")]
        public async Task<IActionResult> KeepRecentLogs(int count)
        {
            try
            {
                await _logService.KeepOnlyRecentLogsAsync(count);
                return Ok($"Se conservaron los {count} logs más recientes");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }