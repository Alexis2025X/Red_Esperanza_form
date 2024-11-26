using System.ComponentModel.DataAnnotations;

namespace Web_Red_de_Esperanza.Models
{
    public class cuentas
    {
        [Key]
        public int Id_cuenta { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }


        //relacionar con la tabla matricula
        public ICollection<Necesitado>? necesitados { get; set; }

        public ICollection<Desaparecidos>? desaparecidos { get; set; }
    }
}
