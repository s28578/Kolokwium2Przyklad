using WebApplication1.Models;

namespace WebApplication1.DTO;

public class ClientDTO
{
    public int IdClient { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string Pesel { get; set; }
    public string Email { get; set; }
    public int IdClientCategory { get; set; }
    
    public virtual ICollection<ReservationDTO> Reservations { get; set; } = new List<ReservationDTO>();
}