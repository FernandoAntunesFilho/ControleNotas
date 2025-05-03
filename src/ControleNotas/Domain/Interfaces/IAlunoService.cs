using ControleNotas.src.Domain.DTOs.Aluno;
using ControleNotas.src.Models;

namespace ControleNotas.src.Domain.Interfaces
{
    public interface IAlunoService
    {
        Task AddAlunoAsync(AlunoRequestDTO aluno);
        Task DeleteAlunoAsync(int id);
        Task UpdateAlunoAsync(int id, AlunoRequestDTO aluno);
        Task<IEnumerable<AlunoResponseDTO>> GetAlunosAsync();
        Task<AlunoResponseDTO> GetAlunoByIdAsync(int id);
        Task<AlunoResponseDTO> GetAlunoByMatriculaAsync(string matricula);
        Task<IEnumerable<AlunoResponseDTO>> GetAlunosByNomeAsync(string nome);
    }
}