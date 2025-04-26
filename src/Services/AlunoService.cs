using ControleNotas.Domain.Interfaces;
using ControleNotas.src.Domain.DTOs.Aluno;
using ControleNotas.src.Domain.Interfaces;
using ControleNotas.src.Models;

namespace ControleNotas.src.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;
        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAlunoAsync(AlunoRequestDTO aluno)
        {
            if (ValidarAlunoDto(aluno)) throw new ArgumentNullException("Os dados do aluno não podem ser nulos ou vazios.");

            Aluno novoAluno = new Aluno
            {
                Nome = aluno.Nome,
                DataNascimento = aluno.DataNascimento,
                Matricula = aluno.Matricula,
                Turma = aluno.Turma
            };

            await _repository.AddAsync(novoAluno);
        }

        public async Task DeleteAlunoAsync(int id)
        {
            var aluno = await _repository.GetByIdAsync(id);
            if (aluno == null) throw new KeyNotFoundException($"Aluno com ID {id} não encontrado.");
            await _repository.DeleteAsync(aluno);
        }

        public async Task UpdateAlunoAsync(int id, AlunoRequestDTO aluno)
        {
            if (aluno is null) throw new ArgumentNullException(nameof(aluno));

            var existingAluno = await _repository.GetByIdAsync(id);
            if (existingAluno == null) throw new KeyNotFoundException($"Aluno com ID {id} não encontrado.");
            
            existingAluno.Nome = !string.IsNullOrWhiteSpace(aluno.Nome) ? aluno.Nome : existingAluno.Nome;
            existingAluno.Matricula = !string.IsNullOrWhiteSpace(aluno.Matricula) ? aluno.Matricula : existingAluno.Matricula;
            existingAluno.DataNascimento = aluno.DataNascimento != DateTime.MinValue ? aluno.DataNascimento : existingAluno.DataNascimento;
            existingAluno.Turma = !string.IsNullOrWhiteSpace(aluno.Turma) ? aluno.Turma : existingAluno.Turma;
            await _repository.UpdateAsync(existingAluno);
        }

        public async Task<IEnumerable<AlunoResponseDTO>> GetAlunosAsync()
        {
            var alunos = await _repository.GetAllAsync();
            return MapAlunos(alunos);
        }

        public async Task<AlunoResponseDTO> GetAlunoByIdAsync(int id)
        {
            var aluno = await _repository.GetByIdAsync(id);
            if (aluno == null) throw new KeyNotFoundException($"Aluno com ID {id} não encontrado.");
            return MapAluno(aluno);
        }

        public async Task<AlunoResponseDTO> GetAlunoByMatriculaAsync(string matricula)
        {
            var aluno = await _repository.GetByMatriculaAsync(matricula);
            if (aluno == null) throw new KeyNotFoundException($"Aluno com matrícula {matricula} não encontrado.");
            return MapAluno(aluno);
        }

        public async Task<IEnumerable<AlunoResponseDTO>> GetAlunosByNomeAsync(string nome)
        {
            var alunos = await _repository.GetByNomeAsync(nome);
            return MapAlunos(alunos);
        }

        private static bool ValidarAlunoDto(AlunoRequestDTO aluno)
        {
            return aluno == null ||
                            string.IsNullOrWhiteSpace(aluno.Nome) ||
                            aluno.DataNascimento == DateTime.MinValue ||
                            string.IsNullOrWhiteSpace(aluno.Matricula) ||
                            string.IsNullOrWhiteSpace(aluno.Turma);
        }

        private static IEnumerable<AlunoResponseDTO> MapAlunos(IEnumerable<Aluno> alunos)
        {
            return alunos.Select(a => new AlunoResponseDTO
            {
                Id = a.Id,
                Nome = a.Nome,
                DataNascimento = a.DataNascimento,
                Matricula = a.Matricula,
                Turma = a.Turma
            });
        }

        private static AlunoResponseDTO MapAluno(Aluno aluno)
        {
            return new AlunoResponseDTO
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                DataNascimento = aluno.DataNascimento,
                Matricula = aluno.Matricula,
                Turma = aluno.Turma
            };
        }
    }
}