using System.ComponentModel.DataAnnotations;

namespace Web_Red_de_Esperanza.Models
{
    public class Distrito
    {
        [Key]
        public int id_distrito { get; set; }
        public required string nombre_distrito { get; set; }
    }
}
