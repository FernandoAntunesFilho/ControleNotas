namespace ControleNotas.src.Domain.DTOs.Professor
{
    public class ProfessorRequestDTO
    {
        public string Nome { get; set; } = string.Empty;
        public int DisciplinaId { get; set; }
    }
}