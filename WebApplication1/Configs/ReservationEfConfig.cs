using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configs;

public class ReservationEfConfig: IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder
            .HasKey(bs => bs.IdReservation)
            .HasName("Reservation_pk");

        builder
            .Property(x => x.DateFrom)
            .IsRequired();
        builder
            .Property(x => x.DateTo)
            .IsRequired();
        builder
            .Property(x => x.Capacity)
            .IsRequired();
        builder
            .Property(x => x.NumOfBoats)
            .IsRequired();
        builder
            .Property(x => x.Fulfilled)
            .IsRequired();
        builder
            .Property(x => x.CancelReason)
            .HasMaxLength(200);
        
        builder
            .HasOne(x => x.BoatStandard)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.IdBoatStandard)
            .HasConstraintName("Reservation_BoatStandard")
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .HasOne(x => x.Client)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.IdClient)
            .HasConstraintName("Reservation_Client")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .ToTable("Reservation");
        // builder
        //     .ToTable(nameof(Client));
    }
}