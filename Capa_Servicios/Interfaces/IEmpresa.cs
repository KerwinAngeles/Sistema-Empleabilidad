using Capa_Datos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.Interfaces
{
    public interface IEmpresa
    {
        void Editar(EmpresaDTO empresaDTO);
        void Eliminar(int id);
        List<EmpresaDTO> ListarEmpresas();
        List<EmpresaDTO> BuscarEmpresa(int id);
        EmpresaDTO Seguidores(int id);
    }
}
