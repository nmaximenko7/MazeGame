using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private Joystick _joystick;
    private Vector2 _touchStartPos;
    void Start()
    {
        transform.position = new Vector3(0, transform.localScale.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        //RotateCharacter();
    }

    private void RotateCharacter()
    {
        if (Input.touchCount < 1) return;
        if (Input.touchCount > 0 && Input.touchCount < 3 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _touchStartPos = Input.GetTouch(0).position;
        }
        Vector2 swipeVector = Input.GetTouch(0).position - _touchStartPos;
        swipeVector.Normalize();
        float angle = Mathf.Atan2(swipeVector.y, swipeVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    private void MoveCharacter()
    {
        float moveHorizontal = _joystick.Horizontal;
        float moveVertical = _joystick.Vertical;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = transform.TransformDirection(movement);
        transform.Translate(movement * _speed * Time.deltaTime);
    }
}
