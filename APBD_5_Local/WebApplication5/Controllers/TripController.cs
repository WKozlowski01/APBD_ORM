using Microsoft.AspNetCore.Mvc;
using WebApplication5.DTOs;
using WebApplication5.Exceptions;
using WebApplication5.Services;

namespace WebApplication5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripController : ControllerBase
{
    private readonly IDbService _dbService;

    public TripController(IDbService dbService)
    {
        _dbService = dbService;
    }
    [HttpGet]
    public async Task<IActionResult> GetTripsAsync()
    {
        GetTripsDTO trips = null;
        try
        {
            trips = await _dbService.GetAllTripsAsync(1, 10);
        }
        catch (NoTripsException e)
        {
            return NotFound(e.Message);
        }
      return Ok(trips);
    }

    [HttpDelete("/api/{id}")]
    public async Task<IActionResult> DeleteTripAsync(int id)
    {
        int? result = null;
        try
        {
            result =await _dbService.DeleteClientAsync(id);
        }catch (ClientDeleteException e){
            return NotFound(e.Message);
        }
        return Ok("Usunięto klienta o ID "+result);


    }
    
    [HttpPost("/api/trips/clients")]
    public async Task<IActionResult> AddClientToTripAsync(ClientToTripDTO data)
    {

        try
        {
            await _dbService.AddClientToTripAsync(data);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        return Ok("Udało się dodać klienta do wycieczki");



    }
    

}