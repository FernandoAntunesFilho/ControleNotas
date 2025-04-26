using ControleNotas.src.Domain.DTOs.Professor;
using ControleNotas.src.Models;

namespace ControleNotas.src.Domain.Interfaces
{
    public interface IProfessorService
    {
        Task AddProfessorAsync(ProfessorRequestDTO professor);
        Task DeleteProfessorAsync(int id);
        Task UpdateProfessorAsync(Professor professor);
        Task<IEnumerable<ProfessorResponseDTO>> GetProfessoresAsync();
        Task<IEnumerable<ProfessorResponseDTO>> GetProfessoresByDisciplinaAsync(int disciplinaId);
        Task<ProfessorResponseDTO> GetProfessorByIdAsync(int id);
        Task<IEnumerable<ProfessorResponseDTO>> GetProfessoresByNomeAsync(string nome);
    }
}