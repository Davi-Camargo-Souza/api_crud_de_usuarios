using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeboScrob.WebAPI.Shared.Exceptions;
using SeboScrob.WebAPI.DTOs.Requests.Login;
using SeboScrob.WebAPI.DTOs.Responses.Login;

namespace SeboScrob.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginUserResponse>> Login(LoginUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return Ok(response);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (WrongPasswordException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
