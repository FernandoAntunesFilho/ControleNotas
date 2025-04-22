using ControleNotas.src.Domain.DTOs.Disciplina;
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

        public async Task AddDisciplinaAsync(DisciplinaRequestDTO disciplina)
        {
            if (disciplina is null ||
                string.IsNullOrWhiteSpace(disciplina.Nome) ||
                disciplina.CargaHoraria <= 0) throw new ArgumentNullException("Os dados da disciplina não podem ser nulos ou vazios.");

            var novaDisciplina = new Disciplina
            {
                Nome = disciplina.Nome,
                CargaHoraria = disciplina.CargaHoraria
            };
            
            await _repository.AddAsync(novaDisciplina);
        }

        public async Task DeleteDisciplinaAsync(int id)
        {
            var disciplina = await _repository.GetByIdAsync(id);
            if (disciplina == null) throw new KeyNotFoundException($"Disciplina com ID {id} não encontrada.");
            await _repository.DeleteAsync(id);
        }

        public async Task UpdateDisciplinaAsync(int id, DisciplinaRequestDTO disciplina)
        {
            var existingDisciplina = await _repository.GetByIdAsync(id);
            if (existingDisciplina == null) throw new KeyNotFoundException($"Disciplina com ID {id} não encontrada.");
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
            if (disciplina == null) throw new KeyNotFoundException($"Disciplina com ID {id} não encontrada.");
            return disciplina;
        }

        public async Task<IEnumerable<Disciplina>> GetDisciplinasByNomeAsync(string nome)
        {
            return await _repository.GetByNomeAsync(nome);
        }
    }
}