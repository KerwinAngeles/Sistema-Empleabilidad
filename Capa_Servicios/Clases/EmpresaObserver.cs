using Capa_Datos;
using Capa_Datos.DTO;
using Capa_Datos.Interfaces;
using Capa_Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.Clases
{
    public class EmpresaObserver : IEmpresaObservable
    {
        private readonly IEnviarCorreo _enviarCorreo;
        private readonly PortalEmpleoContext _context;
        public EmpresaObserver(PortalEmpleoContext context, IEnviarCorreo enviarCorreo)
        {
            _context = context;
            _enviarCorreo = enviarCorreo;
        }
        public void Suscribir(int solicitanteId, int empresaId)
        {
            var solicitante = _context.Solicitantes.FirstOrDefault(s => s.Id == solicitanteId);
            var empresa = _context.Empresas.FirstOrDefault(e => e.Id == empresaId);

           if(empresa != null)
            {
                _context.Suscripcions.Add(new Suscripcion {
                    
                    SolicitanteId = solicitanteId,
                    EmpresaId = empresaId,
                });

                _context.SaveChanges();
            }
        }
        public void Desuscribir(int solicitanteId, int empresaId)
        {
            var relacionExistente = _context.Suscripcions
            .FirstOrDefault(r => r.SolicitanteId == solicitanteId && r.EmpresaId == empresaId);

            if (relacionExistente != null)
            {
                _context.Suscripcions.Remove(relacionExistente);
                _context.SaveChanges();
            }

        }

        public void Notificar(VacanteDTO vacanteDTO, int? empresaId)
        {
            var seguidores = _context.Suscripcions.Where(s => s.EmpresaId == empresaId).Select(s => s.SolicitanteId).ToList();
            foreach (var item in seguidores)
            {
                var solicitante = _context.Solicitantes.FirstOrDefault(s => s.Id == item);
                if(solicitante != null)
                {
                    NotificarSolicitante notificacion = new NotificarSolicitante
                    {
                        SolicitanteId = solicitante.Id,
                        Contenido = $"La vacante  {vacanteDTO.Titulo} a sido publicada.",
                        Estado = false,
                        Fecha = DateTime.Now
                    };
                    _context.NotificarSolicitantes.Add(notificacion);
                    _context.SaveChanges();
                    string mensaje = $"Nueva vacante {vacanteDTO.Titulo} publicada";
                    _enviarCorreo.Enviar(solicitante.Email, "Nueva Vacante", mensaje);
                }
            }

        }

    }
}
