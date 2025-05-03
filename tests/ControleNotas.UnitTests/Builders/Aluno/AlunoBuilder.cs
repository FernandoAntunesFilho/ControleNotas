namespace ControleNotas.UnitTests.Builders.Aluno
{
    public class AlunoBuilder
    {
        private src.Models.Aluno _aluno;

        public AlunoBuilder()
        {
            _aluno = new src.Models.Aluno();
        }

        public AlunoBuilder ComId(int id)
        {
            _aluno.Id = id;
            return this;
        }

        public AlunoBuilder ComNome(string nome)
        {
            _aluno.Nome = nome;
            return this;
        }

        public AlunoBuilder ComDataNascimento(DateTime dataNascimento)
        {
            _aluno.DataNascimento = dataNascimento;
            return this;
        }

        public AlunoBuilder ComMatricula(string matricula)
        {
            _aluno.Matricula = matricula;
            return this;
        }

        public AlunoBuilder ComTurma(string turma)
        {
            _aluno.Turma = turma;
            return this;
        }

        public src.Models.Aluno Build() => _aluno;
    }
}