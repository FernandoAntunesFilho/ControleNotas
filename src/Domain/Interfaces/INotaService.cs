using ControleNotas.src.Domain.DTOs.Nota;

namespace ControleNotas.src.Domain.Interfaces
{
    public interface INotaService
    {
        Task AddNotaAsync(NotaRequestDTO nota);
        Task DeleteNotaAsync(int id);
        Task UpdateNotaAsync(int id, NotaRequestDTO nota);
        Task<IEnumerable<NotaResponseDTO>> GetNotasAsync();
        Task<IEnumerable<NotaResponseDTO>> GetNotasByAlunoAsync(int alunoId);
        Task<NotaResponseDTO> GetNotaByIdAsync(int id);
    }
}