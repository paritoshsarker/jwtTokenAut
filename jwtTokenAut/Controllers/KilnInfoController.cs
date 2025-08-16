using jwtTokenAut.Models;
using jwtTokenAut.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwtTokenAut.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class KilnInfoController : ControllerBase
    {
        private readonly IKilnInfoServices _kilnService;
        private readonly ILogger<KilnInfoController> _logger;

        public KilnInfoController(IKilnInfoServices kilnService, ILogger<KilnInfoController> logger)
        {
            _kilnService = kilnService;
            _logger = logger;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpPost]
        [Route("KilnPostData")]

        public async Task<IActionResult> KilnPostData(KilnInfo model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var (status, message) = await _kilnService.kilnPostData(model, UserRoles.Admin);
                if (status == 0)
                {
                    return BadRequest(message);
                }
                return CreatedAtAction(nameof(KilnPostData), model);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
