using Capa_Datos;
using Capa_Datos.DTO;
using Capa_Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.Clases
{
    public class SolicitanteService : ISolicitante
    {
        private readonly PortalEmpleoContext _context;

        public SolicitanteService(PortalEmpleoContext context)
        {
            _context = context;
        }

        public void EditarSolicitante(SolicitanteDTO solicitanteDTO)
        {
            Solicitante solicitante = _context.Solicitantes.FirstOrDefault(s => s.Id == solicitanteDTO.Id);
            Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.Id == solicitanteDTO.Id);
            if (solicitante != null)
            {
                solicitante.Nombre = solicitanteDTO.Nombre;
                solicitante.Email = solicitanteDTO.Email;
                solicitante.Contrasena = solicitanteDTO.Contrasena;
                _context.Solicitantes.Update(solicitante);
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
            }
        }
        public void EliminarSolicitante(int id)
        {
            Solicitante solicitante = _context.Solicitantes.FirstOrDefault(s => s.Id == id);
            Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);

            if (solicitante != null)
            {
                _context.Solicitantes.Remove(solicitante);
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
                
            }
        }
        public List<SolicitanteDTO> ListarSolicitantes()
        {
            var solicitante = new List<SolicitanteDTO>();
            var data = _context.Solicitantes.Where(solicitante => solicitante.Estado != "Inactivo").ToList();
            foreach (var item in data)
            {
                SolicitanteDTO solicitanteDTO = new SolicitanteDTO();
                solicitanteDTO.Id = item.Id;
                solicitanteDTO.Nombre = item.Nombre;
                solicitanteDTO.Email = item.Email;
                solicitante.Add(solicitanteDTO);
            }

            return solicitante;
        }
    }
}
