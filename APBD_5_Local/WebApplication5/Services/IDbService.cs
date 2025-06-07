using WebApplication5.DTOs;

namespace WebApplication5.Services;

public interface IDbService
{
    Task<GetTripsDTO> GetAllTripsAsync(int page, int pageSize);
    Task<int> DeleteClientAsync(int idClient);
    Task AddClientToTripAsync(ClientToTripDTO data);

}