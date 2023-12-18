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
    public class PostulacionService : IPostulacion
    {
        public readonly PortalEmpleoContext _context;
        private readonly IEnviarCorreo _enviarCorreo;

        public PostulacionService(PortalEmpleoContext context, IEnviarCorreo enviarCorreo)
        {
            _context = context;
            _enviarCorreo = enviarCorreo;
        }

        public List<Postulacione> ObtenerPostulaciones(int vacanteId)
        {
            var postulacionesDTO = new List<Postulacione>();
            var data = _context.Postulaciones.Where(e => e.VacanteId == vacanteId);
            foreach (var postulaciones in data)
            {
                Postulacione postulacion = new Postulacione();
                postulacion.Id = postulaciones.Id;
                postulacion.VacanteId = postulaciones.VacanteId;
                postulacion.SolicitanteId = postulaciones.SolicitanteId;
                postulacion.Cv = postulaciones.Cv;
                postulacionesDTO.Add(postulacion);
               
            }
            return postulacionesDTO;
        }

        public List<PostulacionesDTO> BuscarPostulaciones(PostulacionesDTO postulacionesDTO)
        {
            var postulacionDTO = new List<PostulacionesDTO>();
            var data = _context.Postulaciones.Where(p => p.Id == postulacionesDTO.Id);
            Vacante vacante = _context.Vacantes.FirstOrDefault(v => v.VacanteId == postulacionesDTO.VacanteId);
            Solicitante solicitante = _context.Solicitantes.FirstOrDefault(p => p.Id == postulacionesDTO.SolicitanteId);
            Empresa empresa = _context.Empresas.FirstOrDefault(e => e.Id == postulacionesDTO.EmpresaId);

            
            foreach (var item in data)
            {
                PostulacionesDTO postulacione = new PostulacionesDTO();
                postulacione.Id = item.Id;
                postulacione.VacanteId = item.VacanteId;
                postulacione.SolicitanteId = item.SolicitanteId;
                postulacionDTO.Add(postulacione);

            }

            NotificarSolicitante notificacion = new NotificarSolicitante
            {
                SolicitanteId = solicitante.Id,
                Contenido = $"La empresa {empresa.Nombre} a visto tu vacante",
                Estado = false,
                Fecha = DateTime.Now
            };
            _context.NotificarSolicitantes.Add(notificacion);
            _context.SaveChanges();

            string asunto = "Vacante vista";
            string body = $"La empresa {empresa.Nombre} a visto tu vacante";
            _enviarCorreo.Enviar(solicitante.Email, asunto, body);

            return postulacionDTO;

        }
    }
}
