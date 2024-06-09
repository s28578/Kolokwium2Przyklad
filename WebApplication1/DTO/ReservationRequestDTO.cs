namespace WebApplication1.DTO;

public class ReservationRequestDTO
{
    public int IdClient { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int IdBoatStandard { get; set; }
    public int NumOfBoats { get; set; }
}