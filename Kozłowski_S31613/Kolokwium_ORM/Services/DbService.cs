using Kolokwium_ORM.Data;
using Kolokwium_ORM.DTOs;
using Kolokwium_ORM.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_ORM.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }


    public async Task<GetDTO.RacerDTO> GetRacer(int RacerId)
    {
        var racer = _context.Racers
            .Include(Rp => Rp.RaceParticipations)
            .ThenInclude(rt => rt.trackrace)
            .ThenInclude(t => t.track)
            .Include(r => r.RaceParticipations)
            .ThenInclude(rt => rt.trackrace)
            .ThenInclude(r => r.race).FirstOrDefault(rt => rt.RacerId == RacerId);

        
        var racepartitions = _context.RaceParticipations.Where(rp=>rp.racer.RacerId == RacerId);

       
        
        List<TrackRace> trackraces = new List<TrackRace>();
        foreach (var raceParition in racepartitions)
        {
            var trackRaces = _context.TrackRaces.Where(tr=>tr.TrackRaceId == raceParition.TrackRaceId);
           trackraces = trackRaces.ToList();

            foreach (var trackRace in trackRaces)
            {
                var track = _context.Tracks.Where(t => t.TrackId == trackRace.TrackId);
                
            }
            
            
        }
        





        var result = new GetDTO.RacerDTO
        {
            RacerId = racer.RacerId,
            FirstName = racer.FirstName,
            LastName = racer.LastName,
        };

        return result;


    }

   
        
    }