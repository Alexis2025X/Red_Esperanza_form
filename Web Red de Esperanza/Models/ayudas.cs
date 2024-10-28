using System.ComponentModel.DataAnnotations;

namespace Web_Red_de_Esperanza.Models
{
    public class Ayudas
    {
        [Key]
        public int Id_ayuda { get; set; }
        public required string tipo_ayuda { get; set; }
    }
}
