using PuttingPracticeBackend.Models;

namespace PuttingPracticeBackend.Interfaces;

public interface IJwtUtils
{
    public string GenerateToken(User user);
    public int? ValidateToken(string? token);
}