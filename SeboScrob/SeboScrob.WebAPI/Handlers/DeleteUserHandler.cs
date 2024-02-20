using AutoMapper;
using MediatR;
using SeboScrob.Domain.Entities;
using SeboScrob.Domain.Interfaces;
using SeboScrob.WebAPI.DTOs.Requests.User;
using SeboScrob.WebAPI.DTOs.Responses.User;
using SeboScrob.WebAPI.Shared.Exceptions;

namespace SeboScrob.WebAPI.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        public readonly IUserRepository _userRepository;
        public readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var entity = _userRepository.Get(request.id, cancellationToken, "Users").Result;
            if (entity == null )
            {
                throw new UserNotFoundException("Usúario não encontrado.");
            }
            _userRepository.Delete(entity);
            await _unitOfWork.Commit(cancellationToken);

            DeleteUserResponse response = new DeleteUserResponse() { Success = true };
            return response;

        }
    }
}
