using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class SailboatReservation
{
    [Key]
    public int IdSailboat { get; set; }
    [ForeignKey(nameof(IdSailboat))]
    public virtual Sailboat Sailboat { get; set; }
    public int IdReservation { get; set; }
    [ForeignKey(nameof(IdReservation))]
    public virtual Reservation Reservation { get; set; }

}