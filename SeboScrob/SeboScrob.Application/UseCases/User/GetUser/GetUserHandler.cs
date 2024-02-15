using AutoMapper;
using MediatR;
using SeboScrob.Application.Shared.Exceptions;
using SeboScrob.Application.UseCases.User.UpdateUser;
using SeboScrob.Domain.Entities;
using SeboScrob.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeboScrob.Application.UseCases.User.GetUser
{
    public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;


        public GetUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var consulta = _userRepository.Get(request.id, cancellationToken, "Users");
            if (consulta.Result == null)
            {
                throw new UserNotFoundException("Usúario não encontrado.");
            }

            var result = _mapper.Map<GetUserResponse>(consulta.Result);

            return result;
        }
    }
}
