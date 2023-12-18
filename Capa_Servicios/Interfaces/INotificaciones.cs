using Capa_Datos;
using Capa_Datos.DTO;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.Interfaces
{
    public interface INotificaciones
    {
        List<Notificar> ObtenerNotificaciones(string empresaEmail);
        List<NotificarSolicitante> ObtenerNotificacionesSolicitante(string email);
        void Notificar(Vacante vacante, Solicitante solicitante);
        string ObtenerEmailNotificaciones(int? empresaId);


    }
}
