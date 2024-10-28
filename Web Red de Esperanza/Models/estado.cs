using System.ComponentModel.DataAnnotations;

namespace Web_Red_de_Esperanza.Models
{
    public class Estado
    {
        [Key]
        public int Id_estado { get; set; }
        public required string estado { get; set; }

    }
}
