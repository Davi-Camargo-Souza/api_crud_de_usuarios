using AutoMapper;
using MediatR;
using SeboScrob.Application.Shared.Exceptions;
using SeboScrob.Application.Shared.Uteis;
using SeboScrob.Domain.Entities;
using SeboScrob.Domain.Interfaces;

namespace SeboScrob.Application.UseCases.User.UpdateUser
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
            var entidadeDesatualizada = _userRepository.Get(request.Id, cancellationToken, "Users");
            if (entidadeDesatualizada.Result == null)
            {
                throw new UserNotFoundException("Não há nenhum usúario vínculado ao id.");
            }

            var consulta = _userRepository.GetByEmail(request.Email, cancellationToken);
            if (consulta.Result != null)
            {
                if (consulta.Result.Id != request.Id)
                {
                    throw new EmailAlreadyExistsException("O email inserido pertence a outro usúario já registrado.");
                }
            }

            var entity = _mapper.Map<UserEntity>(request);
            entity.Id = entidadeDesatualizada.Result.Id;
            entity.DateCreated = entidadeDesatualizada.Result.DateCreated;

            PasswordUtil passwordUtil = new PasswordUtil();
            var hashedPassword = passwordUtil.HashPassword(entity.Senha);
            entity.Senha = hashedPassword;

            _userRepository.Update(entity);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UpdateUserResponse>(entity);
        }
    }
}
