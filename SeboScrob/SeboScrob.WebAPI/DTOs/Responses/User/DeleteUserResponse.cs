using SeboScrob.WebAPI.DTOs.Requests.User;

namespace SeboScrob.WebAPI.DTOs.Responses.User
{
    public record DeleteUserResponse
    {
        public bool Success { get; set; }
    }
}
