using Capa_Datos;
using Capa_Datos.DTO;
using Capa_Datos.Interfaces;
using Capa_Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.Clases
{
    public class VacanteService : IVacante
    {
        public readonly PortalEmpleoContext _context;
        public readonly IEmpresaObservable _empresa;
        public readonly INotificaciones _notificaciones;
        public readonly IImagenes _imagenes;
        public VacanteService(PortalEmpleoContext context, INotificaciones notificaciones, IImagenes imagenes, IEmpresaObservable empresa)
        {
            _context = context;
            _notificaciones = notificaciones;
            _imagenes = imagenes;
            _empresa = empresa;
        }

        public void CrearVacante(VacanteDTO vacanteDTO)
        {
            Vacante vacante = new Vacante
            {
                VacanteId = vacanteDTO.VacanteId,
                EmpresaId = vacanteDTO.EmpresaId,
                Titulo = vacanteDTO.Titulo,
                Descripcion = vacanteDTO.Descripcion,
                FechaPublicacion = DateTime.Now,
            };

            _context.Vacantes.Add(vacante);           
            _context.SaveChanges();
            _empresa.Notificar(vacanteDTO, vacanteDTO.EmpresaId);
        }

        public void EditarVacante(VacanteDTO vacanteDTO)
        {
            Vacante vacante = _context.Vacantes.FirstOrDefault(v => v.VacanteId == vacanteDTO.VacanteId);
            if(vacante != null)
            {
                vacante.Titulo = vacanteDTO.Titulo;
                vacante.Descripcion = vacanteDTO.Descripcion;

                _context.Vacantes.Update(vacante);
                _context.SaveChanges();
            }
            
        }

        public void EliminarVacante(int id)
        {

            var postulacionesRelacionadas = _context.Postulaciones.Where(p => p.VacanteId == id);
            _context.Postulaciones.RemoveRange(postulacionesRelacionadas);

            Vacante vacante = _context.Vacantes.FirstOrDefault(v => v.VacanteId == id);
            _context.Vacantes.Remove(vacante);
            _context.SaveChanges();

        }


        public List<VacanteDTO> BuscarVacante(int id)
        {
            var vacanteDTO = new List<VacanteDTO>();
            var data = _context.Vacantes.Where(e => e.VacanteId == id);
            foreach ( var item in data)
            {
                VacanteDTO vacante = new VacanteDTO();
                vacante.VacanteId = item.VacanteId;
                vacante.EmpresaId = item.EmpresaId;
                vacante.Titulo = item.Titulo;
                vacante.Descripcion = item.Descripcion;
                vacanteDTO.Add(vacante);
            }
            return vacanteDTO;
        }

        public List<VacanteDTO> ListarVacante(string correo)
        {
            var vacanteDTO = new List<VacanteDTO>();
            var data = _context.Vacantes.Where(v => v.Empresa.Email == correo);
            foreach (var item in data)
            {
                VacanteDTO vacante = new VacanteDTO();
                vacante.VacanteId = item.VacanteId;
                vacante.EmpresaId = item.EmpresaId;
                vacante.Titulo = item.Titulo;
                vacante.Descripcion = item.Descripcion;
                vacanteDTO.Add(vacante);
            }
            return vacanteDTO;
        }

        public List<VacanteDTO> Listar()
        {
            var vacanteDTO = new List<VacanteDTO>();
            var data = _context.Vacantes.ToList();
            foreach (var item in data)
            {
                VacanteDTO vacante = new VacanteDTO();
                vacante.VacanteId = item.VacanteId;
                vacante.EmpresaId = item.EmpresaId;
                vacante.Titulo = item.Titulo;
                vacante.Descripcion = item.Descripcion;
                vacanteDTO.Add(vacante);
            }
            return vacanteDTO;
        }

        public void AplicarVacante(PostulacionesDTO postulacionesDTO, IFormFile file)
        {
            Empresa empresa = _context.Empresas.FirstOrDefault(e => e.Id == postulacionesDTO.EmpresaId);
            Solicitante solicitante = _context.Solicitantes.FirstOrDefault(s => s.Id == postulacionesDTO.SolicitanteId);
            Vacante vacante = _context.Vacantes.FirstOrDefault(v => v.VacanteId == postulacionesDTO.VacanteId);
            string ruta = _imagenes.GuardarImagen(file);

            if (solicitante != null && vacante != null)
            {
                Postulacione postulacion = new Postulacione
                {

                    Id = postulacionesDTO.Id,
                    EmpresaId = empresa.Id,
                    SolicitanteId = solicitante.Id,
                    VacanteId = vacante.VacanteId,
                    FechaPostulacion = DateTime.Now,
                    Cv = ruta
                };
                _context.Postulaciones.Add(postulacion);
                _context.SaveChanges();
                _notificaciones.Notificar(vacante, solicitante);
        
            }
        }

        public VacantePostuladaDTO vacantePostulacionesDTO(int id)
        {
            var vacante = _context.Vacantes.Where(v => v.EmpresaId == id);
            VacantePostuladaDTO vacanteDTO = new VacantePostuladaDTO
            {
                NumeroPostulaciones = _context.Postulaciones.Count(P => P.VacanteId == id)
            };
            return vacanteDTO;
        }

        public int vacantePublicadasDTO(int empresaID)
        {
            var vacantesDeLaEmpresa = _context.Vacantes.Where(v => v.EmpresaId == empresaID);

            int totalVacantesPublicadas = vacantesDeLaEmpresa
           .Select(v => v.VacanteId) 
           .Distinct() 
           .Count();  

            return totalVacantesPublicadas;
        }
    }
}
