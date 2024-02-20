using MediatR;
using SeboScrob.WebAPI.DTOs.Responses.User;

namespace SeboScrob.WebAPI.DTOs.Requests.User
{
    public record CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
    }
}
