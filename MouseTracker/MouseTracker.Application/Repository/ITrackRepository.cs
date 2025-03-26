namespace MouseTracker.Application.Repository;

public interface ITrackRepository
{
    Task<Guid> AddMouseMovements(Domain.MouseTrack track, CancellationToken cancellationToken);
}