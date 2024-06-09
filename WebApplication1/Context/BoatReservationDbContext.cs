using Microsoft.EntityFrameworkCore;
using WebApplication1.Configs;
using WebApplication1.Models;

namespace WebApplication1.Context;

public class BoatReservationDbContext: DbContext
{
    public virtual DbSet<Sailboat> Sailboats { get; set; }
    public virtual DbSet<Reservation> Reservations { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<ClientCategory> ClientCategory { get; set; }

    public BoatReservationDbContext()
    {
        
    }

    public BoatReservationDbContext(DbContextOptions<BoatReservationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SailboatEfConfig).Assembly);
    }
}