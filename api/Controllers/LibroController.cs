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
    }
}