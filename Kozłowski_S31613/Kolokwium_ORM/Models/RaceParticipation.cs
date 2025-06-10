using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_ORM.Models;

[PrimaryKey(nameof(TrackRaceId),nameof(RacerId))]
public class RaceParticipation
{
    [ForeignKey(nameof(trackrace))]
    public int TrackRaceId { get; set; }
    
    [ForeignKey(nameof(racer))]
    public int RacerId { get; set; }
    public int FinishTimelnSeconds { get; set; }
    public int Position { get; set; }
    
    public TrackRace trackrace { get; set; }
    public Racer racer { get; set; }
    
}