using SeboScrob.WebAPI.DTOs.Requests.User;

namespace SeboScrob.WebAPI.DTOs.Responses.User
{
    public record CreateUserResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
