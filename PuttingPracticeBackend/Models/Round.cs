namespace PuttingPracticeBackend.Models;

public class Round
{
    public int Id { get; set; }

    public User User { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string Name { get; set; } = null!;
    
    public IList<Shots> ListOfShots { get; set; } = null!;
}