using System.ComponentModel.DataAnnotations;

namespace Web_Red_de_Esperanza.Models
{
    public class Necesitados
    {
        [Key]
        public int Id_publicacion { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public int Edad { get; set; }
        public required string dirección { get; set; }
        public int distrito_id { get; set; }
        public int ayuda_id { get; set; }
        public required string Situacion_descripcion { get; set; }
        public DateTime fecha_publicacion { get; set; }
        public int asistido_id { get; set; }
        public int publicado_por { get; set; }

    }
}
