using Capa_Datos.DTO;
using Capa_Datos.Interfaces;
using Capa_Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresa _empresa;
        private readonly IEmpresaObservable _empresaObservable;

        public EmpresaController(IEmpresa empresa, IEmpresaObservable empresaObservable)
        {
            _empresa = empresa;
            _empresaObservable = empresaObservable;
        }

        [HttpPut("ActualizarEmpresa")]
        public IActionResult EditarEmpresa(EmpresaDTO empresaDTO)
        {
            _empresa.Editar(empresaDTO);
            return Ok("Empresa editada exitosamente");
        }

        [HttpDelete("EliminarEmpresa")]
        public IActionResult EliminarEmpresa(int id)
        {
            try
            {
                _empresa.Eliminar(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok("Empresa Eliminada");
        }

        [HttpGet("ListarEmpresas")]

        public ActionResult<EmpresaDTO> ListarEmpresas()
        {
            var empresas = _empresa.ListarEmpresas();
            return Ok(empresas);
        }

        [HttpGet("Buscar")]
        public IActionResult BuscarEmpresa(int id)
        {
            var buscar = _empresa.BuscarEmpresa(id);
            return Ok(buscar);
        }

        [HttpPost("Suscribir")]
        public IActionResult Suscribir(int solicitante, int empresaID)
        {
            _empresaObservable.Suscribir(solicitante, empresaID);
            return Ok("Suscrito");
        }

        [HttpPost("Desuscribir")]
        public IActionResult Desuscribir(int solicitanteId, int empresaId)
        {
            _empresaObservable.Desuscribir(solicitanteId, empresaId);
            return Ok("Desuscrito");
        }

        [HttpGet("Seguidores")]
        public IActionResult Seguidores(int id)
        {
            var seguidores = _empresa.Seguidores(id);
            return Ok(seguidores);
        }


    }
}
