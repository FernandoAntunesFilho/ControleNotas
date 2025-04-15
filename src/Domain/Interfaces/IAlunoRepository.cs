using ControleNotas.src.DTOs.Aluno;
using ControleNotas.src.Models;

namespace ControleNotas.Domain.Interfaces
{
    public interface IAlunoRepository
    {
        Task<Aluno?> GetByIdAsync(int id);
        Task<IEnumerable<Aluno>> GetByNomeAsync(string nome);
        Task<Aluno?> GetByMatriculaAsync(string matricula);
        Task<IEnumerable<Aluno>> GetByTurmaAsync(string turma);
        Task<IEnumerable<Aluno>> GetAllAsync();
        Task AddAsync(Aluno aluno);
        Task UpdateAsync(Aluno aluno);
        Task DeleteAsync(Aluno aluno);
    }
}