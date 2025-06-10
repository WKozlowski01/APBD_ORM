using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_ORM.Models;

public class Track
{
    [Key]
    public int TrackId { get; set; }
    [MaxLength(100)] 
    public string Name { get; set; }
    
    [Column(TypeName = "decimal")]
    [Precision(5, 2)]
    public decimal LengthlnKm { get; set; }
    
    public ICollection<TrackRace> trackRaces { get; set; }
    
}