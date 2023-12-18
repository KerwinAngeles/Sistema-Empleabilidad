using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.DTO
{
    public class VacanteDTO
    {
        public int VacanteId { get; set; }
        public int? EmpresaId { get; set; }
        public string Titulo { get; set; }   
        public string Descripcion { get; set; }
    }
}
