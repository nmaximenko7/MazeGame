using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{
    // Метод вызывается при старте игры
    void StartGame();

    // Метод вызывается при паузе игры
    void PauseGame();

    // Метод вызывается при окончании игры
    void EndGame();

    // Метод вызывается при закрытии игры
    void ResumeGame();
}
