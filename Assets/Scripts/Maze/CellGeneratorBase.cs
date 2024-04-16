using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGeneratorBase
{
    public int X;
    public int Y;

    [HideInInspector] public bool WallLeft = true;
    [HideInInspector] public bool WallBottom = true;

    [HideInInspector] public bool Visited = false;
    [HideInInspector] public int DistanceFromStart;

    [HideInInspector] public CellRole ThisCellRole = CellRole.MID;
}

public enum CellRole
{
    START, FINISH, MID, CURRENT
}