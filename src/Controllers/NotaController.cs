using ControleNotas.src.Domain.DTOs.Nota;
using ControleNotas.src.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleNotas.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : ControllerBase
    {
        private readonly NotaService _notaService;
        public NotaController(NotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotas()
        {
            try
            {
                var notas = await _notaService.GetNotasAsync();
                return Ok(notas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("aluno/{alunoId}")]
        public async Task<IActionResult> GetNotasByAlunoId(int alunoId)
        {
            try
            {
                var notas = await _notaService.GetNotasByAlunoAsync(alunoId);
                return Ok(notas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNota(int id)
        {
            try
            {
                var nota = await _notaService.GetNotaByIdAsync(id);
                return Ok(nota);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNota([FromBody] NotaRequestDTO nota)
        {
            try
            {
                await _notaService.AddNotaAsync(nota);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNota(int id, [FromBody] NotaRequestDTO nota)
        {
            try
            {
                await _notaService.UpdateNotaAsync(id, nota);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNota(int id)
        {
            try
            {
                await _notaService.DeleteNotaAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}