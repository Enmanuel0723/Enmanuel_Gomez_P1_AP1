using Enmanuel_Gomez_P1_AP1.DAL.Ap1_P1.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services
{
    public class AporteService
    {
        private readonly Contexto _contexto;

        public AporteService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int aporteId)
        {
            return await _contexto.Aportes.AnyAsync(a => a.AporteId == aporteId);
        }

        public async Task<bool> Insertar(Aportes aporte)
        {
            _contexto.Aportes.Add(aporte);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Aportes aporte)
        {
            _contexto.Update(aporte);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Aportes aporte)
        {
            if (!await Existe(aporte.AporteId))
            {
                return await Insertar(aporte);
            }
            else
            {
                return await Modificar(aporte);
            }
        }

        public async Task<Aportes> Buscar(int aporteId)
        {
            return await _contexto.Aportes.FirstOrDefaultAsync(a => a.AporteId == aporteId);
        }

        public async Task<bool> Eliminar(int aporteId)
        {
            var aporte = await _contexto.Aportes.FindAsync(aporteId);
            if (aporte == null) return false;

            _contexto.Aportes.Remove(aporte);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<List<Aportes>> Listar(Expression<Func<Aportes, bool>> criterio)
        {
            return await _contexto.Aportes
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Aportes>> Filtrar(string persona, DateTime? desde, DateTime? hasta)
        {
            var query = _contexto.Aportes.AsQueryable();

            if (!string.IsNullOrEmpty(persona))
                query = query.Where(a => a.Persona.Contains(persona));

            if (desde.HasValue)
                query = query.Where(a => a.Fecha >= desde.Value);

            if (hasta.HasValue)
                query = query.Where(a => a.Fecha <= hasta.Value);

            return await query.AsNoTracking().ToListAsync();
        }
    }

    public class Aportes
    {
        public int AporteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Persona { get; set; }
        public string Observacion { get; set; }
        public decimal Monto { get; set; }
    }
}