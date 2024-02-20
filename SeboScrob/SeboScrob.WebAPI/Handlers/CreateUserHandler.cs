﻿using AutoMapper;
using MediatR;
using SeboScrob.Domain.Entities;
using SeboScrob.Domain.Interfaces;
using SeboScrob.WebAPI.DTOs.Requests.User;
using SeboScrob.WebAPI.DTOs.Responses.User;
using SeboScrob.WebAPI.Shared.Exceptions;
using SeboScrob.WebAPI.Shared.Uteis;

namespace SeboScrob.WebAPI.Handlers
{
    internal class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        public readonly IMapper _mapper;
        public readonly IUserRepository _userRepository;
        public readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IMapper mapper, IUserRepository userRepository, IUnitOfWork unitOfWork) 
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var consulta = _userRepository.GetByEmail(request.Email, cancellationToken);
            if (consulta.Result != null)
            {
                throw new EmailAlreadyExistsException("O email já está registrado.");
            }

            var entity = _mapper.Map<UserEntity>(request);
            entity.Id = Guid.NewGuid().ToString();

            PasswordUtil passwordUtil = new PasswordUtil();
            entity.Senha = passwordUtil.HashPassword(entity.Senha);

            _userRepository.Create(entity);
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<CreateUserResponse>(entity);
        }
    }
}
