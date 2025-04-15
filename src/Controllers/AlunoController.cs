using ControleNotas.src.DTOs.Aluno;
using ControleNotas.src.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleNotas.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _alunoService;
        public AlunoController(AlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlunos()
        {
            try
            {
                var alunos = await _alunoService.GetAlunosAsync();
                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAluno(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAlunoByIdAsync(id);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("matricula/{matricula}")]
        public async Task<IActionResult> GetAlunoByMatricula(string matricula)
        {
            try
            {
                var aluno = await _alunoService.GetAlunoByMatriculaAsync(matricula);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetAlunosByNome(string nome)
        {
            try
            {
                var alunos = await _alunoService.GetAlunosByNomeAsync(nome);
                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAluno([FromBody] AlunoRequestDTO request)
        {
            try
            {
                await _alunoService.AddAlunoAsync(request);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAluno(int id, [FromBody] AlunoRequestDTO aluno)
        {
            try
            {
                await _alunoService.UpdateAlunoAsync(id, aluno);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            try
            {
                await _alunoService.DeleteAlunoAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}