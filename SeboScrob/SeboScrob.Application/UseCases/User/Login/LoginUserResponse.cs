namespace SeboScrob.Application.UseCases.User.Login
{
    public record LoginUserResponse
    {
        public string? Id { get; set; }
        public bool IsLoggedIn { get; set; } = false;

    }
}
