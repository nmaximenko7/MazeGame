
using UnityEngine;

public class CellGenerator3D
{
    public int X;
    public int Y;

    [HideInInspector] public bool WallLeft = true;
    [HideInInspector] public bool WallBottom = true;

    [HideInInspector] public bool Visited = false;
    [HideInInspector] public int DistanceFromStart;

    [HideInInspector] public CellRole ThisCellRole = CellRole.MID;

    [HideInInspector] public bool TriggerLeft = false;
    [HideInInspector] public bool TriggerBottom = false;
    [HideInInspector] public bool Floor = true;
}

public enum CellRole
{
    START, FINISH, MID, CURRENT, ENTITY, SCRIMER
}