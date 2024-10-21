using System.ComponentModel.DataAnnotations;

namespace Web_Red_de_Esperanza.Models
{
    public class cuentas
    {
        [Key]
        public int Id_cuenta { get; set; }
        public string Nombre_ { get; set; }
        public string Usuario_ { get; set; }
        public string Contraseña_ { get; set; }
    }
}
