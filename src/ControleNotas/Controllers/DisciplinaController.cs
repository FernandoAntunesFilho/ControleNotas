using ControleNotas.src.Domain.DTOs.Disciplina;
using ControleNotas.src.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleNotas.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaService _disciplinaService;
        public DisciplinaController(IDisciplinaService disciplinaService)
        {
            _disciplinaService = disciplinaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDisciplinas()
        {
            try
            {
                var disciplinas = await _disciplinaService.GetDisciplinasAsync();
                return Ok(disciplinas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDisciplina(int id)
        {
            try
            {
                var disciplina = await _disciplinaService.GetDisciplinaByIdAsync(id);
                return Ok(disciplina);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetDisciplinasByNome(string nome)
        {
            try
            {
                var disciplinas = await _disciplinaService.GetDisciplinasByNomeAsync(nome);
                return Ok(disciplinas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddDisciplina([FromBody] DisciplinaRequestDTO request)
        {
            try
            {
                await _disciplinaService.AddDisciplinaAsync(request);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDisciplina(int id, [FromBody] DisciplinaRequestDTO request)
        {
            try
            {
                await _disciplinaService.UpdateDisciplinaAsync(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisciplina(int id)
        {
            try
            {
                await _disciplinaService.DeleteDisciplinaAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}