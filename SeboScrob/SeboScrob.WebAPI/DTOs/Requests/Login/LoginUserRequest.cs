using MediatR;
using SeboScrob.WebAPI.DTOs.Responses.Login;

namespace SeboScrob.WebAPI.DTOs.Requests.Login
{
    public record LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
