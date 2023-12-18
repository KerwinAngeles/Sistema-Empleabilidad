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
    public class EmpresaService : IEmpresa
    {
        private readonly PortalEmpleoContext _context;

        public EmpresaService(PortalEmpleoContext context)
        {
            _context = context;
        }

        public void Editar(EmpresaDTO empresaDTO)
        {
            Empresa empresa = _context.Empresas.FirstOrDefault(e => e.Id == empresaDTO.Id);
            if (empresa != null)
            {
                empresa.Nombre = empresaDTO.Nombre;
                empresa.Email = empresaDTO.Email;
                empresa.Contrasena = empresaDTO.Contrasena;

                _context.Empresas.Update(empresa);
                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var NotificacionEmpresa = _context.Notificars.Where(n => n.EmpresaId == id);
            _context.Notificars.RemoveRange(NotificacionEmpresa);

            Empresa empresa = _context.Empresas.FirstOrDefault(empresa => empresa.Id == id);
            Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);


            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }   
        }

        public List<EmpresaDTO> ListarEmpresas()
        {
            var empresaDTO = new List<EmpresaDTO>();
            var data = _context.Empresas.Where(empresa => empresa.Estado != "Inactivo").ToList();
            
            foreach (var item in data)
            {
                EmpresaDTO empresa = new EmpresaDTO();
                empresa.Id = item.Id;
                empresa.Nombre = item.Nombre;
                empresa.Email = item.Email;
                empresaDTO.Add(empresa);
            }
            return empresaDTO;
        }

        public List< EmpresaDTO> BuscarEmpresa(int id)
        {
            var empresaDTO = new List<EmpresaDTO>();
            var data = _context.Empresas.Where(e => e.Id == id);
            
            foreach (var item in data)
            {
                EmpresaDTO empresa = new EmpresaDTO();
                empresa.Id = item.Id;
                empresa.Nombre = item.Nombre;
                empresa.Email = item.Email;  
                empresaDTO.Add(empresa) ;
            }
            return empresaDTO;
        }

        public EmpresaDTO Seguidores(int id)
        {
            var empresa = _context.Suscripcions.Where(e => e.EmpresaId ==  id);
           
            EmpresaDTO empresaDTO = new EmpresaDTO
            {
                    Seguidores = _context.Suscripcions.Count(e => e.EmpresaId == id)
            };

            return empresaDTO;
                   
        }
    }
}
