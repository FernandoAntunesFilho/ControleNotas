using ControleNotas.src.Domain.Interfaces;
using ControleNotas.src.Models;

namespace ControleNotas.src.Services
{
    public class DisciplinaService
    {
        private readonly IDisciplinaRepository _repository;
        public DisciplinaService(IDisciplinaRepository repository)
        {
            _repository = repository;
        }

        public async Task AddDisciplinaAsync(Disciplina disciplina)
        {
            await _repository.AddAsync(disciplina);
        }

        public async Task DeleteDisciplinaAsync(int id)
        {
            var disciplina = await _repository.GetByIdAsync(id);
            if (disciplina == null) throw new KeyNotFoundException($"Disciplina com ID {id} não encontrado.");
            await _repository.DeleteAsync(id);
        }

        public async Task UpdateDisciplinaAsync(Disciplina disciplina)
        {
            var existingDisciplina = await _repository.GetByIdAsync(disciplina.Id);
            if (existingDisciplina == null) throw new KeyNotFoundException($"Disciplina com ID {disciplina.Id} não encontrado.");
            existingDisciplina.Nome = disciplina.Nome;
            existingDisciplina.CargaHoraria = disciplina.CargaHoraria;
            await _repository.UpdateAsync(existingDisciplina);
        }

        public async Task<IEnumerable<Disciplina>> GetDisciplinasAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Disciplina> GetDisciplinaByIdAsync(int id)
        {
            var disciplina = await _repository.GetByIdAsync(id);
            if (disciplina == null) throw new KeyNotFoundException($"Disciplina com ID {id} não encontrado.");
            return disciplina;
        }

        public async Task<IEnumerable<Disciplina>> GetDisciplinasByNomeAsync(string nome)
        {
            return await _repository.GetByNomeAsync(nome);
        }
    }
}