using MediatR;
using SeboScrob.WebAPI.DTOs.Responses.User;

namespace SeboScrob.WebAPI.DTOs.Requests.User
{
    public record GetUserRequest (string id) : IRequest<GetUserResponse>;
}
