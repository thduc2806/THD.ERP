using MediatR;
using Microsoft.AspNetCore.Mvc;
using THD.ERP.App.Commands.Authen;

namespace THD.ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok(new
                {
                    Token = response.Token,
                    RefreshToken = response.RefreshToken
                });
            }

            return Unauthorized(new
            {
                Error = response.ErrorMessage
            });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequestCommand request)
        {
            var response = await _mediator.Send(request);
            if (response.Success)
            {
                return Ok(new { Token = response.Token, RefreshToken = response.RefreshToken });
            }
            else
            {
                return Unauthorized(new { Error = response.ErrorMessage });
            }
        }
    }
}
