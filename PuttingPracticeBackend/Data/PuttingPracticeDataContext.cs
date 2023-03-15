using PuttingPracticeBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace PuttingPracticeBackend.Data;
public class PuttingPracticeDataContext : DbContext
{
    public PuttingPracticeDataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private readonly IConfiguration _configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(_configuration.GetConnectionString("PuttingPracticeDatabase"));
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Round> Rounds { get; set; }
}