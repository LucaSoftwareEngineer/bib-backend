using Microsoft.AspNetCore.Authorization;
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
        private readonly IConfiguration _configuration;

        public UtenteController(UtenteService utenteService, IConfiguration configuration)
        {
            this._utenteService = utenteService;
            this._configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterUtenteResponse>> RegisterUtente([FromBody] RegisterUtenteRequest request)
        {
            try
            {
                var jwtKey = _configuration["jwtKey"];
                var response = await _utenteService.RegisterUtente(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginUtente([FromBody] LoginRequest request)
        {
            try
            {
                var jwtKey = _configuration["jwtKey"];
                var response = await _utenteService.LoginUtente(request, jwtKey);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
