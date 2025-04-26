using ControleNotas.src.Models;

namespace ControleNotas.src.Domain.Interfaces
{
    public interface IProfessorRepository
    {
        Task<Professor?> GetByIdAsync(int id);
        Task<IEnumerable<Professor>> GetByNomeAsync(string nome);
        Task<IEnumerable<Professor>> GetByDisciplinaAsync(int disciplinaId);        
        Task<IEnumerable<Professor>> GetAllAsync();
        Task AddAsync(Professor professor);
        Task UpdateAsync(Professor professor);
        Task DeleteAsync(int id);
    }
}