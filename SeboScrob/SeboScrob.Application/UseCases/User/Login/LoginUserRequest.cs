using MediatR;

namespace SeboScrob.Application.UseCases.User.Login
{
    public record LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
