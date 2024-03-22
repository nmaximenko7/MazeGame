using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    void Start()
    {
        transform.position = new Vector3(0, transform.localScale.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // �������� ���� � ���������� ��� ���� WSAD
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // ��������� ������ �������� �� ������ �����
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // ����������� ��������� ����������� �������� � ���������� ������������ ���������
        movement = transform.TransformDirection(movement);

        // ������� ������ � �������� �����������
        transform.Translate(movement * _speed * Time.deltaTime);
    }
}
