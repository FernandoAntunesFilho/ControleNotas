using ControleNotas.Domain.Interfaces;
using ControleNotas.src.Domain.DTOs.Aluno;
using ControleNotas.src.Models;
using ControleNotas.src.Services;
using Moq;

namespace ControleNotas.UnitTests.Services
{
    public class AlunoServiceTest
    {
        private readonly Mock<IAlunoRepository> _repositoryMock;

        public AlunoServiceTest()
        {
            _repositoryMock = new Mock<IAlunoRepository>();
        }

        [Fact]
        public async Task AddAlunoAsync_ComAlunoInvalido_DeveLancarArgumentNullException()
        {
            // Arrange
            var service = new AlunoService(_repositoryMock.Object);
            var alunoInvalido = new AlunoRequestDTO();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddAlunoAsync(alunoInvalido));
        }

        [Fact]
        public async Task AddAlunoAsync_ComAlunoValido_DeveAdicionarAluno()
        {
            // Arrange
            _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Aluno>()))
                .Returns(Task.CompletedTask);
            var service = new AlunoService(_repositoryMock.Object);
            var alunoInvalido = new AlunoRequestDTO(){
                Nome = "Nome Aluno",
                DataNascimento = DateTime.Now.AddYears(-10),
                Matricula = "123456",
                Turma = "Turma Aluno"
            };

            // Act & Assert
            await service.AddAlunoAsync(alunoInvalido);
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Aluno>()), Times.Once);
        }
    }
}