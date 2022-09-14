namespace PuttingPracticeBackend.Models;

public class Shots
{
    public int Id { get; set; }

    public int DistanceInCm { get; set; }

    public Dictionary<string, string> ListOfAttributes { get; set; } = null!;

    public int ShotsMade { get; set; }

    public int ShotsMax { get; set; }
}