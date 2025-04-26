using ControleNotas.src.Domain.DTOs.Professor;
using ControleNotas.src.Domain.Interfaces;
using ControleNotas.src.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleNotas.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfessores()
        {
            try
            {
                var professores = await _professorService.GetProfessoresAsync();
                return Ok(professores);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessor(int id)
        {
            try
            {
                var professor = await _professorService.GetProfessorByIdAsync(id);
                return Ok(professor);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("disciplina/{disciplinaId}")]
        public async Task<IActionResult> GetProfessoresByDisciplina(int disciplinaId)
        {
            try
            {
                var professores = await _professorService.GetProfessoresByDisciplinaAsync(disciplinaId);
                return Ok(professores);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetProfessoresByNome(string nome)
        {
            try
            {
                var professores = await _professorService.GetProfessoresByNomeAsync(nome);
                return Ok(professores);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProfessor([FromBody] ProfessorRequestDTO professor)
        {
            try
            {
                await _professorService.AddProfessorAsync(professor);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfessor(int id, [FromBody] ProfessorRequestDTO professor)
        {
            try
            {
                await _professorService.UpdateProfessorAsync(id, professor);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            try
            {
                await _professorService.DeleteProfessorAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}