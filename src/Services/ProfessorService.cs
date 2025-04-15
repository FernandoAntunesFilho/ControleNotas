using ControleNotas.src.Domain.Interfaces;
using ControleNotas.src.Models;

namespace ControleNotas.src.Services
{
    public class ProfessorService
    {
        private readonly IProfessorRepository _repository;
        public ProfessorService(IProfessorRepository repository)
        {
            _repository = repository;
        }

        public async Task AddProfessorAsync(Professor professor)
        {
            await _repository.AddAsync(professor);
        }

        public async Task DeleteProfessorAsync(int id)
        {
            var professor = await _repository.GetByIdAsync(id);
            if (professor == null) throw new KeyNotFoundException($"Professor com ID {id} não encontrado.");
            await _repository.DeleteAsync(id);
        }

        public async Task UpdateProfessorAsync(Professor professor)
        {
            var existingProfessor = await _repository.GetByIdAsync(professor.Id);
            if (existingProfessor == null) throw new KeyNotFoundException($"Professor com ID {professor.Id} não encontrado.");
            existingProfessor.Nome = professor.Nome;
            existingProfessor.DisciplinaId = professor.DisciplinaId;
            await _repository.UpdateAsync(existingProfessor);
        }

        public async Task<IEnumerable<Professor>> GetProfessoresAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Professor>> GetProfessoresByDisciplinaAsync(int disciplinaId)
        {
            return await _repository.GetByDisciplinaAsync(disciplinaId);
        }

        public async Task<Professor> GetProfessorByIdAsync(int id)
        {
            var professor = await _repository.GetByIdAsync(id);
            if (professor == null) throw new KeyNotFoundException($"Professor com ID {id} não encontrado.");
            return professor;
        }

        public async Task<IEnumerable<Professor>> GetProfessoresByNomeAsync(string nome)
        {
            return await _repository.GetByNomeAsync(nome);
        }
    }
}