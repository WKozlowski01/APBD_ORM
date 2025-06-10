using Kolokwium_ORM.DTOs;
using Kolokwium_ORM.Exceptions;
using Kolokwium_ORM.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_ORM.Controller;

[Route("/api")]
[ApiController]
public class AppController : ControllerBase
{
    private readonly IDbService _dbService;

    public AppController(IDbService dbService)
    {
        _dbService = dbService;
    }



    [HttpGet("racers/{id}/participations")]
    public async Task<IActionResult> GetRaces(int id)
    {
        var races = await _dbService.GetRacer(id);
         if (races == null)
        {
             return NotFound();
         }
        
         return Ok(races);
         }
    
    
    
    [HttpPost("track-races/participants")]
    public async Task<IActionResult> InsertRacet(PostDto dto)
    {

        try
        {

        }
        catch (IncorrectDataException)
        {
            return BadRequest();
        }
        catch (NoraceException)
        {
            return NotFound();
        }
        catch (NoRacerException)
        {
            return NotFound();
        }
        catch (NoTrackExcepion)
        {
            return NotFound();
            
        }

        return Ok();

    }
    
    
}