public class MazeGeneratorCell
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBottom = true;
    public bool Floor = true;

    public bool Visited = false;

    public int DistanceFromStart;
}
