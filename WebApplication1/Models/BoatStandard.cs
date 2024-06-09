using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class BoatStandard
{
    [Key]
    public int IdBoatStandard { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public virtual ICollection<Sailboat> Sailboats { get; set; } = new List<Sailboat>();
}