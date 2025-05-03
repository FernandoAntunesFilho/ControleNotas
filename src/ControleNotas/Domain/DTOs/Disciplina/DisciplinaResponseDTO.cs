namespace ControleNotas.src.Domain.DTOs.Disciplina
{
    public class DisciplinaResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int CargaHoraria { get; set; }
    }
}