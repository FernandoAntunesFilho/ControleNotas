using ControleNotas.src.Domain.Interfaces;
using ControleNotas.src.Models;

namespace ControleNotas.src.Services
{
    public class NotaService
    {
        private readonly INotaRepository _repository;
        public NotaService(INotaRepository repository)
        {
            _repository = repository;
        }

        public async Task AddNotaAsync(Nota nota)
        {
            await _repository.AddAsync(nota);
        }

        public async Task DeleteNotaAsync(int id)
        {
            var nota = await _repository.GetByIdAsync(id);
            if (nota == null) throw new KeyNotFoundException($"Nota com ID {id} não encontrado.");
            await _repository.DeleteAsync(id);
        }

        public async Task UpdateNotaAsync(Nota nota)
        {
            var existingNota = await _repository.GetByIdAsync(nota.Id);
            if (existingNota == null) throw new KeyNotFoundException($"Nota com ID {nota.Id} não encontrado.");
            existingNota.AlunoId = nota.AlunoId;
            existingNota.DisciplinaId = nota.DisciplinaId;
            existingNota.Nota1 = nota.Nota1;
            existingNota.Nota2 = nota.Nota2;
            await _repository.UpdateAsync(existingNota);
        }

        public async Task<IEnumerable<Nota>> GetNotasAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Nota>> GetNotasByAlunoAsync(int alunoId)
        {
            return await _repository.GetByAlunoAsync(alunoId);
        }

        public async Task<Nota> GetNotaByIdAsync(int id)
        {
            var nota = await _repository.GetByIdAsync(id);
            if (nota == null) throw new KeyNotFoundException($"Nota com ID {id} não encontrado.");
            return nota;
        }
    }
}