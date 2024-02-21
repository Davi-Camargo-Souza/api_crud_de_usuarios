using AutoMapper;
using MediatR;
using SeboScrob.Domain.Interfaces;
using SeboScrob.WebAPI.DTOs.Requests.Login;
using SeboScrob.WebAPI.DTOs.Responses.Login;
using SeboScrob.WebAPI.Services;
using SeboScrob.WebAPI.Shared.Exceptions;
using SeboScrob.WebAPI.Shared.Uteis;

namespace SeboScrob.WebAPI.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        public readonly IUserRepository _userRepository;
        public LoginUserHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var usuario = _userRepository.GetByEmail(request.Email, cancellationToken).Result;
            if (usuario == null)
            {
                throw new UserNotFoundException("Usúario não encontrado.");
            }

            var hashedPassword = PasswordUtil.HashPassword(request.Senha);

            if (PasswordUtil.HashPassword(hashedPassword + usuario.DateCreated) == PasswordUtil.HashPassword(usuario.Senha + usuario.DateCreated))
            {
                return new LoginUserResponse { User = usuario, Token = TokenService.Generate(usuario)};
            } else
            {
                throw new WrongPasswordException("Senha incorreta.");
            }
            
        }
    }
}
