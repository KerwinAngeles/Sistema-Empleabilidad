using Capa_Datos;
using Capa_Datos.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.Interfaces
{
    public interface IVacante
    {
        void CrearVacante(VacanteDTO vacanteDTO);
        void EditarVacante(VacanteDTO vacanteDTO);
        void AplicarVacante(PostulacionesDTO postulacionesDTO, IFormFile file);
        void EliminarVacante(int id); 

        List<VacanteDTO> BuscarVacante(int id);
        VacantePostuladaDTO vacantePostulacionesDTO(int id);
        int vacantePublicadasDTO(int empresaID);

        List<VacanteDTO> Listar();
        List<VacanteDTO> ListarVacante(string correo);
    }
}
