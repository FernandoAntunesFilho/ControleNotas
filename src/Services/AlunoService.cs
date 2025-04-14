using ControleNotas.Domain.Interfaces;
using ControleNotas.src.Models;

namespace ControleNotas.src.Services
{
    public class AlunoService
    {
        private readonly IAlunoRepository _repository;
        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAlunoAsync(Aluno aluno)
        {
            if (aluno == null) throw new ArgumentNullException(nameof(aluno));
            await _repository.AddAsync(aluno);
        }

        public async Task DeleteAlunoAsync(int id)
        {
            var aluno = await _repository.GetByIdAsync(id);
            if (aluno == null) throw new KeyNotFoundException($"Aluno com ID {id} não encontrado.");
            await _repository.DeleteAsync(id);
        }

        public async Task UpdateAlunoAsync(Aluno aluno)
        {
            if (aluno == null) throw new ArgumentNullException(nameof(aluno));
            var existingAluno = await _repository.GetByIdAsync(aluno.Id);
            if (existingAluno == null) throw new KeyNotFoundException($"Aluno com ID {aluno.Id} não encontrado.");
            existingAluno.Nome = aluno.Nome;
            existingAluno.Matricula = aluno.Matricula;
            existingAluno.DataNascimento = aluno.DataNascimento;
            existingAluno.Turma = aluno.Turma;
            await _repository.UpdateAsync(existingAluno);
        }

        public async Task<IEnumerable<Aluno>> GetAlunosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Aluno> GetAlunoByIdAsync(int id)
        {
            var aluno = await _repository.GetByIdAsync(id);
            if (aluno == null) throw new KeyNotFoundException($"Aluno com ID {id} não encontrado.");
            return aluno;
        }

        public async Task<Aluno> GetAlunoByMatriculaAsync(string matricula)
        {
            var aluno = await _repository.GetByMatriculaAsync(matricula);
            if (aluno == null) throw new KeyNotFoundException($"Aluno com matrícula {matricula} não encontrado.");
            return aluno;
        }

        public async Task<IEnumerable<Aluno>> GetAlunosByNomeAsync(string nome)
        {
            return await _repository.GetByNomeAsync(nome);
        }
    }
}