using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TriggerFinish : MonoBehaviour
{
    private IGameManager gameManager;
    private void Start()
    {
        gameManager = FindAnyObjectByType<MazeGameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.EndGame();
        }
    }
}
