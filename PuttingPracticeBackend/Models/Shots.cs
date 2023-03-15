using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace PuttingPracticeBackend.Models;

public class Shots
{
    public int Id { get; set; }

    public int DistanceInCm { get; set; }

    [NotMapped]
    public Dictionary<string, string> ListOfAttributes { get; set; } = null!;

    public string JsonListOfAttributes
    {
        get => JsonConvert.SerializeObject(ListOfAttributes);
        set => ListOfAttributes = JsonConvert.DeserializeObject<Dictionary<string, string>>(value);
    }

    public int ShotsMade { get; set; }

    public int ShotsMax { get; set; }
}