using Capa_Datos.DTO;
using Capa_Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.Clases
{
    public class CorreoService : IEnviarCorreo
    {
        public void Enviar(string correo, string asunto, string cuerpo)
        {
            string mensaje = "error al enviar el correo electronico";

            try
            {
                MailMessage email = new MailMessage();
                email.From = new MailAddress("pruebadeprogramacion12@gmail.com");
                email.To.Add(correo);
                email.Subject = asunto;
                email.Body = cuerpo;
                email.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("pruebadeprogramacion12@gmail.com", "usvb wkjz gtzv bree");
                smtp.EnableSsl = true;
                smtp.Send(email);
                mensaje = "Mensaje enviado con exito";

            }
            catch (Exception ex)
            {
                mensaje = "Error al enviar el correo: " + ex.ToString();

            }
        }
    }
}
