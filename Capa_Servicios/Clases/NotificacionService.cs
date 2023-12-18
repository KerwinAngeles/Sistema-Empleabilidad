using Capa_Datos;
using Capa_Datos.DTO;
using Capa_Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.Clases
{
    public class NotificacionService : INotificaciones
    {
        public readonly PortalEmpleoContext _context;
        public readonly IEnviarCorreo _enviarCorreo;
        public NotificacionService(PortalEmpleoContext portalEmpeloContext,IEnviarCorreo enviarCorreo)
        {
            _context = portalEmpeloContext;
            _enviarCorreo = enviarCorreo;
        }

        public string ObtenerEmailNotificaciones(int? empresaId)
        {
            Empresa empresa = _context.Empresas.FirstOrDefault(e => e.Id == empresaId);
            return empresa.Email;
        }

        public void Notificar(Vacante vacante, Solicitante solicitante)
        {
            Notificar notificacion = new Notificar
            { 
                EmpresaId = vacante.EmpresaId,
                Contenido = $"El solicitante {solicitante.Nombre} ha aplicado a la vacante {vacante.Titulo}",
                Estado = false,
                Fecha = DateTime.Now
            };

            _context.Notificars.Add(notificacion);
            _context.SaveChanges();

            string correo = ObtenerEmailNotificaciones(vacante.EmpresaId);
            if (!string.IsNullOrEmpty(correo))
            {
                string asunto = "Nueva aplicacion a vacante";
                string body = $"El solicitante {solicitante.Nombre} ha aplicado a la vacante {vacante.Titulo}.";
                _enviarCorreo.Enviar(correo, asunto, body);
            }
        }

        public List<Notificar> ObtenerNotificaciones(string email)
        {
            return _context.Notificars
                   .Where(n => n.Empresa.Email == email)
                   .OrderByDescending(n => n.Fecha)
                   .ToList();
        }    

        public List<NotificarSolicitante> ObtenerNotificacionesSolicitante(string email)
        {
            return _context.NotificarSolicitantes
                .Where(e => e.Solicitante.Email == email)
                .OrderByDescending(e => e.Fecha)
                .ToList();
        }

    }
}
