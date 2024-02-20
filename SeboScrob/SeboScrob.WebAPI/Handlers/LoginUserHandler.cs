using AutoMapper;
using MediatR;
using SeboScrob.Domain.Interfaces;
using SeboScrob.WebAPI.DTOs.Requests.Login;
using SeboScrob.WebAPI.DTOs.Responses.Login;
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
            PasswordUtil passwordUtil = new PasswordUtil();
            var hashedPassword = passwordUtil.HashPassword(request.Senha);

            if (passwordUtil.HashPassword(hashedPassword + usuario.DateCreated) == passwordUtil.HashPassword(usuario.Senha + usuario.DateCreated))
            {
                LoginUserResponse response = new LoginUserResponse();
                response.Id = usuario.Id;
                response.IsLoggedIn = true;
                return new LoginUserResponse { Id = usuario.Id, IsLoggedIn = true };
            } else
            {
                throw new WrongPasswordException("Senha incorreta.");
            }
            
        }
    }
}
