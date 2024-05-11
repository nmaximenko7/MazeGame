using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        MazeGenerator3D.Instance.CurrentMazeData = null;
        GetComponent<SceneController>().SwitchToScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
