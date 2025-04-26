using ControleNotas.src.Models;

namespace ControleNotas.src.Domain.Interfaces
{
    public interface IDisciplinaRepository
    {
        Task<Disciplina?> GetByIdAsync(int id);
        Task<IEnumerable<Disciplina>> GetByNomeAsync(string nome);
        Task<IEnumerable<Disciplina>> GetAllAsync();
        Task AddAsync(Disciplina disciplina);
        Task UpdateAsync(Disciplina disciplina);
        Task DeleteAsync(int id);
    }
}