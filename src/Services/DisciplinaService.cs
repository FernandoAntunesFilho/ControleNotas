using ControleNotas.src.Domain.DTOs.Disciplina;
using ControleNotas.src.Domain.Interfaces;
using ControleNotas.src.Models;

namespace ControleNotas.src.Services
{
    public class DisciplinaService : IDisciplinaService
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

        public async Task<IEnumerable<DisciplinaResponseDTO>> GetDisciplinasAsync()
        {
            var disciplinas = await _repository.GetAllAsync();
            return MapDisciplinas(disciplinas);
        }

        public async Task<DisciplinaResponseDTO> GetDisciplinaByIdAsync(int id)
        {
            var disciplina = await _repository.GetByIdAsync(id);
            if (disciplina == null) throw new KeyNotFoundException($"Disciplina com ID {id} não encontrada.");
            return new DisciplinaResponseDTO
            {
                Id = disciplina.Id,
                Nome = disciplina.Nome,
                CargaHoraria = disciplina.CargaHoraria
            };
        }

        public async Task<IEnumerable<DisciplinaResponseDTO>> GetDisciplinasByNomeAsync(string nome)
        {
            var disciplinas = await _repository.GetByNomeAsync(nome);
            return MapDisciplinas(disciplinas);
        }

        private static IEnumerable<DisciplinaResponseDTO> MapDisciplinas(IEnumerable<Disciplina> disciplinas)
        {
            return disciplinas.Select(d => new DisciplinaResponseDTO
            {
                Id = d.Id,
                Nome = d.Nome,
                CargaHoraria = d.CargaHoraria
            });
        }
    }
}