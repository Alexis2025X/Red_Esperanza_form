using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Web_Red_de_Esperanza.Models
{
    public class Necesitado
    {
        [Key]
        public int Id_publicacionNese { get; set; }
        public required string Nombre_nece { get; set; }
        public required string Apellido { get; set; }
        public int Edad { get; set; }
        public required string Direccion { get; set; }
        public int Distrito_id { get; set; }
        public int Ayuda_id { get; set; }
        public required string Situacion_descripcion { get; set; }
        public DateTime Fecha_publicacion { get; set; }
        public int Asistido_id { get; set; }
        public string? Telefono { get; set; }
        public string? WhatsApp { get; set; }
        public int Publicado_por { get; set; }
        //public int Imagen_necesitados { get; set; }

    }
}
