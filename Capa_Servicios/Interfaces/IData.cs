using Capa_Datos;
using Capa_Datos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.Interfaces
{
    public interface IData
    {
        EstadisticaDTO Datos(string correo);
    }
}
