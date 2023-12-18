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
    public class EstadisticaService : IData
    {
        private readonly PortalEmpleoContext _context;
        public EstadisticaService(PortalEmpleoContext context)
        {
            _context = context;
        }

        public EstadisticaDTO Datos(string correo)
        {
            var estadistica = new EstadisticaDTO();
            var empresa = _context.Suscripcions.Where(e => e.Empresa.Email == correo);
            var vacante = _context.Vacantes.Where(v => v.Empresa.Email  == correo);
            var postulaciones = _context.Vacantes.Where(v => v.Empresa.Email == correo);

            estadistica.Seguidores = _context.Suscripcions.Count(s => s.Empresa.Email == correo);
            estadistica.VacanteAplicadas = _context.Postulaciones.Count(p => p.Empresa.Email == correo);
            estadistica.VacantePublicadas = _context.Vacantes
            .Where(v => v.Empresa.Email == correo)
            .Select(v => v.VacanteId)
            .Distinct()
            .Count();

            estadistica.VacanteAplicadas = _context.Postulaciones
            .Where(v => v.Empresa.Email == correo)
            .Select(v => v.VacanteId)
            .Distinct()
            .Count();

            return estadistica;    
           
        }
    }
}
