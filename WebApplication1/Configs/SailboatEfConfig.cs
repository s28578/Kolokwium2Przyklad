using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configs;

public class SailboatEfConfig: IEntityTypeConfiguration<Sailboat>
{
    public void Configure(EntityTypeBuilder<Sailboat> builder)
    {
        builder
            .HasKey(bs => bs.IdSailboat)
            .HasName("Sailboat_pk");
        
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(x => x.Capacity)
            .IsRequired();
        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .HasOne(x => x.BoatStandard)
            .WithMany(x => x.Sailboats)
            .HasForeignKey(x => x.IdBoatStandard)
            .HasConstraintName("Sailboat_BoatStandard")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .Property(x => x.Price)
            .IsRequired();
        
    }
}