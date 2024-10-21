﻿using System.ComponentModel.DataAnnotations;

namespace Web_Red_de_Esperanza.Models
{
    public class necesitados
    {
        [Key]
        public int Id_publicacion { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public string dirección { get; set; }
        public int distrito_id { get; set; }
        public int ayuda_id { get; set; }
        public string Situacion_descripcion { get; set; }
        public DateTime fecha_publicacion { get; set; }
        public int asistido_id { get; set; }
        public int publicado_por { get; set; }

    }
}
