using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MazeGenerator3D : MazeGeneratorBase
{
    private static MazeGenerator3D _instance;
    public CellGenerator3D[,] CurrentMazeData { get; set; }

    public static MazeGenerator3D Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MazeGenerator3D();
                Debug.Log("Instanse");
            }
            return _instance;
        }
    }
    public bool IsGenerated()
    {
        return _instance.CurrentMazeData != null;
    }
    public override CellGenerator3D[,] GenerateMaze(int Width, int Height)
    {
        CellGenerator3D[,] maze = new CellGenerator3D[Width, Height];
        
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new CellGenerator3D { X = x, Y = y };
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
        RemoveWalls(maze);
        PlaceMazeExit(maze);
        SetActionCells(maze);
        return maze;
    }

    private void SetActionCells(CellGenerator3D[,] maze)
    {
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                if (x == 0 && y == 0 || maze[x, y].WallBottom && maze[x, y].WallLeft) { continue; }
                if (Random.Range(0f, 1f) < 0.2f)
                {
                    if (!maze[x, y].WallLeft) maze[x, y].TriggerLeft = true;
                    if (!maze[x, y].WallBottom) maze[x, y].TriggerBottom = true;
                    if (Random.Range(0f, 1f) < 0.3f) maze[x, y].ThisCellRole = CellRole.ENTITY;
                    else maze[x, y].ThisCellRole = CellRole.SCRIMER;
                }
                else
                {
                    maze[x, y].TriggerLeft = false;
                    maze[x, y].TriggerBottom = false;
                }
            }
        }
        
    }
}
