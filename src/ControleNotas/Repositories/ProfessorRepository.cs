using ControleNotas.src.context;
using ControleNotas.src.Domain.Interfaces;
using ControleNotas.src.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleNotas.src.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly AppDbContext _context;
        public ProfessorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Professor professor)
        {
            await _context.Professores.AddAsync(professor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var professor = await GetByIdAsync(id);
            if (professor != null)
            {
                _context.Professores.Remove(professor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Professor>> GetAllAsync()
        {
            return await _context.Professores.ToListAsync();
        }

        public async Task<IEnumerable<Professor>> GetByDisciplinaAsync(int disciplinaId)
        {
            return await _context.Professores
                .Where(p => p.DisciplinaId == disciplinaId)
                .ToListAsync();
        }

        public async Task<Professor?> GetByIdAsync(int id)
        {
            return await _context.Professores.FindAsync(id);
        }

        public async Task<IEnumerable<Professor>> GetByNomeAsync(string nome)
        {
            return await _context.Professores
                .Where(p => p.Nome.Contains(nome))
                .ToListAsync();
        }

        public async Task UpdateAsync(Professor professor)
        {
            _context.Professores.Update(professor);
            await _context.SaveChangesAsync();
        }
    }
}