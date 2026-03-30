using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.dto;
using services;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtenteController : ControllerBase
    {
        private readonly UtenteService _utenteService;

        public UtenteController(UtenteService utenteService)
        {
            this._utenteService = utenteService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterUtenteResponse>> RegisterUtente([FromBody] RegisterUtenteRequest request)
        {
            try
            {
                var response = await _utenteService.RegisterUtente(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
