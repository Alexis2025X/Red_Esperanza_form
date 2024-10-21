using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace Web_Red_de_Esperanza.Models
{
    public class desaparecidos
    {
        [Key]
        public int Id_publicacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public DateTime Fecha_Desaparicion { get; set; }
        public string Lugar_Desaparicion { get; set; }
        public string Descripción_persona { get; set; }
        public string Telefono { get; set; }
        public string WhatsApp { get; set; }
        public int distrito_id { get; set; }
        public DateTime fecha_publicacion { get; set; }
        public int Publicado_por { get; set; }
        public byte[] Imagen_desaparecidos { get; set; } // Asumimos que 'image' se mapea a un array de bytes

    }
}
