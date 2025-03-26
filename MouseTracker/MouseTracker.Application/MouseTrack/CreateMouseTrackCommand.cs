using MouseTracker.Application.Dtos;

namespace MouseTracker.Application.MouseTrack;

public class CreateMouseTrackCommand
{
    public CreateMouseTrackCommand(IEnumerable<MouseMovementDto> data)
    {
        Data = data;
    }
    public IEnumerable<MouseMovementDto> Data { get; }
}