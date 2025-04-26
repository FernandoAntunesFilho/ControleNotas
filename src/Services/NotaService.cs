using ControleNotas.Domain.Interfaces;
using ControleNotas.src.Domain.DTOs.Nota;
using ControleNotas.src.Domain.Interfaces;
using ControleNotas.src.Models;

namespace ControleNotas.src.Services
{
    public class NotaService : INotaService
    {
        private readonly INotaRepository _notaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        public NotaService(INotaRepository notaRepository, IAlunoRepository alunoRepository, IDisciplinaRepository disciplinaRepository)
        {
            _notaRepository = notaRepository;
            _alunoRepository = alunoRepository;
            _disciplinaRepository = disciplinaRepository;
        }

        public async Task AddNotaAsync(NotaRequestDTO nota)
        {
            Nota novaNota = new()
            {
                AlunoId = nota.AlunoId,
                DisciplinaId = nota.DisciplinaId,
                Nota1 = nota.Nota1,
                Nota2 = nota.Nota2
            };

            await _notaRepository.AddAsync(novaNota);
        }

        public async Task DeleteNotaAsync(int id)
        {
            var nota = await _notaRepository.GetByIdAsync(id);
            if (nota == null) throw new KeyNotFoundException($"Nota com ID {id} não encontrada.");
            await _notaRepository.DeleteAsync(id);
        }

        public async Task UpdateNotaAsync(int id, NotaRequestDTO nota)
        {
            var existingNota = await _notaRepository.GetByIdAsync(id);
            if (existingNota == null) throw new KeyNotFoundException($"Nota com ID {id} não encontrada.");

            existingNota.AlunoId = nota.AlunoId;
            existingNota.DisciplinaId = nota.DisciplinaId;
            existingNota.Nota1 = nota.Nota1;
            existingNota.Nota2 = nota.Nota2;
            
            await _notaRepository.UpdateAsync(existingNota);
        }

        public async Task<IEnumerable<NotaResponseDTO>> GetNotasAsync()
        {
            var notas = await _notaRepository.GetAllAsync();
            var alunos = await _alunoRepository.GetAllAsync();
            var disciplinas = await _disciplinaRepository.GetAllAsync();
            IEnumerable<NotaResponseDTO> notasResponse = MapNotas(notas, alunos, disciplinas);

            return notasResponse;
        }

        public async Task<IEnumerable<NotaResponseDTO>> GetNotasByAlunoAsync(int alunoId)
        {
            var notas = await _notaRepository.GetByAlunoAsync(alunoId);
            var alunos = await _alunoRepository.GetAllAsync();
            var disciplinas = await _disciplinaRepository.GetAllAsync();
            IEnumerable<NotaResponseDTO> notasResponse = MapNotas(notas, alunos, disciplinas);

            return notasResponse;
        }

        public async Task<NotaResponseDTO> GetNotaByIdAsync(int id)
        {
            var nota = await _notaRepository.GetByIdAsync(id);
            if (nota == null) throw new KeyNotFoundException($"Nota com ID {id} não encontrada.");

            var notaResponse = new NotaResponseDTO
            {
                Id = nota.Id,
                AlunoNome = (await _alunoRepository.GetByIdAsync(nota.AlunoId))!.Nome,
                DisciplinaNome = (await _disciplinaRepository.GetByIdAsync(nota.DisciplinaId))!.Nome,
                Nota1 = nota.Nota1,
                Nota2 = nota.Nota2,
                Media = (nota.Nota1 + nota.Nota2) / 2,
                Situacao = CalculaSituacao(nota.Nota1, nota.Nota2)
            };

            return notaResponse;
        }

        private static string CalculaSituacao(double nota1, double nota2)
        {
            return (nota1 + nota2) / 2 >= 7 ? "Aprovado" : "Reprovado";
        }

        private static IEnumerable<NotaResponseDTO> MapNotas(IEnumerable<Nota> notas, IEnumerable<Aluno> alunos, IEnumerable<Disciplina> disciplinas)
        {
            return notas.Select(n => new NotaResponseDTO
            {
                Id = n.Id,
                AlunoNome = alunos.FirstOrDefault(a => a.Id == n.AlunoId)!.Nome,
                DisciplinaNome = disciplinas.FirstOrDefault(d => d.Id == n.DisciplinaId)!.Nome,
                Nota1 = n.Nota1,
                Nota2 = n.Nota2,
                Media = (n.Nota1 + n.Nota2) / 2,
                Situacao = CalculaSituacao(n.Nota1, n.Nota2)
            });
        }
    }
}