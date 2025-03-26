using MouseTracker.Application.Repository;
using MouseTracker.Domain;

namespace MouseTracker.Application.MouseTrack;

public class CreateMouseTrackHandler
{
    private readonly ITrackRepository _repository;

    public CreateMouseTrackHandler(ITrackRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateMouseTrackCommand command, CancellationToken cancellationToken)
    {
        var tracks = command.Data.Select(t => new Track(t.X, t.Y, t.Timestamp));
        var mouseTrack = new Domain.MouseTrack(Guid.NewGuid(), tracks);
        
        await _repository.AddMouseMovements(mouseTrack, cancellationToken);
        
        return mouseTrack.Id;
    }
}