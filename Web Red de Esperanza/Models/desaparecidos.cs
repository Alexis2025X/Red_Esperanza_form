using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Red_de_Esperanza.Models
{
    public class Desaparecidos
    {
        // Clave primaria
        [Key]
        public int Id_publicacionDesa { get; set; }

        // Propiedades básicas
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }

        [Range(0, 120, ErrorMessage = "La edad debe estar entre 0 y 120 años.")]
        public int Edad { get; set; }

        [Required]
        public DateTime Fecha_Desaparicion { get; set; }

        [MaxLength(200)]
        public string Lugar_Desaparicion { get; set; }

        [MaxLength(500)]
        public string Descripción_persona { get; set; }

        [Phone]
        public string Telefono { get; set; }

        [Phone]
        public string? WhatsApp { get; set; }

        public DateTime Fecha_publicacion { get; set; } = DateTime.Now;

        // Claves foráneas
        [Required]
        [ForeignKey("Cuenta")]
        public int id_cuenta { get; set; }

        [Required]
        [ForeignKey("Distrito")]
        public int id_distrito { get; set; }

        // Propiedades de navegación
        public Cuentas Cuenta { get; set; }
        public Distritos Distrito { get; set; }
    }

    public class Cuentas
    {
        // Clave primaria
        [Key]
        public int id_cuenta { get; set; }

        // Propiedades básicas
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string Usuario { get; set; }

        [Required]
        [MaxLength(100)]
        public string Contraseña { get; set; }

        // Propiedades de navegación inversa
       //public ICollection<Desaparecidos> desaparecidos { get; set; }
    }

    public class Distritos
    {
        // Clave primaria
        [Key]
        public int id_distrito { get; set; }

        // Propiedades básicas
        [Required]
        [MaxLength(100)]
        public string nombre_distrito { get; set; }

        // Propiedades de navegación inversa
        //public ICollection<Desaparecidos> Desaparecidos { get; set; }
    }

    public class RedDeEsperanzaContext : DbContext
    {
        public DbSet<Desaparecidos> Desaparecidos { get; set; }
        public DbSet<Cuentas> Cuenta { get; set; }
        public DbSet<Distritos> Distritos { get; set; }

        public RedDeEsperanzaContext(DbContextOptions<RedDeEsperanzaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para Desaparecidos
            modelBuilder.Entity<Desaparecidos>()
                .ToTable("Desaparecidos") // Asegurar el nombre correcto de la tabla
                .HasKey(d => d.Id_publicacionDesa);

            modelBuilder.Entity<Desaparecidos>()
                .HasOne(d => d.Cuenta);
            //.WithMany(c => c.desaparecidos)
            //.HasForeignKey(d => d.id_cuenta)
            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Desaparecidos>()
                .HasOne(d => d.Distrito);
                //.WithMany(d => d.Desaparecidos)
                //.HasForeignKey(d => d.id_distrito)
                //.OnDelete(DeleteBehavior.Cascade);

            // Configuración para Cuentas
            modelBuilder.Entity<Cuentas>()
                .ToTable("Cuentas") // Asegurar el nombre correcto de la tabla
                .HasKey(c => c.id_cuenta);

            // Configuración para Distritos
            modelBuilder.Entity<Distritos>()
                .ToTable("Distritos") // Asegurar el nombre correcto de la tabla
                .HasKey(d => d.id_distrito);
        }
    }
}
