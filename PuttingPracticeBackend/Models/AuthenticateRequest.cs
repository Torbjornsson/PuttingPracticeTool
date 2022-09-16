using System.ComponentModel.DataAnnotations;

namespace PuttingPracticeBackend.Models;

public class AuthenticateRequest
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}