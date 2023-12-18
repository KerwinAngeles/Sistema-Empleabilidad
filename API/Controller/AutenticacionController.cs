using Capa_Datos.DTO;
using Capa_Servicios.Clases;
using Capa_Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly IAutenticacion _autenticacion;

        public AutenticacionController(IAutenticacion autenticacion)
        {
            _autenticacion = autenticacion;
        }

        [HttpPost("RegistrarUsuario")]
        public IActionResult Registro(UsuarioDTO usuarioDTO)
        {
            _autenticacion.RegistrarUsuarios(usuarioDTO);
            return Ok();  
        }

        [HttpPost("LoguearUsuario")]
        public IActionResult Login([FromBody]LoginDTO loginDTO)
        {
           var autenticado =  _autenticacion.Login(loginDTO);
            if(autenticado == true )
            {
                return Ok("Usuario logueado con exito");
            }
            else
            {
                return BadRequest("El usuario no existe");
            }
        }
    }
}
