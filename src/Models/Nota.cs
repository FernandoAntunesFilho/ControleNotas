namespace ControleNotas.src.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int DisciplinaId { get; set; }
        public int Nota1 { get; set; }
        public int Nota2 { get; set; }
        public int Status { get; set; }
    }
}