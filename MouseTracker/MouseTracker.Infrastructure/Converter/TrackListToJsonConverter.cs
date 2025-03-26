using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MouseTracker.Domain;

namespace MouseTracker.Infrastructure.Converter;

public class TrackListToJsonConverter : ValueConverter<List<Track>, string>
{
    public TrackListToJsonConverter()
        : base(
            v => JsonSerializer.Serialize(v, new JsonSerializerOptions { WriteIndented = false }),
            v => JsonSerializer.Deserialize<List<Track>>(v, new JsonSerializerOptions()) ?? new List<Track>())
    {
    }
}