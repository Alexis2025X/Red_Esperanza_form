using System.ComponentModel.DataAnnotations;

namespace Web_Red_de_Esperanza.Models
{
    public class Asistido
    {
        [Key]
        public int Id_asistido { get; set; }
        public required string asistido { get; set; }
    }
}
