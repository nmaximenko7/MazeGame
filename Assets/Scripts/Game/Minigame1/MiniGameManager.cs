using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour, IGameManager
{
    [SerializeField]private GameObject _startPanel;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _pauseBtn;
    void Start()
    {
        _startPanel.SetActive(true);
        _endPanel.SetActive(false);
        _pauseBtn.SetActive(false);
        _pausePanel.SetActive(false);
        Time.timeScale = 0.0f;
    }

    public void StartGame()
    {   
        _startPanel.SetActive(false);
        _pauseBtn.SetActive(true);
        Time.timeScale = 1.0f;
    }
    public void EndGame()
    {
        _pauseBtn.SetActive(false);
        _endPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void PauseGame()
    {
        _pausePanel.SetActive(true);
        _pauseBtn.SetActive(false);
        Time.timeScale = 0.0f;
    }
    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        _pauseBtn.SetActive(true);
        Time.timeScale = 1.0f;
    }
}
