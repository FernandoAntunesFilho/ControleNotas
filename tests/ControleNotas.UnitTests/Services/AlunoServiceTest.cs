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
            var Aluno = new AlunoRequestDTO(){
                Nome = "Nome Aluno",
                DataNascimento = DateTime.Now.AddYears(-10),
                Matricula = "123456",
                Turma = "Turma Aluno"
            };

            // Act & Assert
            await service.AddAlunoAsync(Aluno);
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Aluno>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAlunoAsync_AlunoNaoExiste_DeveLancarKeyNotFoundException()
        {
            // Arrange
            var service = new AlunoService(_repositoryMock.Object);
            var alunoId = 1;
            
            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => service.DeleteAlunoAsync(alunoId));
        }

        [Fact]
        public async Task DeleteAlunoAsync_ComAlunoValido_DeveDeletarAluno()
        {
            // Arrange
            var Aluno = new Aluno(){
                Id = 1,
                Nome = "Nome Aluno",
                DataNascimento = DateTime.Now.AddYears(-10),
                Matricula = "123456",
                Turma = "Turma Aluno"
            };
            _repositoryMock.Setup(r => r.DeleteAsync(It.IsAny<Aluno>()))
                .Returns(Task.CompletedTask);
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(Aluno);
            var service = new AlunoService(_repositoryMock.Object);
            

            // Act & Assert
            await service.DeleteAlunoAsync(It.IsAny<int>());
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<Aluno>()), Times.Once);
        }
    }
}