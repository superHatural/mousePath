namespace MouseTracker.Domain;

public class Track
{
    public Track(int coordX, int coordY, long time)
    {
        CoordX = coordX;
        CoordY = coordY;
        Time = time;            
    }
    public int CoordX { get;}
    public int CoordY { get;}
    public long Time{ get;}
}                   