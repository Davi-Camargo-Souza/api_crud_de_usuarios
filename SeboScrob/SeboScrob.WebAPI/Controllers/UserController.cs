using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeboScrob.Application.Shared.Exceptions;
using SeboScrob.Application.UseCases.User.CreateUser;
using SeboScrob.Application.UseCases.User.DeleteUser;
using SeboScrob.Application.UseCases.User.GetUser;
using SeboScrob.Application.UseCases.User.Login;
using SeboScrob.Application.UseCases.User.UpdateUser;

namespace SeboScrob.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserResponse>> Get(string id, CancellationToken cancellationToken)
        {
            GetUserRequest request = new GetUserRequest(id);
            try
            {
                var response = await _mediator.Send(request);
                return response;

            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }            
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> CreateUser (CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return Ok(response);
            }
            catch(EmailAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginUserResponse>> Login (LoginUserRequest request, CancellationToken cancellationToken)
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

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateUserResponse>> Update (string id, UpdateUserRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;

            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return Ok(response);
            }
            catch(EmailAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (string id, CancellationToken cancellationToken)
        {
            DeleteUserRequest request = new DeleteUserRequest(id);
            try
            {
                var result = await _mediator.Send(request);
                return NoContent();
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
