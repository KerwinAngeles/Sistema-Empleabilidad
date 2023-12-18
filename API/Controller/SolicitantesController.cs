using Capa_Datos.DTO;
using Capa_Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitantesController : ControllerBase
    {
        private readonly ISolicitante _solicitante;

        public SolicitantesController(ISolicitante solicitante)
        {
            _solicitante = solicitante;
        }

        [HttpPut("EditarSolicitante")]
        public IActionResult EditarSolicitante(SolicitanteDTO solicitanteDTO)
        {
            _solicitante.EditarSolicitante(solicitanteDTO);
            return Ok("Cuenta editada exitosamente");
        }

        [HttpDelete("EliminarSolicitante")]
        public IActionResult EliminarSolicitante(int Id)
        {
            _solicitante.EliminarSolicitante(Id);
            return Ok("Solicitante dado de baja exitosamente");
        }

        [HttpGet("ListarSolicitante")]
        public ActionResult<SolicitanteDTO> ListarSolicitantes()
        {
            var solicitantes = _solicitante.ListarSolicitantes();
            return Ok(solicitantes);
        }
    }
}
