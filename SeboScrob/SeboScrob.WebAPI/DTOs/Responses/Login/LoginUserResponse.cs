namespace SeboScrob.WebAPI.DTOs.Responses.Login
{
    public record LoginUserResponse
    {
        public string Id { get; set; }
        public bool IsLoggedIn { get; set; } = false;

    }
}
