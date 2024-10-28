using System.ComponentModel.DataAnnotations;

namespace Web_Red_de_Esperanza.Models
{
    public class Distritos
    {
        [Key]
        public int Id_distrito { get; set; }
        public required string distrito { get; set; }
    }
}
