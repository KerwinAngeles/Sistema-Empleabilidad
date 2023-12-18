using Capa_Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificaciones _notificaciones;

        public NotificacionesController(INotificaciones notificaciones)
        {
            _notificaciones = notificaciones;
        }

        [HttpGet("NotificacionesEmpresa")]
        public IActionResult ObtenerNotificaciones(string email)
        {
           var notificaciones = _notificaciones.ObtenerNotificaciones(email);
           return Ok(notificaciones);
         
        }

        [HttpGet("NotificacionesSolicitante")]
        public IActionResult notifySolicitante(string email)
        {
            var notify  = _notificaciones.ObtenerNotificacionesSolicitante(email); 
            return Ok(notify);
        }
    }
}
