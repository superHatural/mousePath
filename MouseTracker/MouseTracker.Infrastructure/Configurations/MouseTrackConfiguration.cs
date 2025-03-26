using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MouseTracker.Domain;
using MouseTracker.Infrastructure.Converter;

namespace MouseTracker.Infrastructure.Configurations;

public class MouseTrackConfiguration: IEntityTypeConfiguration<MouseTrack>
{
    public void Configure(EntityTypeBuilder<MouseTrack> builder)
    {
        builder.ToTable("tracks");
        builder.HasKey(n => n.Id);
        
        builder.Property(n => n.Id);

        builder.Property(n => n.Data)
            .HasColumnType("jsonb")
            .HasConversion(new TrackListToJsonConverter())
            .IsRequired();

    }
}