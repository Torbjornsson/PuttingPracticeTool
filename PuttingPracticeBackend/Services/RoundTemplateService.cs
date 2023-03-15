using PuttingPracticeBackend.Data;

namespace PuttingPracticeBackend.Services;

public class RoundTemplateService
{
    private PuttingPracticeDataContext _context;
    public RoundTemplateService(PuttingPracticeDataContext context)
    {
        _context = context;
    }
}