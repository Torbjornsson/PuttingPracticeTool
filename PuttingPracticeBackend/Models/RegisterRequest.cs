using System.ComponentModel.DataAnnotations;

namespace PuttingPracticeBackend.Models;

public class RegisterRequest
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string DisplayName { get; set; }
}