using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AgroConecta.Domain.System.Seguridad;
using AgroConecta.Infrastructure.Repositorio.Data;
using AgroConecta.Shared.Security;

namespace AgroConecta.Presentation.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        /*public UsuarioController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet("ConexionServidor"),Authorize(Roles ="Usuario")]
        public async Task<ActionResult<string>> GetEjemplo()
        {
            return "Autorizado para usar endpoint";
        }




        [HttpGet("Datos")]
        public async Task<ActionResult<List<Usuario>>> GetCuenta()
        {
            var lista = await _context.Usuarios.ToListAsync();
            return Ok(lista);
        }

        public static Usuario usuario = new Usuario();
        [HttpPost("Registrar")]
        public async Task<ActionResult<string>> CreateCuenta(UsuarioDTO objeto)
        {
            try
            {
                CreatePasswordHash(objeto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                usuario.Username = objeto.Username;
                usuario.Email = objeto.Email;
                usuario.PasswordHash = passwordHash;
                usuario.PasswordSalt = passwordSalt;

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                var respuesta = "Registrado Con Exito";

                return respuesta;
            }
            catch (Exception ex)
            {
                return BadRequest("Error durante el registro");
            }

        }
        [HttpPost("Login")]
        public async Task<ActionResult<string>> InicioSesion(UsuarioDTO objeto)
        {
            var cuanta = await _context.Usuarios.Where(x => x.Email == objeto.Email).FirstOrDefaultAsync();
            if (cuanta == null)
            {
                return BadRequest("Usuario no encontrado");
            }
            if (!VerifyPasswordHash(objeto.Password, cuanta.PasswordHash, cuanta.PasswordSalt))
            {
                return BadRequest("Contraseña incorrecta");
            }
            string token = CreateToken(cuanta);
            return Ok(token);

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }


        private string CreateToken(Usuario user)
        {
            List<Claim> claims = new List<Claim>
     {
         new Claim(ClaimTypes.Name, user.Email),
         new Claim(ClaimTypes.Role,user.Rol)
     };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                "4u4LqxA2IaMZQs9c9AP77fMdcV3YxzVm8EUcqvaw5VR7JA4ZcwrDGITVPajPvfRa"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }*/



    }