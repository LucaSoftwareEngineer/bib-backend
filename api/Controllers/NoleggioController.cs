using Microsoft.AspNetCore.Mvc;
using models.dto;
using services;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoleggioController : ControllerBase
    {

        private readonly NoleggioService _noleggioService;

        public NoleggioController(NoleggioService noleggioService)
        {
            this._noleggioService = noleggioService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<AddNoleggioResponse>> AddNoleggio([FromBody] AddNoleggioRequest noleggio)
        {
            try {
                var response = await _noleggioService.AddNoleggio(noleggio);
                return Ok(response);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

    }
}
