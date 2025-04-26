using ControleNotas.src.context;
using ControleNotas.src.Domain.Interfaces;
using ControleNotas.src.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleNotas.src.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly AppDbContext _context;
        public DisciplinaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Disciplina disciplina)
        {
            await _context.Disciplinas.AddAsync(disciplina);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var disciplina = await GetByIdAsync(id);
            if (disciplina != null)
            {
                _context.Disciplinas.Remove(disciplina);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Disciplina>> GetAllAsync()
        {
            return await _context.Disciplinas.ToListAsync();
        }

        public async Task<Disciplina?> GetByIdAsync(int id)
        {
            return await _context.Disciplinas.FindAsync(id);
        }

        public async Task<IEnumerable<Disciplina>> GetByNomeAsync(string nome)
        {
            return await _context.Disciplinas
                .Where(d => d.Nome.Contains(nome))
                .ToListAsync();
        }

        public async Task UpdateAsync(Disciplina disciplina)
        {
            _context.Disciplinas.Update(disciplina);
            await _context.SaveChangesAsync();
        }
    }
}