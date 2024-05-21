using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameGreenManager : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _pauseBtn;
    [SerializeField] private TextMeshProUGUI _timeRemainingText;

    public float TimeRemaining { get; set; }
    private float _timeLimit = 60f;
    void Start()
    {
        _startPanel.SetActive(true);
        _endPanel.SetActive(false);
        _pauseBtn.SetActive(false);
        _pausePanel.SetActive(false);
        TimeRemaining = 0f;
        Time.timeScale = 0.0f;
    }
    private void Update()
    {
        if (TimeRemaining > _timeLimit) EndGame();
        else
        {
            TimeRemaining += Time.deltaTime;
            _timeRemainingText.text = "Time Remaining: " + Mathf.Round(_timeLimit - TimeRemaining).ToString();
        }
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
