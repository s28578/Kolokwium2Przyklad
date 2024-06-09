using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Sailboat
{
    [Key]
    public int IdSailboat { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public string Description { get; set; }
    public int IdBoatStandard { get; set; }
    [ForeignKey(nameof(IdBoatStandard))]
    public virtual BoatStandard BoatStandard { get; set; }
    public decimal Price { get; set; }
    
    public virtual ICollection<SailboatReservation> SailboatReservations { get; set; } = new List<SailboatReservation>();
}