using Kolokwium_ORM.Models;

namespace Kolokwium_ORM.DTOs;

public class PostDto
{
    public string raceName { get; set; }
    public string trackName { get; set; }
    public InesrtRaceParticipationDTO participation { get; set; }



    public class InesrtRaceParticipationDTO
    {
        public int raceId { get; set; }
        public int position { get; set; }
        public int finishTimeInSeconds { get; set; }
    }
}