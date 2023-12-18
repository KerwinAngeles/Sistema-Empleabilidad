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
    public class AutenticacionService : IAutenticacion
    {
        private readonly PortalEmpleoContext _context;

        public AutenticacionService(PortalEmpleoContext context)
        {
            _context = context;
        }

        public bool RegistrarUsuarios(UsuarioDTO usuario)
        {

            var nuevoUsuario = new Usuario
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Email,
                Contrasena = usuario.Contrasena,
                Estado = usuario.Estado,
                TipoCuenta = usuario.TipoCuenta
            };

            _context.Usuarios.Add(nuevoUsuario);

            if (usuario.TipoCuenta == "Empresa")
                {
                    var nuevaEmpresa = new Empresa
                    {
                        Id = usuario.Id,
                        Nombre = usuario.Nombre,
                        Email = usuario.Email,
                        Contrasena = usuario.Contrasena,
                        Estado = usuario.Estado,
                    };

                    _context.Empresas.Add(nuevaEmpresa);
            }
            else if (usuario.TipoCuenta == "Solicitante")
            {
                var nuevoSolicitante = new Solicitante
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Email = usuario.Email,
                    Contrasena = usuario.Contrasena,
                    Estado = usuario.Estado

                };

                _context.Solicitantes.Add(nuevoSolicitante);
            }
            else if(usuario.TipoCuenta == "Analista")
            {
                var nuevoAnalista = new Analistum
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Correo = usuario.Email,
                    Contrasena = usuario.Contrasena,
                };

                _context.Analista.Add(nuevoAnalista);
            }
            else if(usuario.TipoCuenta == "Gerente")
            {
                var nuevoGerente = new Gerente
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Correo = usuario.Email,
                    Contrasena = usuario.Contrasena,
                };

                
            }

            _context.SaveChanges();
            return true;      
        }

        public bool Login(LoginDTO loginDTO)
        {
          
           var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == loginDTO.Correo && u.Contrasena == loginDTO.Contrasena && u.TipoCuenta == loginDTO.TipoCuenta);
           if (usuario != null)
           {
                return true;
           }
           else
           {
                return false;
           }
        }
    }
}
