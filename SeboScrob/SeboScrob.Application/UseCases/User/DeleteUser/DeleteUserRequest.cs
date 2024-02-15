using MediatR;
using SeboScrob.Application.UseCases.User.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeboScrob.Application.UseCases.User.DeleteUser
{
    public record DeleteUserRequest(string id) : IRequest<DeleteUserResponse>
    {
    }
}
