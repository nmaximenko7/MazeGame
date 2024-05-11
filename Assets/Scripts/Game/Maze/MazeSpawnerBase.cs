using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MazeSpawnerBase : MonoBehaviour
{
    [Header("Объект ячейки")]
    public Transform CellPrefab;
    [Header("Финиш")]
    public Transform FinishPrefabTrigger;
    [Header("Игрок")]
    public Transform PlayerTransform;

    [Header("Размеры лабиринта")]
    [SerializeField] protected int _mazeWidth = 10;
    [SerializeField] protected int _mazeHeight = 10;

    public abstract void SpawnMaze(MazeGenerator3D mazeGenerator3D);
    protected abstract void PlaceMazeExitTrigger(Transform exitCell);
    protected abstract void ActivateComponents(Transform cellTransform, CellGenerator3D cellGenerator);
}
