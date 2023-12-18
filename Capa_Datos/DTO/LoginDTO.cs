using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.DTO
{
    public class LoginDTO
    {
        public string Correo {  get; set; }
        public string Contrasena { get; set; }
        public string TipoCuenta { get; set; }
    }
}
