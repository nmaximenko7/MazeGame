using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player; // ������ �� ������
    public Vector3 offset = new Vector3(10f, 20f, 0f); // ������ ������ �� ������

    void LateUpdate()
    {
        // ��������� ������� ������ ��� ������� � ������ �������
        transform.position = player.position + offset;

        // ����������� ������ � ������� ������
        transform.LookAt(player);
    }
}
