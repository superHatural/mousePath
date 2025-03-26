using MouseTracker.Application.Repository;
using MouseTracker.Domain;

namespace MouseTracker.Infrastructure.Repository;

public class TrackRepository : ITrackRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TrackRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> AddMouseMovements(MouseTrack track, CancellationToken cancellationToken)
    {
        await _dbContext.Tracks.AddAsync(track, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return track.Id;
    }
}