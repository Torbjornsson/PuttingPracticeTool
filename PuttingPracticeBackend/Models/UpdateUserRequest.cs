namespace PuttingPracticeBackend.Models;

public class UpdateUserRequest
{
    public string Email { get; set; }
    public string DisplayName { get; set; }
    public string Password { get; set; }
}