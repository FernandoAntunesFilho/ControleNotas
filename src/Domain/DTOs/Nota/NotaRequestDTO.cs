namespace ControleNotas.src.Domain.DTOs.Nota
{
    public class NotaRequestDTO
    {
        public int AlunoId { get; set; }
        public int DisciplinaId { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
    }
}