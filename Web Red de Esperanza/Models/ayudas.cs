using System.ComponentModel.DataAnnotations;

namespace Web_Red_de_Esperanza.Models
{
    public class ayudas
    {
        [Key]
        public int Id_ayuda { get; set; }
        public string tipo_ayuda { get; set; }
    }
}
