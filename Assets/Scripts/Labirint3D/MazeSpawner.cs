using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    [Header("ќбъект €чейки")]
    public Transform CellPrefab;

    [Header("√лобальные и локальные размеры €чейки")]
    [SerializeField] private Vector2 _cellSize;
    [SerializeField] private Vector3 _localCellSize;

    [Header("–азмеры лабиринта")]
    [SerializeField] private int _mazeWidth = 10;
    [SerializeField] private int _mazeHeight = 10;

    void Start()
    {
        MazeGenerator generator = new MazeGenerator(_mazeWidth, _mazeHeight);
        MazeGeneratorCell[,] maze = generator.GenerateMaze();
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                Transform cellTransform = Instantiate(CellPrefab, 
                    new Vector3(x * _cellSize.x * _localCellSize.x, 0, y * _cellSize.y * _localCellSize.z),
                    Quaternion.identity, transform);
                cellTransform.localScale = new Vector3(_localCellSize.x, _localCellSize.y, _localCellSize.z);

                Cell cell = cellTransform.GetComponent<Cell>();
                cell.WallLeft.SetActive(maze[x, y].WallLeft);
                cell.WallBottom.SetActive(maze[x, y].WallBottom);
                cell.Floor.SetActive(maze[x, y].Floor);
            }
        }
    }
}
