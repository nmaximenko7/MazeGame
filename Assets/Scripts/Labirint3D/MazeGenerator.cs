using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator
{
    public int Width;
    public int Height;

    public MazeGenerator(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public MazeGeneratorCell[,] GenerateMaze()
    {
        MazeGeneratorCell[,] maze = new MazeGeneratorCell[Width, Height];
        
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new MazeGeneratorCell { X = x, Y = y };
            }
        }
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            maze[x, Height - 1].WallLeft = false;
            maze[x, Height - 1].Floor = false;
        }
        for (int y = 0; y < maze.GetLength(1); y++)
        {
            maze[Width - 1, y].WallBottom = false;
            maze[Width - 1, y].Floor = false;
        }
        RemoveWallsWithBacktracker(maze);
        PlaceMazeExit(maze);
        return maze;
    }

    private void RemoveWallsWithBacktracker(MazeGeneratorCell[,] maze)
    {
        MazeGeneratorCell current = maze[0, 0];
        current.DistanceFromStart = 0;
        current.Visited = true;
        Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();
        do
        {
            List<MazeGeneratorCell> unvisitedNeighbours = new List<MazeGeneratorCell>();

            int x = current.X;
            int y = current.Y;

            if (x > 0 && !maze[x - 1, y].Visited) unvisitedNeighbours.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].Visited) unvisitedNeighbours.Add(maze[x, y - 1]);
            if (x < Width - 2 && !maze[x + 1, y].Visited) unvisitedNeighbours.Add(maze[x + 1, y]);
            if (y < Height - 2 && !maze[x, y + 1].Visited) unvisitedNeighbours.Add(maze[x, y + 1]);

            if (unvisitedNeighbours.Count > 0)
            {
                MazeGeneratorCell chosen = unvisitedNeighbours[Random.Range(0, unvisitedNeighbours.Count)];
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

    private void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b)
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

    private void PlaceMazeExit(MazeGeneratorCell[,] maze)
    {
        MazeGeneratorCell firsthest = maze[0, 0];
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
            maze[firsthest.X + 1, firsthest.Y].ThisCellRole = CellRole.FINISH;
        }
        else if (firsthest.Y == Height - 2)
        {
            maze[firsthest.X, firsthest.Y + 1].WallBottom = false;
            maze[firsthest.X, firsthest.Y + 1].ThisCellRole = CellRole.FINISH;
        }
    }
}
