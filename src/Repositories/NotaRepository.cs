using ControleNotas.src.context;
using ControleNotas.src.Domain.Interfaces;
using ControleNotas.src.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleNotas.src.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly AppDbContext _context;
        public NotaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Nota nota)
        {
            await _context.Notas.AddAsync(nota);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var nota = await GetByIdAsync(id);
            if (nota != null)
            {
                _context.Notas.Remove(nota);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Nota>> GetAllAsync()
        {
            return await _context.Notas.ToListAsync();
        }

        public async Task<IEnumerable<Nota>> GetByAlunoAsync(int alunoId)
        {
            return await _context.Notas
                .Where(n => n.AlunoId == alunoId)
                .ToListAsync();
        }

        public async Task<Nota?> GetByIdAsync(int id)
        {
            return await _context.Notas.FindAsync(id);
        }

        public async Task UpdateAsync(Nota nota)
        {
            _context.Notas.Update(nota);
            await _context.SaveChangesAsync();
        }
    }
}