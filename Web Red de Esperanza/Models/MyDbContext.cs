using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Red_de_Esperanza.Models
{
    public class MyDbContext : DbContext
    {
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb; Database=red_esperanza; integrated security=true;");
        }*/

        public MyDbContext() { }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        //NECESITADOS
        public DbSet<Necesitado> necesitados { get; set; }
        //DESAPARECIDOS
        public DbSet<desaparecidos> desaparecidos { get; set; }
        //CUENTAS
        public DbSet<cuentas> cuentas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  //NECESITADOS
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Necesitado>().HasKey(e => e.Id_publicacionNese);
            //DESAPARECIDOS
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<desaparecidos>().HasKey(e => e.Id_publicacionDesa);
            //CUENTAS
           base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<cuentas>().HasKey(e => e.Id_cuenta);
        }


    }


}
