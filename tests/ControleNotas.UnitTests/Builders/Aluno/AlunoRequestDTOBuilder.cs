using ControleNotas.src.Domain.DTOs.Aluno;

namespace ControleNotas.UnitTests.Builders.Aluno
{
    public class AlunoRequestDTOBuilder
    {
        private AlunoRequestDTO _alunoRequestDTO;

        public AlunoRequestDTOBuilder()
        {
            _alunoRequestDTO = new AlunoRequestDTO();
        }

        public AlunoRequestDTOBuilder ComNome(string nome)
        {
            _alunoRequestDTO.Nome = nome;
            return this;
        }

        public AlunoRequestDTOBuilder ComDataNascimento(DateTime dataNascimento)
        {
            _alunoRequestDTO.DataNascimento = dataNascimento;
            return this;
        }
        
        public AlunoRequestDTOBuilder ComMatricula(string matricula)
        {
            _alunoRequestDTO.Matricula = matricula;
            return this;
        }

        public AlunoRequestDTOBuilder ComTurma(string turma)
        {
            _alunoRequestDTO.Turma = turma;
            return this;
        }

        public AlunoRequestDTO Build() => _alunoRequestDTO;
    }
}