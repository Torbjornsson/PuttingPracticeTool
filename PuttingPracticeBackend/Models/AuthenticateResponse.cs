namespace PuttingPracticeBackend.Models;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string DisplayName { get; set; }
    public string Token { get; set; }
}