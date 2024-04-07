using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TriggerFinish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Если да, то выводим сообщение о входе в триггер
            Debug.Log("You are win");
<<<<<<< HEAD
            Application.Quit();
=======
            EditorApplication.isPlaying = false;
>>>>>>> c66f5ca348e9b26c3c3e737ad90acc2d58d7c479
        }
    }
}
