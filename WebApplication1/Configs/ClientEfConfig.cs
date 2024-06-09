using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configs;

public class ClientEfConfig: IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder
            .HasKey(bs => bs.IdClient)
            .HasName("Client_pk");
        builder
            .HasOne(x => x.ClientCategory)
            .WithMany(x => x.Clients)
            .HasForeignKey(x => x.IdClientCategory)
            .HasConstraintName("Client_ClientCategory")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(x => x.Birthday)
            .IsRequired();
        builder
            .Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(x => x.Pesel)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(x => x.IdClientCategory)
            .IsRequired();
        
        
        
        builder
            .ToTable("Client");
        // builder
        //     .ToTable(nameof(Client));
    }
}