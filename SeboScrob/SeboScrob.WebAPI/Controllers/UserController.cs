using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeboScrob.WebAPI.DTOs.Requests.User;
using SeboScrob.WebAPI.DTOs.Responses.User;
using SeboScrob.WebAPI.Shared.Exceptions;


namespace SeboScrob.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GetUserResponse>> GetUser(string id, CancellationToken cancellationToken)
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
        [AllowAnonymous]
        public async Task<ActionResult<CreateUserResponse>> CreateUser (CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createdUser = await _mediator.Send(request, cancellationToken);
                return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
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

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<UpdateUserResponse>> UpdateUser (string id, UpdateUserRequest request, CancellationToken cancellationToken)
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
        [Authorize]
        public async Task<ActionResult> DeleteUser (string id, CancellationToken cancellationToken)
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
