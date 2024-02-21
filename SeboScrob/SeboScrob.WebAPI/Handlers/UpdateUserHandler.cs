using AutoMapper;
using MediatR;
using SeboScrob.Domain.Entities;
using SeboScrob.Domain.Interfaces;
using SeboScrob.WebAPI.DTOs.Requests.User;
using SeboScrob.WebAPI.DTOs.Responses.User;
using SeboScrob.WebAPI.Shared.Exceptions;
using SeboScrob.WebAPI.Shared.Uteis;

namespace SeboScrob.WebAPI.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public UpdateUserHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var entidadeDesatualizada = _userRepository.Get(request.Id, cancellationToken, "Users").Result;
            if (entidadeDesatualizada == null)
            {
                throw new UserNotFoundException("Não há nenhum usúario vínculado ao id.");
            }

            var consulta = _userRepository.GetByEmail(request.Email, cancellationToken).Result;
            if (consulta != null)
            {
                if (consulta.Id != request.Id)
                {
                    throw new EmailAlreadyExistsException("O email inserido pertence a outro usúario já registrado.");
                }
            }

            var entity = _mapper.Map<UserEntity>(request);
            entity.Id = entidadeDesatualizada.Id;
            entity.DateCreated = entidadeDesatualizada.DateCreated;

            var hashedPassword = PasswordUtil.HashPassword(entity.Senha);
            entity.Senha = hashedPassword;

            _userRepository.Update(entity);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UpdateUserResponse>(entity);
        }
    }
}
