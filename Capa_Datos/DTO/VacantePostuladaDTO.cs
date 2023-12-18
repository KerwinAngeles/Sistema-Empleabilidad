using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.DTO
{
    public  class VacantePostuladaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int NumeroPostulaciones { get; set; }
        public int NumeroVacantesPublicadas { get; set; }

    }
}
