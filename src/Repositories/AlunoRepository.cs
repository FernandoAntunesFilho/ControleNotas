using ControleNotas.Domain.Interfaces;
using ControleNotas.src.context;
using ControleNotas.src.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleNotas.src.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;
        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var aluno = await GetByIdAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Aluno>> GetAllAsync()
        {
            return await _context.Alunos.ToListAsync();
        }

        public async Task<Aluno?> GetByIdAsync(int id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        public async Task<Aluno?> GetByMatriculaAsync(string matricula)
        {
            return await _context.Alunos.FirstOrDefaultAsync(a => a.Matricula == matricula);
        }

        public async Task<IEnumerable<Aluno>> GetByNomeAsync(string nome)
        {
            return await _context.Alunos
                .Where(a => a.Nome.Contains(nome))
                .ToListAsync();
        }

        public async Task<IEnumerable<Aluno>> GetByTurmaAsync(string turma)
        {
            return await _context.Alunos
                .Where(a => a.Turma == turma)
                .ToListAsync();
        }

        public async Task UpdateAsync(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();
        }
    }
}