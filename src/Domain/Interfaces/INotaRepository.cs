using ControleNotas.src.Models;

namespace ControleNotas.src.Domain.Interfaces
{
    public interface INotaRepository
    {
        Task<Nota> GetByIdAsync(int id);
        Task<IEnumerable<Nota>> GetByAlunoAsync(int alunoId);
        Task<IEnumerable<Nota>> GetAllAsync();
        Task AddAsync(Nota nota);
        Task UpdateAsync(Nota nota);
        Task DeleteAsync(int id);
    }
}