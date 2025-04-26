using ControleNotas.src.Domain.DTOs.Disciplina;
using ControleNotas.src.Models;

namespace ControleNotas.src.Domain.Interfaces
{
    public interface IDisciplinaService
    {
        Task AddDisciplinaAsync(DisciplinaRequestDTO disciplina);
        Task DeleteDisciplinaAsync(int id);
        Task UpdateDisciplinaAsync(int id, DisciplinaRequestDTO disciplina);
        Task<IEnumerable<Disciplina>> GetDisciplinasAsync();
        Task<Disciplina> GetDisciplinaByIdAsync(int id);
        Task<IEnumerable<Disciplina>> GetDisciplinasByNomeAsync(string nome);
    }
}