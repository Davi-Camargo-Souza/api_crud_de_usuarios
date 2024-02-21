using AutoMapper;
using MediatR;
using SeboScrob.Domain.Entities;
using SeboScrob.Domain.Interfaces;
using SeboScrob.WebAPI.DTOs.Requests.User;
using SeboScrob.WebAPI.DTOs.Responses.User;
using SeboScrob.WebAPI.Shared.Exceptions;

namespace SeboScrob.WebAPI.Handlers
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
            var consulta = _userRepository.Get(request.id, cancellationToken, "Users").Result;
            if (consulta == null)
            {
                throw new UserNotFoundException("Usúario não encontrado.");
            }

            var result = _mapper.Map<GetUserResponse>(consulta);

            return result;
        }
    }
}
