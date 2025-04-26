using ControleNotas.src.Domain.DTOs.Aluno;
using ControleNotas.src.Models;

namespace ControleNotas.src.Domain.Interfaces
{
    public interface IAlunoService
    {
        Task AddAlunoAsync(AlunoRequestDTO aluno);
        Task DeleteAlunoAsync(int id);
        Task UpdateAlunoAsync(int id, AlunoRequestDTO aluno);
        Task<IEnumerable<Aluno>> GetAlunosAsync();
        Task<Aluno> GetAlunoByIdAsync(int id);
        Task<Aluno> GetAlunoByMatriculaAsync(string matricula);
        Task<IEnumerable<Aluno>> GetAlunosByNomeAsync(string nome);
    }
}