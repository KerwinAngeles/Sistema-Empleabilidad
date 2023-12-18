using Capa_Datos.DTO;
using Capa_Servicios.Clases;
using Capa_Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacanteController : ControllerBase
    {
        public readonly IVacante _vacante;
        public readonly IContratarSolicitante _contratarSolicitante;

        public VacanteController(IVacante vacante, IContratarSolicitante contratarSolicitante)
        {
            _vacante = vacante;
            _contratarSolicitante = contratarSolicitante;
        }

        [HttpPost("PublicarVacante")]
        public IActionResult PublicarVacante([FromBody] VacanteDTO vacanteDTO)
        {
            _vacante.CrearVacante(vacanteDTO);
            return Ok("Vacante creada con exito.");
        }

        [HttpPut("EditarVacante")]
        public IActionResult EditarVacante([FromBody ]VacanteDTO vacanteDTO)
        {
            _vacante.EditarVacante(vacanteDTO);
            return Ok("Vacante editada con exito.");
        }

        [HttpDelete("EliminarVacante")]
        public IActionResult EliminarVacante(int id)
        {
            _vacante.EliminarVacante(id);
            return Ok("Vacante eliminada con exito.");
        }

        [HttpGet("BuscarVacante")]
        public IActionResult BuscarVacante(int id)
        {
            var buscar = _vacante.BuscarVacante(id);
            return Ok(buscar);
        }

        [HttpGet("ListarVacanteEmpresa")]
        public ActionResult<VacanteDTO> ObtenerVacantes(string correo)
        {
            var vacantes = _vacante.ListarVacante(correo);
            return Ok(vacantes);
        }

        [HttpGet ("Listar")]
        public IActionResult GetAllVacantes()
        {
            var vacantes = _vacante.Listar();
            return Ok(vacantes);
        }

        [HttpPost("AplicarVacante")]
        public IActionResult AplicarVacante([FromForm]PostulacionesDTO postulacionesDTO, IFormFile file)
        {
            _vacante.AplicarVacante(postulacionesDTO, file);
            return Ok("Aplicaste a una vacante.");
        }

        [HttpGet("VacantesPostulada")]
        public IActionResult ObtenerVacantesConPostulaciones(int id)
        {
            var vacantesConPostulaciones = _vacante.vacantePostulacionesDTO(id);
            return Ok(vacantesConPostulaciones);
        }

        [HttpGet("VacantesPublicada")]
        public IActionResult VacantesPublicadas(int empresaId)
        {
            var vacantesPublicadas = _vacante.vacantePublicadasDTO(empresaId);
            return Ok(vacantesPublicadas);
        }

        [HttpPost("ContratarSolicitante")]
        public IActionResult Contratar(int vacanteId, int solicitanteId)
        {
            _contratarSolicitante.Contractar(vacanteId, solicitanteId);
            return Ok("Solicitante contratado");

        }
    }
}
