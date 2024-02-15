using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeboScrob.Application.UseCases.User.GetUser
{
    public record GetUserRequest (string id) : IRequest<GetUserResponse>;
}
