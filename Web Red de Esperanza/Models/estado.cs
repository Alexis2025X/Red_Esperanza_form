using System.ComponentModel.DataAnnotations;

namespace Web_Red_de_Esperanza.Models
{
    public class estado
    {
        [Key]
        public int Id_estado { get; set; }
        public string estado_ { get; set; }

    }
}
