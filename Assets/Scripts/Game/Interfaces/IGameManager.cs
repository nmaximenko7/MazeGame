using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{
    // ����� ���������� ��� ������ ����
    void StartGame();

    // ����� ���������� ��� ����� ����
    void PauseGame();

    // ����� ���������� ��� ��������� ����
    void EndGame();

    // ����� ���������� ��� �������� ����
    void ResumeGame();
}
