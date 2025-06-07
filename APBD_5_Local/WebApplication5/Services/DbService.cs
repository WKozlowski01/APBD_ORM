using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.DTOs;
using WebApplication5.Exceptions;
using WebApplication5.Models;

namespace WebApplication5.Services;

public class DbService: IDbService
{
    private readonly TripsDBContext _context;

    public DbService(TripsDBContext context)
    {
        _context = context;
    }


    public async Task<GetTripsDTO> GetAllTripsAsync(int page, int pageSize)
    {
      
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;

        var totalTrips = _context.Trips.Count();
        var totalPages = (int)Math.Ceiling(totalTrips / (double)pageSize);
        
        var trips = await _context.Trips
            .Include(t => t.ClientTrips)
            .ThenInclude(ct => ct.IdClientNavigation)
            .Include(t => t.IdCountries)
            .OrderByDescending(t => t.DateFrom)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        if (trips == null)
        {
            throw new NoTripsException("Nie ma żadnych wycieczek");

        }

        var result = new GetTripsDTO
        {
            PageNum = page,
            PageSize = pageSize,
            AllPages = totalPages,
            Trips = trips.Select(t => new TripDTO
            {
                Name = t.Name,
                Description = t.Description,
                DateFrom = t.DateFrom,
                DateTo = t.DateTo,
                MaxPeople = t.MaxPeople,
                Countries = t.IdCountries.Select(ct => new CountryDTO
                {
                    Name = ct.Name
                }).ToList(),
                Clients = t.ClientTrips.Select(ct => new ClientDTO
                {
                    FirstName = ct.IdClientNavigation.FirstName,
                    LastName = ct.IdClientNavigation.LastName,
                }).ToList()
            }).ToList()

        };

        return result;

    }

    public async Task<int> DeleteClientAsync(int idClient)
    {
         var clientTrips = await _context.ClientTrips
            .Where(ct => ct.IdClient == idClient)
            .ToListAsync();
       
        if (clientTrips.Any())
        {
            throw new ClientDeleteException("Nie można usunąć klienta ponieważ jest do niego przypisana wycieczka");
        }
        var user =  await _context.Clients.Where(ct => ct.IdClient == idClient).FirstOrDefaultAsync();
        _context.Clients.Remove(user);
        _context.SaveChanges();

        return user.IdClient;

    }

    public async Task AddClientToTripAsync([FromBody] ClientToTripDTO data)
    {
        
        var idClient  = await _context.Clients
            .Where(p=>p.Pesel == data.Pesel)
            .Select(i=>i.IdClient)
            .FirstOrDefaultAsync();

        if (idClient != 0)
        {
            throw new NoClientException("Taki klient jest już w bazie");
        }

        int lastId = await _context.Clients
            .OrderBy(c => c.IdClient)  
            .Select(c => c.IdClient)
            .LastOrDefaultAsync();
        
        
        var ifTripExists = await _context.Trips.Where(t => t.IdTrip == data.idTrip).FirstOrDefaultAsync();

        var ifClientOnTrip = await _context.ClientTrips.Where(ct => ct.IdClient == idClient && ct.IdTrip == data.idTrip).FirstOrDefaultAsync();

        if (ifClientOnTrip != null)
        {
            throw new ClientAlreadyOnTripException("Taki klient jest już zapisany na tę wycieczkę");
        }

      
        
        if (ifTripExists != null)
        {
            if (ifTripExists.DateFrom < DateTime.Now)
            {
                throw new TripException("Data rozpoczęcia wycieczki jest wcześniejsza niż aktualna");
            }
            
        }
        else
        {
            throw new TripException("Wycieczka o podanym id nie istnieje");
        }



        var client = new Client
        {
            FirstName = data.FirstName,
            LastName = data.LastName,
            Email = data.Email,
            Telephone = data.Telephone,
            Pesel = data.Pesel
        };
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
        

         await _context.ClientTrips.AddAsync(new ClientTrip
        {
            IdClient = await _context.Clients.Where(ct => ct.Pesel == data.Pesel).Select(id=>id.IdClient).FirstOrDefaultAsync(),
            IdTrip = ifTripExists.IdTrip,
            RegisteredAt = DateTime.Now,
            PaymentDate = data.PaymentDate
        });
        await _context.SaveChangesAsync();
        
    }
    
    
}