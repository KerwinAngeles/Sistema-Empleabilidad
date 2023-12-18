using Capa_Datos;
using Capa_Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IData _data;
        public DataController(IData data)
        {
            _data = data;
        }

        [HttpGet("MostrarDatos")]
        public IActionResult MostrarDatos(string correo)
        {
           var datos = _data.Datos(correo);
            return Ok(datos);
        }
    }
}
