using Capa_Datos;
using Capa_Datos.DTO;
using Capa_Servicios.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.Clases
{
    public class ContratarSolicitanteService : IContratarSolicitante
    {
        public readonly PortalEmpleoContext _context;
        public readonly IEnviarCorreo _enviarCorreo;
        public ContratarSolicitanteService(PortalEmpleoContext context, IEnviarCorreo enviarCorreo)
        {
            _context = context;
            _enviarCorreo = enviarCorreo;
        }

        public void Contractar(int vacanteId, int solicitanteId)
        {
            Vacante vacante = _context.Vacantes.FirstOrDefault(v => v.VacanteId == vacanteId);
            Postulacione postulacione = _context.Postulaciones.FirstOrDefault(p => p.SolicitanteId == solicitanteId && p.VacanteId == vacanteId);
           

            if (vacante != null)
            {
                vacante.PlazaOcupada = true;
                postulacione.EstadoPostulacion = "Contratado";
                _context.SaveChanges();

                var postulacion = _context.Postulaciones.Where(p => p.VacanteId == vacanteId);
                foreach (var item in postulacion)
                {
                    // Solicitante solicitante = _context.Solicitantes.FirstOrDefault(s => s.Id == item.SolicitanteId);
                    //_enviarCorreo.Enviar(solicitante.Email, "Actualizacion de vacante", "Vacante ocupada");

                    //Solicitante solicitanteContratado = _context.Solicitantes.FirstOrDefault(s => s.Id ==  solicitanteId);
                    //_enviarCorreo.Enviar(solicitanteContratado.Email, "FELICIDADES", $"Estas contratado");

                    Solicitante solicitante = _context.Solicitantes.FirstOrDefault(s => s.Id == item.SolicitanteId);

                    if (solicitante.Id == solicitanteId) 
                    {
                        _enviarCorreo.Enviar(solicitante.Email, "¡FELICIDADES!", $"¡Felicidades! Has sido contratado para la vacante {vacante.Titulo}");
                    }
                    else
                    {
                        _enviarCorreo.Enviar(solicitante.Email, "Actualización de vacante", "Vacante ocupada");
                    }

                }             
            }
        }
    }
}
