namespace ControleNotas.src.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int DisciplinaId { get; set; }
    }
}