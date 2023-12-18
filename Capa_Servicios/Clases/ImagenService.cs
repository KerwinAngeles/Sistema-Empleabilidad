using Capa_Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.Clases
{
    public class ImagenService : IImagenes
    {
        public string GuardarImagen(IFormFile cv)
        {
            string ruta = @"C:\\Proyectos\\Imagenes";
            string nombreImagen = Guid.NewGuid().ToString() + Path.GetExtension(cv.FileName);
            string archivo = Path.Combine(ruta, nombreImagen);

            using (var stream = File.Create(archivo))
            {
                cv.CopyTo(stream);
            }

            return nombreImagen;

        }
    }
}
