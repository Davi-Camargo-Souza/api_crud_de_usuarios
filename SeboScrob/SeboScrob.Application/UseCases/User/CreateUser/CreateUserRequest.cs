using MediatR;
using SeboScrob.Application.UseCases.User.Login;
using SeboScrob.Domain.Interfaces;

namespace SeboScrob.Application.UseCases.User.CreateUser
{
    public record CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
    }
}
