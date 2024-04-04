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
            // ���� ��, �� ������� ��������� � ����� � �������
            Debug.Log("You are win");
            EditorApplication.isPlaying = false;
        }
    }
}
