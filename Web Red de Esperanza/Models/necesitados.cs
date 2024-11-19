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
        //SEÑALA EN 1
        public int distrito_id { get; set; }
        //nombre_distrito
        //SEÑALA EN 1
        public int ayuda_id { get; set; }
        //tipo_ayuda
        public required string Situacion_descripcion { get; set; }
        public DateTime Fecha_publicacion { get; set; }
        public string? Telefono { get; set; }
        public string? WhatsApp { get; set; }
        //SEÑALA EN 1
        public int publicado_por { get; set; }
        //Usuario
        public byte[]? imagen { get; set; }

    }
}
