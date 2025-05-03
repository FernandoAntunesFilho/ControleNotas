namespace ControleNotas.src.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int CargaHoraria { get; set; }

        public ICollection<Professor> Professores { get; set; } = new List<Professor>();
        public ICollection<Nota> Notas { get; set; } = new List<Nota>();
    }
}