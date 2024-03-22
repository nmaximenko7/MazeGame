using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    public Vector3 offset = new Vector3(10f, 20f, 0f); // Отступ камеры от игрока

    void LateUpdate()
    {
        // Установка позиции камеры над игроком с учетом отступа
        transform.position = player.position + offset;

        // Направление камеры в сторону игрока
        transform.LookAt(player);
    }
}
