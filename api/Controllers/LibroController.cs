using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using services.interfaces;
using models.dto;
using System;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<AddLibroResponse>> AddLibro([FromBody] AddLibroRequest request)
        {
            try
            {
                if (request == null) return BadRequest("Dati non validi");

                var response = await _libroService.AddLibro(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("get/all")]
        public async Task<ActionResult<List<LibroResponse>>> GetAllLibro()
        {
            try
            {
                var response = await _libroService.GetAllLibro();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("get")]
        public async Task<ActionResult<LibroResponse>> GetLibroByTitolo([FromQuery] string titolo)
        {
            try
            {
                var response = await _libroService.GetLibroByTitolo(titolo);
                if (response == null) return NotFound("Libro non trovato");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("edit")]
        public async Task<ActionResult<LibroResponse>> EditLibro([FromBody] EditLibroRequest request)
        {
            try
            {
                if (request == null) return BadRequest("Dati non validi");

                var response = await _libroService.EditLibro(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteLibro([FromRoute] int id)
        {
            try
            {
                _libroService.DeleteLibro(id);
                return Ok("Libro cancellato con successo");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}