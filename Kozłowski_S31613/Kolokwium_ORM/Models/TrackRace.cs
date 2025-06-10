using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium_ORM.Models;

public class TrackRace
{
    [Key]
    public int TrackRaceId { get; set; }
    
    [ForeignKey(nameof(track))]
    public int TrackId { get; set; }
    
    [ForeignKey(nameof(race))]
    public int RaceId { get; set; }
    
    
    public int Laps { get; set; }
    public int? BestTimelnSeconds { get; set; }
    public Race race { get; set; }
    public Track track { get; set; }
    
    
}