using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoatReservationController: ControllerBase
{
    private readonly BoatReservationDbContext _dbContext;

    public BoatReservationController(BoatReservationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("Client/{idClient:int}/getReservations")]
    public async Task<IActionResult> GetReservations(int idClient)
    {
        Client client = await _dbContext.Clients.Where(cl => cl.IdClient == idClient).SingleAsync();
        List<Reservation> reservations = await _dbContext.Reservations.Where(res => res.IdClient == idClient).OrderByDescending(res=>res.DateTo).ToListAsync();
        List<ReservationDTO> reservationDtos = new List<ReservationDTO>();
        foreach (Reservation res in reservations)
        {
            reservationDtos.Add(new ReservationDTO()
            {
                CancelReason = res.CancelReason,
                Capacity = res.Capacity,
                DateFrom = res.DateFrom,
                DateTo = res.DateTo,
                Fulfilled = res.Fulfilled,
                IdBoatStandard = res.IdBoatStandard,
                IdClient = res.IdClient,
                IdReservation = res.IdReservation,
                NumOfBoats = res.NumOfBoats,
                Price = res.Price
            });
        }

        ClientDTO clientDto = new ClientDTO
        {
            IdClient = client.IdClient,
            Name = client.Name,
            LastName = client.LastName,
            Birthday = client.Birthday,
            Pesel = client.Pesel,
            Email = client.Email,
            IdClientCategory = client.IdClientCategory,
            Reservations = reservationDtos
        };
        return Ok(clientDto);
    }

    [HttpPost]
    //public async Task<IActionResult> GetPatients(Patient patient, Prescription prescription, Doctor doctor)
    public async Task<IActionResult> PostReservation(ReservationRequestDTO reservation)
    {
        Client client = await _dbContext.Clients.Where(cl => cl.IdClient == reservation.IdClient).SingleAsync();
        List<Reservation> reservations = await _dbContext.Reservations.Where(res => res.IdClient == reservation.IdClient).ToListAsync();
        int discountPerc = await _dbContext.ClientCategory.Where(cc => cc.IdClientCategory == client.IdClientCategory)
            .Select(cl => cl.DiscountPerc).SingleAsync();
        decimal price = reservation.NumOfBoats * (await _dbContext.Sailboats.Where(sail => sail.IdBoatStandard == reservation.IdBoatStandard)
            .Select(sail => sail.Price).SingleAsync()) * ((decimal)(100 - discountPerc)/100);
        int capacity = reservation.NumOfBoats * (await _dbContext.Sailboats.Where(sail => sail.IdBoatStandard == reservation.IdBoatStandard)
            .Select(sail => sail.Capacity).SingleAsync());
        
        foreach(Reservation res in reservations)
        {
            if (res.Fulfilled == false)
            {
                Reservation reservationX = new Reservation
                {
                    CancelReason = "Klient ma aktywna rezerwacje!",
                    Capacity = capacity,
                    DateFrom = reservation.DateFrom,
                    DateTo = reservation.DateTo,
                    Fulfilled = true,
                    IdBoatStandard = reservation.IdBoatStandard,
                    IdClient = reservation.IdClient,
                    NumOfBoats = reservation.NumOfBoats,
                    Price = price
                };
                await _dbContext.AddAsync(reservationX);
                await _dbContext.SaveChangesAsync();
                return BadRequest("Klient ma aktywna rezerwacje!");
            }
        }
        Reservation reservationY = new Reservation
        {
            Capacity = capacity,
            DateFrom = reservation.DateFrom,
            DateTo = reservation.DateTo,
            Fulfilled = true,
            IdBoatStandard = reservation.IdBoatStandard,
            IdClient = reservation.IdClient,
            NumOfBoats = reservation.NumOfBoats,
            Price = price
        };
        await _dbContext.AddAsync(reservationY);
        await _dbContext.SaveChangesAsync();
        return Ok(reservationY.IdReservation);
    }

}

//INSERT INTO Patient (FirstName,LastName,Birthdate)
//VALUES ('Mark','Twain','1984-06-01 00:00:00.000'); 

// UPDATE Reservation
// SET Fulfilled = 0
// WHERE IdReservation = 1; 

// DELETE FROM Reservation WHERE IdReservation = 2;

//return StatusCode(StatusCodes.Status201Created);
// return StatusCode((int)HttpStatusCode.OK, "data");
// return Created("uri", "data");
// return ValidationProblem("message");
// return Forbid("message");
// return Challenge();
// return Accepted("data or message");
// return Unauthorized("message");
// return NotFound("Message");
// return BadRequest("Error description");
//return Ok(ret);