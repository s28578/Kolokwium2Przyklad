using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configs;

public class SailboatReservationEfConfig: IEntityTypeConfiguration<SailboatReservation>
{
    public void Configure(EntityTypeBuilder<SailboatReservation> builder)
    {
        builder
            .HasKey(x => new{x.IdSailboat, x.IdReservation})
            .HasName("SailboatReservation_pk");
        
    }
}