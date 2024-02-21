using SeboScrob.Domain.Entities;

namespace SeboScrob.WebAPI.DTOs.Responses.Login
{
    public record LoginUserResponse
    {
        public UserEntity User { get; set; }
        public string Token { get; set; }
    }
}
