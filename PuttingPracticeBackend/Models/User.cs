using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PuttingPracticeBackend.Models;

[Table("Users")]
public class User
{
    public int Id { get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [JsonIgnore]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    public string DisplayName { get; set; } = null!;
}