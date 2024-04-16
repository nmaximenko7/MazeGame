using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MazeGeneratorBase
{
    //public int Width;
    //public int Height;

    //public MazeGeneratorBase(int width, int height)
    //{
    //    Width = width;
    //    Height = height;
    //}

    public abstract CellGeneratorBase[,] GenerateMaze(int width, int height);

    protected void RemoveWalls(CellGeneratorBase[,] maze)
    {
        int Width = maze.GetLength(0);
        int Height = maze.GetLength(1);
        CellGeneratorBase current = maze[0, 0];
        current.DistanceFromStart = 0;
        current.Visited = true;
        Stack<CellGeneratorBase> stack = new Stack<CellGeneratorBase>();
        do
        {
            List<CellGeneratorBase> unvisitedNeighbours = new List<CellGeneratorBase>();

            int x = current.X;
            int y = current.Y;

            if (x > 0 && !maze[x - 1, y].Visited) unvisitedNeighbours.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].Visited) unvisitedNeighbours.Add(maze[x, y - 1]);
            if (x < Width - 2 && !maze[x + 1, y].Visited) unvisitedNeighbours.Add(maze[x + 1, y]);
            if (y < Height - 2 && !maze[x, y + 1].Visited) unvisitedNeighbours.Add(maze[x, y + 1]);

            if (unvisitedNeighbours.Count > 0)
            {
                CellGeneratorBase chosen = unvisitedNeighbours[Random.Range(0, unvisitedNeighbours.Count)];
                RemoveWall(current, chosen);

                chosen.Visited = true;
                stack.Push(chosen);
                current = chosen;
                chosen.DistanceFromStart = stack.Count;
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);
    }

    protected void RemoveWall(CellGeneratorBase a, CellGeneratorBase b)
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y) a.WallBottom = false;
            else b.WallBottom = false;
        }
        else
        {
            if (a.X > b.X) a.WallLeft = false;
            else b.WallLeft = false;
        }
    }

    protected void PlaceMazeExit(CellGeneratorBase[,] maze)
    {
        int Width = maze.GetLength(0);
        int Height = maze.GetLength(1);
        CellGeneratorBase firsthest = maze[0, 0];
        maze[0, 0].ThisCellRole = CellRole.START;

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            if (maze[x, Width - 2].DistanceFromStart > firsthest.DistanceFromStart) firsthest = maze[x, Height - 2];
            if (maze[x, 0].DistanceFromStart > firsthest.DistanceFromStart) firsthest = maze[x, 0];
        }
        for (int y = 0; y < maze.GetLength(1); y++)
        {
            if (maze[Width - 2, y].DistanceFromStart > firsthest.DistanceFromStart) firsthest = maze[Width - 2, y];
            if (maze[0, y].DistanceFromStart > firsthest.DistanceFromStart) firsthest = maze[0, y];
        }

        if (firsthest.X == 0)
        {
            firsthest.WallLeft = false;
            firsthest.ThisCellRole = CellRole.FINISH;
        }
        else if (firsthest.Y == 0)
        {
            firsthest.WallBottom = false;
            firsthest.ThisCellRole = CellRole.FINISH;
        }
        else if (firsthest.X == Width - 2)
        {
            maze[firsthest.X + 1, firsthest.Y].WallLeft = false;
            maze[firsthest.X, firsthest.Y].ThisCellRole = CellRole.FINISH;
        }
        else if (firsthest.Y == Height - 2)
        {
            maze[firsthest.X, firsthest.Y + 1].WallBottom = false;
            maze[firsthest.X, firsthest.Y].ThisCellRole = CellRole.FINISH;
        }
    }
}
