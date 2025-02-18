using Enmanuel_Gomez_P1_AP1.DAL.Ap1_P1.DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq.Expressions;

namespace Services;

public class AportesService(Contexto contexto)
{
    public async Task<bool> Guardar(Aportes aporte)
    {
        if (!await Existe(aporte.AporteId))
        {
            contexto.Aportes.Add(aporte);
        }
        else
        {
            contexto.Update(aporte);
        }
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Existe(int aporteId) =>
        await contexto.Aportes.AnyAsync(a => a.AporteId == aporteId);

    public async Task<Aportes?> Buscar(int aporteId) =>
        await contexto.Aportes.FindAsync(aporteId);

    public async Task<bool> Eliminar(int aporteId)
    {
        var aporte = await contexto.Aportes.FindAsync(aporteId);
        if (aporte is null) return false;
        contexto.Aportes.Remove(aporte);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<List<Aportes>> Consultar(string? persona, DateTime? desde, DateTime? hasta)
    {
        var query = contexto.Aportes.AsQueryable();
        if (!string.IsNullOrWhiteSpace(persona))
            query = query.Where(a => a.Persona.Contains(persona));
        if (desde.HasValue && hasta.HasValue)
            query = query.Where(a => a.Fecha >= desde && a.Fecha <= hasta);
        return await query.AsNoTracking().ToListAsync();
    }
}

public class Aportes
{
    public int AporteId { get; set; }
    public string Persona { get; set; } = string.Empty;
    public string Observacion { get; set; } = string.Empty;
    public decimal Monto { get; set; }
    public DateTime Fecha { get; set; }
}

