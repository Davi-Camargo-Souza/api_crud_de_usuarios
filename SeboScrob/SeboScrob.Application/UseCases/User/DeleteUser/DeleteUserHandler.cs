using MediatR;
using SeboScrob.Application.Shared.Exceptions;
using SeboScrob.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeboScrob.Application.UseCases.User.DeleteUser
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
