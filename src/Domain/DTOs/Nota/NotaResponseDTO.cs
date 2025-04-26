namespace ControleNotas.src.Domain.DTOs.Nota
{
    public class NotaResponseDTO
    {
        public int Id { get; set; }
        public string AlunoNome { get; set; } = string.Empty;
        public string DisciplinaNome { get; set; } = string.Empty;
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Media { get; set; }
        public string Situacao { get; set; } = string.Empty;
    }
}