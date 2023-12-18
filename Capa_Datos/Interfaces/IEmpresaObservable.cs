using Capa_Datos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Interfaces
{
    public interface IEmpresaObservable
    {
        void Suscribir(int solicitante, int empresaID);
        void Desuscribir(int solicitante, int empresaId);
        void Notificar(VacanteDTO vacante, int? empresaId);
    }
}
