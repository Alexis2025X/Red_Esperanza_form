using System.ComponentModel.DataAnnotations;

namespace Web_Red_de_Esperanza.Models
{
    public class cuentas
    {
        [Key]
        public int id_cuenta { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }


    }
}
