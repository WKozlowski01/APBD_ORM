using Kolokwium_ORM.DTOs;

namespace Kolokwium_ORM.Services;

public interface IDbService
{
    public Task<GetDTO.RacerDTO> GetRacer(int RacerId);
   
}