using ControleNotas.src.Domain.DTOs.Professor;
using ControleNotas.src.Domain.Interfaces;
using ControleNotas.src.Models;

namespace ControleNotas.src.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        public ProfessorService(IProfessorRepository professorRepository, IDisciplinaRepository disciplinaRepository)
        {
            _professorRepository = professorRepository;
            _disciplinaRepository = disciplinaRepository;
        }

        public async Task AddProfessorAsync(ProfessorRequestDTO professor)
        {
            var novoProfessor = new Professor
            {
                Nome = professor.Nome,
                DisciplinaId = professor.DisciplinaId
            };

            await _professorRepository.AddAsync(novoProfessor);
        }

        public async Task DeleteProfessorAsync(int id)
        {
            var professor = await _professorRepository.GetByIdAsync(id);
            if (professor == null) throw new KeyNotFoundException($"Professor com ID {id} não encontrado.");
            await _professorRepository.DeleteAsync(id);
        }

        public async Task UpdateProfessorAsync(int id, ProfessorRequestDTO professor)
        {
            var existingProfessor = await _professorRepository.GetByIdAsync(id);
            if (existingProfessor == null) throw new KeyNotFoundException($"Professor com ID {id} não encontrado.");

            existingProfessor.Nome = professor.Nome;
            existingProfessor.DisciplinaId = professor.DisciplinaId;
            await _professorRepository.UpdateAsync(existingProfessor);
        }

        public async Task<IEnumerable<ProfessorResponseDTO>> GetProfessoresAsync()
        {
            var professores = await _professorRepository.GetAllAsync();
            var disciplinas = await _disciplinaRepository.GetAllAsync();
            return MapProfessores(professores, disciplinas);
        }

        public async Task<IEnumerable<ProfessorResponseDTO>> GetProfessoresByDisciplinaAsync(int disciplinaId)
        {
            var professores = await _professorRepository.GetByDisciplinaAsync(disciplinaId);
            var disciplinas = await _disciplinaRepository.GetAllAsync();

            return MapProfessores(professores, disciplinas);
        }

        public async Task<ProfessorResponseDTO> GetProfessorByIdAsync(int id)
        {
            var professor = await _professorRepository.GetByIdAsync(id);
            if (professor == null) throw new KeyNotFoundException($"Professor com ID {id} não encontrado.");
            return new ProfessorResponseDTO
            {
                Id = professor.Id,
                Nome = professor.Nome,
                DisciplinaId = professor.DisciplinaId,
                DisciplinaNome = (await _disciplinaRepository.GetByIdAsync(professor.DisciplinaId))?.Nome ?? string.Empty
            };
        }

        public async Task<IEnumerable<ProfessorResponseDTO>> GetProfessoresByNomeAsync(string nome)
        {
            var professores = await _professorRepository.GetByNomeAsync(nome);
            var disciplinas = await _disciplinaRepository.GetAllAsync();
            return MapProfessores(professores, disciplinas);
        }

        private static IEnumerable<ProfessorResponseDTO> MapProfessores(IEnumerable<Professor> professores, IEnumerable<Disciplina> disciplinas)
        {
            return professores.Select(p => new ProfessorResponseDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                DisciplinaId = p.DisciplinaId,
                DisciplinaNome = disciplinas.FirstOrDefault(d => d.Id == p.DisciplinaId)?.Nome ?? string.Empty
            });
        }
    }
}