namespace MouseTracker.Domain;

public class Track
{
    public Track(int x, int y, long time)
    {
        X = x;
        Y = y;
        Time = time;
    }
    public int X { get;}
    public int Y { get;}
    public long Time{get;}
}