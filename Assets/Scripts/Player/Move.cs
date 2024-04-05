using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private Joystick _joystick;

    private float _gravity = -9.8f;
    private CharacterController _characterController;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if (_characterController == null)
            Debug.Log("CharacterController is NULL");
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = _joystick.Horizontal * _speed;
        float moveVertical = _joystick.Vertical * _speed;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = Vector3.ClampMagnitude(movement, _speed);
        movement.y = _gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
