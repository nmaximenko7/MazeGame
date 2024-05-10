using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _continueButton;
    private void Start()
    {
        if (MazeGenerator3D.Instance.IsGenerated())
            _continueButton.SetActive(true);
        else
            _continueButton.SetActive(false);
    }
    public void Continue()
    {
        GetComponent<SceneController>().SwitchToScene(2);
    }
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
