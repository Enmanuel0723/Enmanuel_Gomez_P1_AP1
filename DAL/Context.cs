using JoseEstrella_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace JoseEstrella_Ap1_P1.DAL;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
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
