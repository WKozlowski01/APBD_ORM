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



    [HttpGet("patient/{id}")]
    public async Task<IActionResult> GetPrescription(int id)
    {
        // var patient = await _dbService.GetAllPatientAsync(id);
        //
        // if (patient == null)
        // {
        //     return NotFound("Pacjent o id: "+id+" nie istnieje");
        // }
        //
        // return Ok(patient);
        // }
        return Ok();
    }
}