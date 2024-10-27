using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Web_Red_de_Esperanza.Models
{
    public class Necesitado
    {
        [Key]
        public int Id_publicacionNese { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public int Edad { get; set; }
        public required string Direccion { get; set; }
        public int Distrito_id { get; set; }
        public int Ayuda_id { get; set; }
        public required string Situacion_descripcion { get; set; }
        public DateTime Fecha_publicacion { get; set; }
        public int Asistido_id { get; set; }
        public int Publicado_por { get; set; }
    }
}
