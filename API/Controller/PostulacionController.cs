using Capa_Datos.DTO;
using Capa_Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostulacionController : ControllerBase
    {
        private readonly IPostulacion _postulacion;

        public PostulacionController(IPostulacion postulacion)
        {
            _postulacion = postulacion;
        }

        [HttpGet("ListarPostulaciones")]

        public IActionResult Get(int vacanteId)
        {
            var postulaciones = _postulacion.ObtenerPostulaciones(vacanteId);
            return Ok(postulaciones);
        }

        [HttpPost("BuscarPostulaciones")]
        public IActionResult BuscarPostulacion([FromBody] PostulacionesDTO postulacionesDTO)
        {
            var postulaciones = _postulacion.BuscarPostulaciones(postulacionesDTO);
            return Ok(postulaciones);
        }
    }
}
