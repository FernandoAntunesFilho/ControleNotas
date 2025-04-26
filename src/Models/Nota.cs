namespace ControleNotas.src.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int DisciplinaId { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }

        public Aluno Aluno { get; set; } = null!;
        public Disciplina Disciplina { get; set; } = null!;
    }
}