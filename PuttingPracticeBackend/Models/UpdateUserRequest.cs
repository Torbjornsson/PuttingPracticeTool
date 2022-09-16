using System.ComponentModel.DataAnnotations;

namespace PuttingPracticeBackend.Models;

public class UpdateUserRequest
{
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    public string DisplayName { get; set; }
    public string Password { get; set; }
}