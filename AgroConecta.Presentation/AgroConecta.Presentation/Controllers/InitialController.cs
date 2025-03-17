using AgroConecta.Application.Servicios.Interfaces;
using AgroConecta.Domain.General;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Seguridad.Mensajes;
using Microsoft.AspNetCore.Mvc;

namespace AgroConecta.Presentation.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public abstract class InitialController<TDto, TEntity> : ControllerBase
        where TEntity : BaseEntity
        where TDto : BaseDTO
    {
        protected readonly IBaseService<TDto, TEntity> _service;

        public InitialController(IBaseService<TDto, TEntity> service)
        {
            _service = service;
        }

        // GET: api/[controller]
        [HttpGet]
        public virtual async Task<ActionResult<ApiResponse<IEnumerable<TDto>>>> GetAll()
        {
            var dtos = await _service.GetAllAsync();
            var response = new ApiResponse<IEnumerable<TDto>>
            {
                Success = true,
                Message = dtos
            };
            return Ok(response);
        }

        // GET: api/[controller]/{id}
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<ApiResponse<TDto>>> GetById([FromQuery]string id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
            {
                var notFoundResponse = new ApiResponse<string>
                {
                    Success = false,
                    Message = "Elemento no encontrado."
                };
                return NotFound(notFoundResponse);
            }

            var response = new ApiResponse<TDto>
            {
                Success = true,
                Message = dto
            };
            return Ok(response);
        }

        // POST: api/[controller]
        [HttpPost]
        public virtual async Task<IActionResult>  Create([FromBody] TDto dto)
        {
            await _service.AddAsync(dto);
            var response = new ApiResponse<TDto>
            {
                Success = true,
                Message = dto
            };
            return Ok(response);
        }

        // PUT: api/[controller]/{id}
        [HttpPut("{id}")]
        public virtual async Task<ActionResult<ApiResponse<TDto>>> Update(string id, [FromBody] TDto dto)
        {
            if (dto.Id != id)
            {
                var badRequestResponse = new ApiResponse<string>
                {
                    Success = false,
                    Message = "El ID del DTO no coincide con el ID de la ruta."
                };
                return BadRequest(badRequestResponse);
            }

            await _service.UpdateAsync(dto);
            var response = new ApiResponse<TDto>
            {
                Success = true,
                Message = dto
            };
            return Ok(response);
        }

        // DELETE (SoftDelete): api/[controller]/soft/{id}
        [HttpDelete("soft/{id}")]
        public virtual async Task<ActionResult<ApiResponse<string>>> SoftDelete(string id)
        {
            await _service.SoftDeleteAsync(id);
            var response = new ApiResponse<string>
            {
                Success = true,
                Message = "Elemento eliminado lógicamente."
            };
            return Ok(response);
        }

        // DELETE (HardDelete): api/[controller]/hard/{id}
        [HttpDelete("hard/{id}")]
        public virtual async Task<ActionResult<ApiResponse<string>>> HardDelete(string id)
        {
            await _service.HardDeleteAsync(id);
            var response = new ApiResponse<string>
            {
                Success = true,
                Message = "Elemento eliminado permanentemente."
            };
            return Ok(response);
        }
    }