using Moq;
using MouseTracker.Application.Dtos;
using MouseTracker.Application.MouseTrack;
using MouseTracker.Application.Repository;
using MouseTracker.Domain;

namespace MouseTracker.Tests;

public class CreateMouseTrackHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCallRepository_AddMouseMovements()
    {
        // Arrange
        var mockRepository = new Mock<ITrackRepository>();
        var handler = new CreateMouseTrackHandler(mockRepository.Object);

        var command = new CreateMouseTrackCommand(new List<MouseMovementDto>
        {
            new() { X = 100, Y = 200, Timestamp = 1698745600000 },
            new() { X = 150, Y = 250, Timestamp = 1698745601000 }
        });

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        mockRepository.Verify(r => r.AddMouseMovements(It.IsAny<MouseTrack>(), It.IsAny<CancellationToken>()),
            Times.Once);
        Assert.NotEqual(Guid.Empty, result);
    }
}