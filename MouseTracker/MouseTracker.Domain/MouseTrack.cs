using CSharpFunctionalExtensions;

namespace MouseTracker.Domain;

public class MouseTrack : Entity<Guid>
{
    // EF CORE
    private MouseTrack()
    {
    }

    public MouseTrack(Guid id, IEnumerable<Track> data) : base(id)
    {
        Data = data.ToList();
    }

    public List<Track> Data { get; set; } = default!;
}