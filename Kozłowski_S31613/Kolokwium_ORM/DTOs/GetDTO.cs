using Kolokwium_ORM.Models;

namespace Kolokwium_ORM.DTOs;

public class GetDTO
{
    public class RacerDTO
    {
        public int RacerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       // public ICollection<RaceParticipationDTO> RaceParticipations { get; set; }
    }


    public class RaceParticipationDTO
    {
        public RaceDTO race { get; set; }
        public TrackDTO track { get; set; }
        public int Laps { get; set; }
        public int FinishTimeLnSeconds { get; set; }
        public int Position { get; set; }

    }

    public class TrackDTO
    {
        public string name { get; set; }
        public decimal lengthInKm { get; set; }

    }

    public class RaceDTO
    {
        public string name { get; set; }
        public string Location { get; set; }
        public DateTime date { get; set; }
    }
}