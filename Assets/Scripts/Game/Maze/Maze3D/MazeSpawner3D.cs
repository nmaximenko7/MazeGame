using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UIElements;

public class MazeSpawner3D : MazeSpawnerBase
{

    [Header("√лобальные и локальные размеры €чейки")]
    [SerializeField] private Vector2 _cellSize;
    [SerializeField] private Vector3 _localCellSize;

    void Start()
    {
        MazeGenerator3D mazeGenerator = MazeGenerator3D.Instance;
        Debug.Log(mazeGenerator.CurrentMazeData);
        if (!mazeGenerator.IsGenerated()) {
            _mazeWidth = PlayerPrefs.GetInt("mazeWidth");
            _mazeHeight = PlayerPrefs.GetInt("mazeHeight");
            mazeGenerator.CurrentMazeData = mazeGenerator.GenerateMaze(_mazeWidth, _mazeHeight);
            ScoreCounter.Instance.Score = 0;
        }
        SpawnMaze(mazeGenerator);
    }

    public override void SpawnMaze(MazeGenerator3D mazeGenerator)
    {
        CellGenerator3D[,] maze = mazeGenerator.CurrentMazeData;
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                Transform cellTransform = Instantiate(CellPrefab,
                    new Vector3(x * _cellSize.x * _localCellSize.x, 0, y * _cellSize.y * _localCellSize.z),
                    Quaternion.identity, transform);
                cellTransform.localScale = new Vector3(_localCellSize.x, _localCellSize.y, _localCellSize.z);

                ActivateComponents(cellTransform, maze[x, y]);

                if (maze[x, y].ThisCellRole == CellRole.FINISH)
                    PlaceMazeExitTrigger(cellTransform);

                if (maze[x, y].ThisCellRole == CellRole.START)
                {
                    Debug.Log("—павним игрока");
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    if (player) Destroy(player);
                    Instantiate(PlayerTransform,
                        new Vector3(x * _cellSize.x * _localCellSize.x, 5f, y * _cellSize.y * _localCellSize.z), 
                        Quaternion.identity);
                }
            }
        }
    }
    protected override void PlaceMazeExitTrigger(Transform exitCell)
    {
        Transform exitTrigger = Instantiate(FinishPrefabTrigger);
        exitTrigger.transform.position = exitCell.position + new Vector3(0, 2, 0);
    }
    protected override void ActivateComponents(Transform cellTransform, CellGenerator3D cellGenerator)
    {
        Cell3D cell = cellTransform.GetComponent<Cell3D>();
        if (cellGenerator is CellGenerator3D)
        {
            CellGenerator3D cellGenerator3D = cellGenerator;
            cell.X = cellGenerator3D.X;
            cell.Y = cellGenerator3D.Y;
            cell.WallLeft.SetActive(cellGenerator3D.WallLeft);
            cell.WallBottom.SetActive(cellGenerator3D.WallBottom);
            cell.TriggerLeft.SetActive(cellGenerator3D.TriggerLeft);
            cell.TriggerBottom.SetActive(cellGenerator3D.TriggerBottom);
            cell.Floor.SetActive(cellGenerator3D.Floor);
        }
    }

}
