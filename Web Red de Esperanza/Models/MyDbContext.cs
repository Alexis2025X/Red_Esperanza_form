using Microsoft.EntityFrameworkCore;

namespace Web_Red_de_Esperanza.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<necesitados> necesitados { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<necesitados>().HasKey(e => e.Id_publicacion);
        }

    }
}
