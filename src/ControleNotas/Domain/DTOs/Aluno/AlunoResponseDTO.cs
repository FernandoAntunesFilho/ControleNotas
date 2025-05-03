namespace ControleNotas.src.Domain.DTOs.Aluno
{
    public class AlunoResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Matricula { get; set; } = string.Empty;
        public string Turma { get; set; } = string.Empty;
    }
}