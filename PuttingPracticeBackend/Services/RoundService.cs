using PuttingPracticeBackend.Data;
using PuttingPracticeBackend.Models;

namespace PuttingPracticeBackend.Services;

public class RoundService
{
    private PuttingPracticeDataContext _context;
    public RoundService(PuttingPracticeDataContext context)
    {
        _context = context;
    }
    
    public Round StartRound(User currentUser, string name, RoundTemplate? template = null)
    {
        var newRound = new Round
        {
            Name = name,
            CreatedAt = DateTime.Now,
            User = currentUser,
            ListOfShots = template != null ? template.ListOfShots : new List<Shots>()
        };

        return newRound;
    }

    public Round FinishRound(Round round)
    {
        round.FinishedAt = DateTime.Now;
        _context.Rounds.Add(round);
        _context.SaveChanges();

        return round;
    }
}