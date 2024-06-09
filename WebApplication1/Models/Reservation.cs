using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Reservation
{
    [Key]
    public int IdReservation { get; set; }
    public int IdClient { get; set; }
    [ForeignKey(nameof(IdClient))]
    public virtual Client Client { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int IdBoatStandard { get; set; }
    [ForeignKey(nameof(IdBoatStandard))]
    public virtual BoatStandard BoatStandard { get; set; }
    public int Capacity { get; set; }
    public int NumOfBoats { get; set; }
    public bool Fulfilled { get; set; }
    public decimal Price { get; set; }
    public string CancelReason { get; set; }
    
    public virtual ICollection<SailboatReservation> SailboatReservations { get; set; } = new List<SailboatReservation>();
    
    
}