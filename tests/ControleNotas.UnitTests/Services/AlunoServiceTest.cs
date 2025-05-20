using ControleNotas.Domain.Interfaces;
using ControleNotas.src.Domain.DTOs.Aluno;
using ControleNotas.src.Models;
using ControleNotas.src.Services;
using ControleNotas.UnitTests.Builders.Aluno;
using Moq;

namespace ControleNotas.UnitTests.Services
{
    public class AlunoServiceTest
    {
        private readonly Mock<IAlunoRepository> _repositoryMock;
        private readonly AlunoRequestDTOBuilder _alunoRequestDTOBuilder;
        private readonly AlunoBuilder _alunoBuilder;

        public AlunoServiceTest()
        {
            _repositoryMock = new Mock<IAlunoRepository>();
            _alunoRequestDTOBuilder = new AlunoRequestDTOBuilder();
            _alunoBuilder = new AlunoBuilder();
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
            var alunoRequestDTO = _alunoRequestDTOBuilder
                .ComNome("Nome Aluno")
                .ComDataNascimento(DateTime.Now.AddYears(-10))
                .ComMatricula("123456")
                .ComTurma("Turma Aluno")
                .Build();
            _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Aluno>()))
                .Returns(Task.CompletedTask);
            var service = new AlunoService(_repositoryMock.Object);

            // Act & Assert
            await service.AddAlunoAsync(alunoRequestDTO);
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
            var aluno = _alunoBuilder
                .ComId(1)
                .ComNome("Nome Aluno")
                .ComDataNascimento(DateTime.Now.AddYears(-10))
                .ComMatricula("123456")
                .ComTurma("Turma Aluno")
                .Build();
            _repositoryMock.Setup(r => r.DeleteAsync(It.IsAny<Aluno>()))
                .Returns(Task.CompletedTask);
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(aluno);
            var service = new AlunoService(_repositoryMock.Object);


            // Act & Assert
            await service.DeleteAlunoAsync(It.IsAny<int>());
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<Aluno>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAlunoAsync_AlunoDTONulo_DeveLancarArgumentNullException()
        {
            // Arrange
            var service = new AlunoService(_repositoryMock.Object);
            var alunoId = 1;
            var alunoInvalido = null as AlunoRequestDTO;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.UpdateAlunoAsync(alunoId, alunoInvalido!));
        }

        [Fact]
        public async Task UpdateAlunoAsync_AlunoNaoExiste_DeveLancarKeyNotFoundException()
        {
            // Arrange
            var alunoRequestDTO = _alunoRequestDTOBuilder
                .ComNome("Nome Aluno")
                .ComDataNascimento(DateTime.Now.AddYears(-10))
                .ComMatricula("123456")
                .ComTurma("Turma Aluno")
                .Build();
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(null as Aluno);
            var service = new AlunoService(_repositoryMock.Object);
            var alunoId = 1;

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => service.UpdateAlunoAsync(alunoId, alunoRequestDTO));
        }

        [Theory]
        [MemberData(nameof(AlunoRequestDTOData))]
        public async Task UpdateAlunoAsync_ComCampoVazio_DeveAtualizarApenasCamposPreenchidos(AlunoRequestDTO alunoRequestDTO, Aluno alunoEsperado)
        {
            // Arrange
            var alunoExistente = _alunoBuilder
                .ComId(1)
                .ComNome("Nome Aluno Existente")
                .ComDataNascimento(DateTime.Now.AddYears(-8))
                .ComMatricula("789654")
                .ComTurma("Turma Aluno Axistente")
                .Build();
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(alunoExistente);
            var service = new AlunoService(_repositoryMock.Object);
            var alunoId = 1;

            // Act
            await service.UpdateAlunoAsync(alunoId, alunoRequestDTO);

            // Assert
            Assert.Equal(alunoExistente.Nome, alunoEsperado.Nome);
            Assert.Equal(alunoExistente.DataNascimento.Date, alunoEsperado.DataNascimento.Date);
            Assert.Equal(alunoExistente.Matricula, alunoEsperado.Matricula);
            Assert.Equal(alunoExistente.Turma, alunoEsperado.Turma);
        }

        [Fact]
        public async Task UpdateAlunoAsync_ComAlunoValido_DeveAtulizarAluno()
        {
            // Arrange
            var aluno = _alunoBuilder
                .ComId(1)
                .ComNome("Nome Aluno")
                .ComDataNascimento(DateTime.Now.AddYears(-10))
                .ComMatricula("123456")
                .ComTurma("Turma Aluno")
                .Build();
            var alunoRequestDTO = _alunoRequestDTOBuilder
                .ComNome("Nome Aluno Atualizado")
                .ComDataNascimento(DateTime.Now.AddYears(-11))
                .ComMatricula("789654")
                .ComTurma("Turma Aluno Atualizada")
                .Build();
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(aluno);
            _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<Aluno>()))
                .Returns(Task.CompletedTask);
            var service = new AlunoService(_repositoryMock.Object);
            var alunoId = 1;


            // Act & Assert
            await service.UpdateAlunoAsync(alunoId, alunoRequestDTO);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Aluno>()), Times.Once);
        }

        [Fact]
        public async Task GetAlunoByIdAsync_AlunoNaoExiste_DeveLancarKeyNotFoundException()
        {
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(null as Aluno);
            var service = new AlunoService(_repositoryMock.Object);
            var alunoId = 1;

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => service.GetAlunoByIdAsync(alunoId));
        }

        [Fact]
        public async Task GetAlunoByIdAsync_AlunoValido_DeveRetornarDTOCorretamente()
        {
            var alunoId = 1;
            var aluno = _alunoBuilder
                .ComId(alunoId)
                .ComNome("Nome Aluno")
                .ComDataNascimento(DateTime.Now.AddYears(-10))
                .ComMatricula("123456")
                .ComTurma("Turma Aluno")
                .Build();
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(aluno);
            var service = new AlunoService(_repositoryMock.Object);

            // Act & Assert
            var response = await service.GetAlunoByIdAsync(alunoId);
            Assert.Equal(response.Id, alunoId);
            Assert.Equal(response.Nome, aluno.Nome);
            Assert.Equal(response.DataNascimento.Date, aluno.DataNascimento.Date);
            Assert.Equal(response.Matricula, aluno.Matricula);
            Assert.Equal(response.Turma, aluno.Turma);
        }

        public static IEnumerable<object[]> AlunoRequestDTOData =>
        new List<object[]>
        {
            new object[]
            {
                new AlunoRequestDTOBuilder()
                    .ComDataNascimento(DateTime.Now.AddYears(-10))
                    .ComMatricula("123456")
                    .ComTurma("Turma Aluno")
                    .Build(),

                new AlunoBuilder()
                    .ComId(1)
                    .ComNome("Nome Aluno Existente")
                    .ComDataNascimento(DateTime.Now.AddYears(-10))
                    .ComMatricula("123456")
                    .ComTurma("Turma Aluno")
                    .Build()
            },
            new object[]
            {
                new AlunoRequestDTOBuilder()
                    .ComNome("Nome Aluno")
                    .ComMatricula("123456")
                    .ComTurma("Turma Aluno")
                    .Build(),

                new AlunoBuilder()
                    .ComId(1)
                    .ComNome("Nome Aluno")
                    .ComDataNascimento(DateTime.Now.AddYears(-8))
                    .ComMatricula("123456")
                    .ComTurma("Turma Aluno")
                    .Build()
            },
            new object[]
            {
                new AlunoRequestDTOBuilder()
                    .ComNome("Nome Aluno")
                    .ComDataNascimento(DateTime.Now.AddYears(-10))
                    .ComTurma("Turma Aluno")
                    .Build(),

                new AlunoBuilder()
                    .ComId(1)
                    .ComNome("Nome Aluno")
                    .ComDataNascimento(DateTime.Now.AddYears(-10))
                    .ComMatricula("789654")
                    .ComTurma("Turma Aluno")
                    .Build()
            },
            new object[]
            {
                new AlunoRequestDTOBuilder()
                    .ComNome("Nome Aluno")
                    .ComDataNascimento(DateTime.Now.AddYears(-10))
                    .ComMatricula("123456")
                    .Build(),

                new AlunoBuilder()
                    .ComId(1)
                    .ComNome("Nome Aluno")
                    .ComDataNascimento(DateTime.Now.AddYears(-10))
                    .ComMatricula("123456")
                    .ComTurma("Turma Aluno Axistente")
                    .Build()
            }
        };
    }
}