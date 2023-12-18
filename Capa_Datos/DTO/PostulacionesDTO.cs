using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.DTO
{
    public class PostulacionesDTO
    {
        public int Id { get; set; }
        public int SolicitanteId { get; set; }
        public int VacanteId { get; set; }
        public int? EmpresaId {  get; set; }
    }
}
