using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeStateManager : MonoBehaviour
{

    private static MazeStateManager _instance;

    // Публичное статическое свойство для доступа к экземпляру синглтона
    public static MazeStateManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singletonObject = new GameObject("MazeStateManager");
                _instance = singletonObject.AddComponent<MazeStateManager>();
                DontDestroyOnLoad(singletonObject);
            }
            return _instance;
        }
    }
    public CellGenerator3D[,] CurrentMazeData { get; set; }
}
