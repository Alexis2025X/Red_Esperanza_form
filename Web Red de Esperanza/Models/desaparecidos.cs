using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace Web_Red_de_Esperanza.Models
{
    public class Desaparecidos
    {
        [Key]
        public int Id_publicacionDesa { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public int Edad { get; set; }
        public DateTime Fecha_Desaparicion { get; set; }
        public required string Lugar_Desaparicion { get; set; }
        public required string Descripción_persona { get; set; }
        public required string Telefono { get; set; }
        public string? WhatsApp { get; set; }
        public int Distrito_id { get; set; }
        public DateTime Fecha_publicacion { get; set; }
        public int Publicado_por { get; set; }
        public byte[]? imagen { get; set; }

        //relacionando
        [ForeignKey("Publicado_por")]
        public cuentas? cuenta { get; set; }
    }

}
