namespace ControleNotas.src.DTOs.Aluno
{
    public class AlunoRequestDTO
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Matricula { get; set; } = string.Empty;
        public string Turma { get; set; } = string.Empty;
    }
}