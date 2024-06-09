using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class ClientCategory
{
    [Key]
    public int IdClientCategory { get; set; }
    public string Name { get; set; }
    public int DiscountPerc { get; set; }
    
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}