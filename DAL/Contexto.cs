namespace Enmanuel_Gomez_P1_AP1.DAL
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
    {
        public class Context
        public virtual DbSet<Aportes> Aportes { get; set; }
        public virtual DbSet<AportesDetalles> AportesDetalles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aportes>().HasData(
                new List<Aportes>
                {
                    new()
                    {
                        AporteId = 1,
                        Persona = "Enel",
                        Monto = 100.00m,
                        Fecha = new DateTime(2024, 2, 1)
                    },
                    new()
                    {
                        AporteId = 2,
                        Persona = "Javier",
                        Monto = 100.00m,
                        Fecha = new DateTime(2024, 2, 3)
                    }
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}