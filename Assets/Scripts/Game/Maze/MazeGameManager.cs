using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MazeGameManager : MonoBehaviour, IGameManager
{
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _pauseBtn;
    [SerializeField] private GameObject _winText;
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        _endPanel.SetActive(false);
        _pausePanel.SetActive(false);
        _pauseBtn.SetActive(true);
        Time.timeScale = 1.0f;
    }
    public void EndGame()
    {
        _pauseBtn.SetActive(false);
        _endPanel.SetActive(true);
        TextMeshProUGUI winText = _endPanel.transform.Find("WinText").GetComponent<TextMeshProUGUI>();
        winText.text = "����������, �� �������� � ���� �������� ���������, ������� ��������. ��� ����: " +
            ScoreCounter.Instance.Score.ToString();
        winText.color = Color.white;
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

    public void NewGame()
    {
        MazeGenerator3D.Instance.CurrentMazeData = null;
        GetComponent<SceneController>().SwitchToScene(1);
    }
}
