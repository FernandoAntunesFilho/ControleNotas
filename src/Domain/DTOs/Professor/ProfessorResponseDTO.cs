namespace ControleNotas.src.Domain.DTOs.Professor
{
    public class ProfessorResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int DisciplinaId { get; set; }
        public string DisciplinaNome { get; set; } = string.Empty;
    }
}