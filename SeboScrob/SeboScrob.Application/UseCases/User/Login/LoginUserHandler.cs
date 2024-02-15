using MediatR;
using SeboScrob.Application.Shared.Exceptions;
using SeboScrob.Application.Shared.Uteis;
using SeboScrob.Domain.Interfaces;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SeboScrob.Application.UseCases.User.Login
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
